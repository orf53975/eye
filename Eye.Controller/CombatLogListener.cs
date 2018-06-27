using System;
using System.Net;
using System.Threading.Tasks;
using Eye.CombatLog.Core;
using Eye.Shared;

namespace Eye.Controller
{
    public class CombatLogListener : IDataListener<CombatLogEntry>
    {
        public event EventHandler<Exception> Error;
        public event EventHandler<CombatLogEntry> DataReceived;

        private HttpListener _httpListener;
        private bool _stop;

        public CombatLogListener()
        {
            initHttpListener();
        }

        public void Listen()
        {
            try
            {
                _httpListener.Start();
                receiveContext();
            }
            catch (Exception e)
            {
                OnError(e);
            }
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
            _httpListener.Prefixes.Add("http://*:80/combatlog/");
        }

        private void receiveContext()
        {
            if (_stop) return;

            var getContextTask = _httpListener.GetContextAsync();
            getContextTask.ContinueWith(contextReceived);
        }

        private void contextReceived(Task<HttpListenerContext> task)
        {
            try
            {
                var context = task.Result;
                var request = context.Request;

                var combatLogEntry = CombatLogJsonParser.ParseStream(request.InputStream);

                OnDataReceived(combatLogEntry);

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

        protected virtual void OnDataReceived(CombatLogEntry e)
        {
            DataReceived?.Invoke(this, e);
        }

        protected virtual void OnError(Exception e)
        {
            Error?.Invoke(this, e);
        }
    }
}