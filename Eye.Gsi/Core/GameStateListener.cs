using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;

using Eye.Gsi.Objects;
using Eye.Shared;

namespace Eye.Gsi.Core
{
    public class GameStateListener : IDataListener<GameStateEntry>
    {
        public event EventHandler<Exception> Error;
        public event EventHandler<GameStateEntry> DataReceived;
        public event EventHandler<string> RawDataReceived;

        private readonly string _address;

        private HttpListener _httpListener;
        private bool _stop;

        public GameStateListener( string address)
        {
            _address = address;

            initHttpListener();
        }

        public void Listen()
        {
            /*try
            {*/
                _httpListener.Start();
                receiveContext();
            /*}
            catch (Exception e)
            {
                OnError(e);
            }*/
        }

        public void Stop()
        {
            _httpListener.Stop();
            _stop = true;
        }

        private void initHttpListener()
        {
            _stop = false;

            _httpListener = new HttpListener();
            _httpListener.Prefixes.Add($"http://{_address}:80/gsi/");
        }

        private void receiveContext()
        {
            if(_stop) return;

            var getContextTask = _httpListener.GetContextAsync();
            getContextTask.ContinueWith(contextReceived);
        }

        private void contextReceived(Task<HttpListenerContext> task)
        {
            try
            {
                var context = task.Result;
                var request = context.Request;

                using (var steamReader = new StreamReader(request.InputStream))
                {
                    var json = steamReader.ReadToEnd();
                    var gsi = GameStateEntry.FromString(json);

                    OnRawDataReceived(json);
                    OnDataReceived(gsi);
                }

                var response = context.Response;
                response.StatusCode = 200;
                response.Close();

                receiveContext();
            }
            catch (Exception e)
            {
                OnError(e);
            }
        }

        protected virtual void OnDataReceived(GameStateEntry e)
        {
            DataReceived?.Invoke(this, e);
        }

        protected virtual void OnError(Exception e)
        {
            Error?.Invoke(this, e);
        }

        protected virtual void OnRawDataReceived(string e)
        {
            RawDataReceived?.Invoke(this, e);
        }
    }
}