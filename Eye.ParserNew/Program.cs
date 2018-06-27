using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Ether.Network.Client;
using Eye.CombatLog.Core;
using Eye.CombatLog.Objects;
using Eye.Gsi.Core;
using Eye.Gsi.Objects;
using Eye.Objects;
using Newtonsoft.Json;

namespace Eye.Parser
{
    public class Program
    {
#if DEBUG
        const string CombatLogFilePath = @"C:\Program Files (x86)\Steam\steamapps\common\dota 2 beta\game\dota\combat.log";
        const string GamestateIntegrationFilePath = @"C:\Program Files (x86)\Steam\steamapps\common\dota 2 beta\game\dota\cfg\gamestate_integration\gamestate_integration_eye.cfg";
        const string AutoexecFilePath = @"C:\Program Files (x86)\Steam\steamapps\common\dota 2 beta\game\dota\cfg\autoexec.cfg";
#else
        const string CombatLogFilePath = @"..\game\dota\combat.log";
        const string GamestateIntegrationFilePath = @"..\game\dota\cfg\gamestate_integration\gamestate_integration_eye.cfg";
        const string AutoexecFilePath = @"..\game\dota\cfg\autoexec.cfg";
#endif

        private static string gsiWithTokenFile = @"""Eye""{""uri""""{uri}""""timeout""""5.0""""buffer""""0.0""""throttle""""0.0""""heartbeat""""60.0""""auth""{""token""""{token}""}""data""{""buildings""""1""""provider""""1""""map""""1""""player""""1""""hero""""1""""abilities""""1""""items""""1""""draft""""1""""wearables""""1""""buildings""""1""}}";
        private static string autoexecFile = "dota_combatlog_file combat.log";
        private static string tokenFile = "token";

        //private static IPAddress _address;
        private static string _token;

        private static readonly Func<string, string> LogFormat = message => $"[{DateTime.Now.ToLongTimeString()}:{DateTime.Now.Millisecond}] {message}";

        protected static bool IsFileLocked(FileInfo file)
        {
            FileStream stream = null;

            try
            {
                stream = file.Open(FileMode.Open, FileAccess.Read, FileShare.None);
            }
            catch (IOException)
            {
                return true;
            }
            finally
            {
                stream?.Close();
            }
            return false;
        }

        static void Main(string[] args)
        {
            var logFile = $"parser{DateTime.Now.ToShortDateString()}.log";
            var logTextWriter = File.AppendText(logFile);

            Console.SetError(logTextWriter);

            Trace.Listeners.Add(new TextWriterTraceListener(Console.Out, "Console"));
            Trace.Listeners.Add(new TextWriterTraceListener(logTextWriter, "File"));
            Trace.AutoFlush = true;

            Trace.WriteLine(LogFormat("Введите локальный IP адрес управляющего компьютера."));
            Trace.WriteLine(LogFormat("Список локльных IP адресов:"));
            foreach (var ipAddress in Dns.GetHostEntry(Dns.GetHostName()).AddressList)
                if (!ipAddress.IsIPv6LinkLocal)
                    Trace.WriteLine($"{ipAddress}{(ipAddress.AddressFamily == AddressFamily.InterNetwork ? " - ваш компьютер" : "")}");

#if DEBUG
            var ip = "192.168.0.100";
#else
            var ip = Console.ReadLine();
#endif
            if (File.Exists(CombatLogFilePath))
                if (!IsFileLocked(new FileInfo(CombatLogFilePath)))
                    File.Delete(CombatLogFilePath);

            if (!File.Exists(AutoexecFilePath))
                File.WriteAllText(AutoexecFilePath, autoexecFile);


            if (!Directory.Exists(Path.GetDirectoryName(GamestateIntegrationFilePath)))
                Directory.CreateDirectory(Path.GetDirectoryName(GamestateIntegrationFilePath));

            if (!File.Exists(GamestateIntegrationFilePath))
                File.Create(GamestateIntegrationFilePath).Close();

            if (File.Exists(tokenFile))
            {
                _token = File.ReadAllText(tokenFile);
            }
            else
            {
                Trace.WriteLine(LogFormat("Введите токен обсервера, токеном является уникальная строка для каждого обсервера(лучше всего использовать краткие название вроде: obs1, obs2, obs3)"));
                _token = Console.ReadLine();
            }

            Trace.WriteLine(LogFormat($"Token: {_token}"));
            File.WriteAllText(tokenFile, _token);

            File.WriteAllText(GamestateIntegrationFilePath, gsiWithTokenFile.Replace("{uri}", "http://127.0.0.1:80/gsi").Replace("{token}", _token));

            StartParser(ip);

            Console.ReadLine();
        }

        private static void StartParser(string ip)
        {
            var gamestate = new GameStateListener("127.0.0.1");
            var combatlog = new CombatLogListener(CombatLogFilePath);

            var eyeTcpClient = new EyeTcpClient(gamestate, combatlog, ip, _token);
            eyeTcpClient.Connected += (sender, entry) => Trace.WriteLine(LogFormat("Парсер запущен!"));
            eyeTcpClient.Disconnected += (sender, entry) =>
            {
                gamestate.Stop();
                StartParser(ip);
            };
            combatlog.DataReceived += (sender, entry) =>
            {
                var gs = entry as CombatLogEntryGameState;
                if (gs == null || gs.State != (int) Map.GameState.DOTA_GAMERULES_STATE_POST_GAME) return;

                gamestate.Stop();
                combatlog.Stop();

                while (IsFileLocked(new FileInfo(CombatLogFilePath)))
                    Thread.Sleep(1000);
                File.Delete(CombatLogFilePath);

                StartParser(ip);
            };
            eyeTcpClient.Connect();
        }
    }
}