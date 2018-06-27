using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Eye.CombatLog.Objects;
using Eye.Shared;

using Timer = System.Timers.Timer;

namespace Eye.CombatLog.Core
{
    public class CombatLogListener : IDataListener<CombatLogEntry>
    {
        private readonly string _combatlogFilePath;
        private readonly object _syncObject;

        public string CombatlogFileDirectory => Path.GetDirectoryName(_combatlogFilePath);
        public string CombatlogFileName => Path.GetFileName(_combatlogFilePath);

        private Timer _timer;
        private string _data;
        private long _bytesReaded;

        public CombatLogListener(string combatlogFilePath)
        {
            _combatlogFilePath = combatlogFilePath;
            _syncObject = new object();
        }

        public event EventHandler<Exception> Error;
        public event EventHandler<CombatLogEntry> DataReceived;

        public void Listen()
        {
            InitWatcher();
        }

        public void Stop()
        {
            _timer.Stop();
        }

        private void InitWatcher()
        {
            _timer = new Timer(1);
            _timer.Elapsed += (sender, args) => CheckSize();
            _timer.Start();
        }

        private void CheckSize()
        {
            if (!Monitor.TryEnter(_syncObject)) return;

            try
            {
                var file = new FileInfo(_combatlogFilePath);
                if (!file.Exists) return;

                Read(file);
            }
            catch (Exception e)
            {
                OnError(e);
            }
            finally {
                Monitor.Exit(_syncObject);
            }
        }

        private void Read(FileInfo file)
        {
            try
            {
                if (file.Length <= _bytesReaded) return;

                using (var stream = file.Open(FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                using (var reader = new StreamReader(stream))
                {
                    file.Refresh();

                    stream.Seek(-file.Length + _bytesReaded, SeekOrigin.End);

                    _data = reader.ReadToEnd();
                }

                _bytesReaded = file.Length;

                var entries = CombatLogEntry.Parse(_data);
                foreach (var entry in entries)
                    OnDataReceived(entry);
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
