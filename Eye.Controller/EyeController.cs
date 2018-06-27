using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Ether.Network.Common;
using Ether.Network.Packets;
using Ether.Network.Server;
using Eye.CombatLog.Core;
using Eye.Events.Core;
using Eye.Gsi.Objects;
using Eye.Objects;
using Eye.Shared;
using Fleck;
using Newtonsoft.Json;

namespace Eye.Controller
{
    public interface IEyePlayerCommand
    {
        int Type { get; }
    }

    public class EyePlayerController
    {
        public event EventHandler WebSocketServerOpened;

        private readonly WebSocketServer _webSocketServer;
        private List<IWebSocketConnection> _webSocketConnections;

        public EyePlayerController()
        {
            _webSocketConnections = new List<IWebSocketConnection>();
            _webSocketServer = new WebSocketServer("ws://127.0.0.1:81");
        }

        public void Start()
        {
            _webSocketServer.Start(socket =>
            {
                _webSocketConnections.Add(socket);
            });
        }

        public void Execute<T>(T command) where T : IEyePlayerCommand
        {
            var json = JsonConvert.SerializeObject(command);

            foreach (var connection in _webSocketConnections)
            {
                if (connection == null || !connection.IsAvailable) continue;

                connection.Send(json);

            }
        }

        protected virtual void OnWebSocketServerOpened()
        {
            //WebSocketServerOpened?.Invoke(this, EventArgs.Empty);
        }
    }

    /*public class EyeNetwork
    {
        public event EventHandler<GameStateEntry> GameStateReceived;
        public event EventHandler<CombatLogEntry> CombatLogReceived;

        private ISocket _listenSocket;
        private Thread _acceptThread;

        public EyeNetwork()
        {
            
        }

        public void Start()
        {
            _listenSocket = AweSock.TcpListen(8765);

            _acceptThread = new Thread(acceptThread);
            _acceptThread.Start();
        }

        private void acceptThread()
        {
            while (true)
            {
                var clientSocket = _listenSocket.Accept();

                Task.Factory.StartNew(() => recv(clientSocket));
            }
        }

        private void recv(ISocket clientSocket)
        {
            do
            {
                var buffer = Buffer.New(1024 * 128);
                var bytesReceived = AweSock.ReceiveMessage(clientSocket, buffer).Item1;

                if (bytesReceived > 0)
                {
                    var type = Buffer.Get<int>(buffer);
                    var json = Buffer.Get<string>(buffer);

                    eventInvoker(type, json);

                } else if (bytesReceived == 0) return;

            } while (true);
        }

        private void eventInvoker(int type, string json)
        {
            switch (type)
            {
                case 0:
                    OnCombatLogReceived(CombatLogJsonParser.ParseString(json));
                    break;
                case 1:
                    OnGameStateReceived(GameStateEntry.FromString(json));
                    break;
                default:
                    throw new Exception("Unexcepted type!");
            }
        }

        protected virtual void OnGameStateReceived(GameStateEntry e)
        {
            GameStateReceived?.Invoke(this, e);
        }

        protected virtual void OnCombatLogReceived(CombatLogEntry e)
        {
            CombatLogReceived?.Invoke(this, e);
        }
    }*/

    public class EyeClient : NetUser
    {
        public event EventHandler<GameStateEntry> GameStateReceived;
        public event EventHandler<CombatLogEntry> CombatLogReceived;

        public override void HandleMessage(INetPacketStream packet)
        {
            var type = packet.Read<int>();
            var json = packet.Read<string>();

            switch (type)
            {
                case 0:
                    OnCombatLogReceived(CombatLogJsonParser.ParseString(json));
                    break;
                case 1:
                    OnGameStateReceived(GameStateEntry.FromString(json));
                    break;
                default:
                    throw new Exception("Unexcepted type!");
            }
        }

        protected virtual void OnGameStateReceived(GameStateEntry e)
        {
            GameStateReceived?.Invoke(this, e);
        }

        protected virtual void OnCombatLogReceived(CombatLogEntry e)
        {
            CombatLogReceived?.Invoke(this, e);
        }
    }

    public class EyeServer : NetServer<EyeClient>
    {
        public event EventHandler<GameStateEntry> GameStateReceived;
        public event EventHandler<CombatLogEntry> CombatLogReceived;

        public EyeServer()
        {
            Configuration.Backlog = 100;
            Configuration.Port = 8765;
            Configuration.Host = Program.LocalAddress.ToString();
            Configuration.BufferSize = 1024 * 128;
            Configuration.Blocking = false;
        }

        protected override void Initialize()
        {
            
        }

        protected override void OnClientConnected(EyeClient connection)
        {
            connection.CombatLogReceived += OnCombatLogReceived;
            connection.GameStateReceived += OnGameStateReceived;
        }

        protected override void OnClientDisconnected(EyeClient connection)
        {
            connection.CombatLogReceived += OnCombatLogReceived;
            connection.GameStateReceived += OnGameStateReceived;
        }

        protected override void OnError(Exception exception)
        {

        }

        private void OnGameStateReceived(object sender, GameStateEntry entry)
        {
            OnGameStateReceived(entry);
        }

        private void OnCombatLogReceived(object sender, CombatLogEntry entry)
        {
            OnCombatLogReceived(entry);
        }

        protected virtual void OnGameStateReceived(GameStateEntry e)
        {
            GameStateReceived?.Invoke(this, e);
        }

        protected virtual void OnCombatLogReceived(CombatLogEntry e)
        {
            CombatLogReceived?.Invoke(this, e);
        }
    }

    public class NetworkGameStateListener : IDataListener<GameStateEntry>
    {
        private readonly EyeServer _network;

        public event EventHandler<Exception> Error;
        public event EventHandler<GameStateEntry> DataReceived;

        public NetworkGameStateListener(EyeServer network)
        {
            _network = network;
        }

        private void GameStateReceived(object sender, GameStateEntry entry)
        {
            OnDataReceived(entry);
        }

        public void Listen()
        {
            _network.GameStateReceived += GameStateReceived;
        }

        public void Stop()
        {
            _network.GameStateReceived -= GameStateReceived;
        }

        protected virtual void OnDataReceived(GameStateEntry e)
        {
            DataReceived?.Invoke(this, e);
        }
    }

    public class NetworkCombatLogListener : IDataListener<CombatLogEntry>
    {
        private readonly EyeServer _network;

        public event EventHandler<Exception> Error;
        public event EventHandler<CombatLogEntry> DataReceived;

        public NetworkCombatLogListener(EyeServer network)
        {
            _network = network;
        }

        private void CombatLogReceived(object sender, CombatLogEntry entry)
        {
            OnDataReceived(entry);
        }

        public void Listen()
        {
            _network.CombatLogReceived += CombatLogReceived;
        }

        public void Stop()
        {
            _network.CombatLogReceived -= CombatLogReceived;
        }

        protected virtual void OnDataReceived(CombatLogEntry e)
        {
            DataReceived?.Invoke(this, e);
        }
    }

    public class EyeStateListener : IDataListener<EyeStateEntry>
    {
        private readonly NetworkGameStateListener _gameStateListener;

        public event EventHandler<Exception> Error;
        public event EventHandler<EyeStateEntry> DataReceived;

        public EyeStateListener(NetworkGameStateListener gameStateListener)
        {
            _gameStateListener = gameStateListener;
        }

        private void GameStateDataReceived(object sender, GameStateEntry entry)
        {
            OnDataReceived(new EyeStateEntry(entry));
        }

        public void Listen()
        {
            _gameStateListener.DataReceived += GameStateDataReceived;
        }

        public void Stop()
        {
            _gameStateListener.DataReceived -= GameStateDataReceived;
        }

        protected virtual void OnDataReceived(EyeStateEntry e)
        {
            DataReceived?.Invoke(this, e);
        }
    }

    public class EyeController
    {
        public EyeStateEventManager EventManager => _stateEventManager;
        public EyePlayerController PlayerController => _playerController;
        public EyeServer Network => _network;
        public EyeStateEntry Entry => _entry;

        private EyeStateEntry _entry;

        private readonly EyeStateEventManager _stateEventManager;
        private readonly EyePlayerController _playerController;
        private readonly EyeServer _network;

        private readonly NetworkGameStateListener _networkGameStateListener;
        private readonly NetworkCombatLogListener _networkCombatLogListener;

        private readonly EyeStateListener _eyeStateListener;

        public EyeController(EyePlayerController playerController)
        {
            _playerController = playerController;

            _network = new EyeServer();

            _networkGameStateListener = new NetworkGameStateListener(Network);
            _networkCombatLogListener = new NetworkCombatLogListener(Network);
            _eyeStateListener = new EyeStateListener(_networkGameStateListener);
            _eyeStateListener.DataReceived += (sender, entry) => _entry = entry;

            _stateEventManager = new EyeStateEventManager(_eyeStateListener, _networkCombatLogListener);
        }

        public void Start()
        {
            _playerController.Start();

            _networkCombatLogListener.Listen();
            _networkGameStateListener.Listen();
            _eyeStateListener.Listen();

            _network.Start();
        }
    }
}