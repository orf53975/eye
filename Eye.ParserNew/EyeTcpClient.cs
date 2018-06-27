using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Ether.Network.Client;
using Ether.Network.Packets;
using Eye.CombatLog.Core;
using Eye.CombatLog.Objects;
using Eye.Gsi.Core;
using Eye.Gsi.Objects;
using Newtonsoft.Json;

namespace Eye.Parser
{
    public class EyeTcpClient : NetClient
    {
        public event EventHandler Disconnected;
        public event EventHandler Connected;

        private readonly GameStateListener _gameStateListener;
        private readonly CombatLogListener _combatLogListener;
        private readonly string _token;

        public EyeTcpClient(GameStateListener gameStateListener, CombatLogListener combatLogListener, string ip, string token)
        {
            _gameStateListener = gameStateListener;
            _combatLogListener = combatLogListener;
            _token = token;

            _gameStateListener.RawDataReceived += GameStateRawDataReceived;
            _combatLogListener.DataReceived += CombatLogDataReceived;

            Configuration.Host = ip;
            Configuration.Port = 8765;
            Configuration.BufferSize = 1024 * 128;
            Configuration.TimeOut = 5000;
            Configuration.RetryMode = NetClientRetryOptions.Infinite;
        }

        private void CombatLogDataReceived(object sender, CombatLogEntry e)
        {
            if (!IsConnected) return;

            e.Token = _token;
            var json = JsonConvert.SerializeObject(e);

            var packet = new NetPacket();
            packet.Write(0);
            packet.Write(json);

            Send(packet);

            //Trace.WriteLine("CombatLog sended");
        }

        private void GameStateRawDataReceived(object sender, string e)
        {
            if(!IsConnected) return;

            var packet = new NetPacket();
            packet.Write(1);
            packet.Write(e);

            Send(packet);

            //Trace.WriteLine("GameState sended");
        }

        protected override void OnConnected()
        {
            OnConnect();

            _combatLogListener.Listen();
            _gameStateListener.Listen();
        }

        protected override void OnDisconnected()
        {
            Trace.WriteLine("Подключение потеряно!");

            _combatLogListener.Stop();
            _gameStateListener.Stop();

            OnDisconnect();
        }

        protected override void OnSocketError(SocketError socketError)
        {
            Trace.WriteLine("Подключение потеряно!");

            _combatLogListener.Stop();
            _gameStateListener.Stop();

            OnDisconnect();
        }

        protected virtual void OnDisconnect()
        {
            Disconnected?.Invoke(this, EventArgs.Empty);
        }

        protected virtual void OnConnect()
        {
            Connected?.Invoke(this, EventArgs.Empty);
        }
    }
}
