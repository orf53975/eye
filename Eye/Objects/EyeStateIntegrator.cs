using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eye.CombatLog.Core;
using Eye.Gsi.Core;
using Eye.Gsi.Objects;
using Eye.Shared;

namespace Eye.Objects
{
    public delegate void EyeStateEntryUpdate(object sender, EyeStateEntry entry);

    public class EyeStateIntegrator
    {
        public EyeStateEntry StateEntry => _currentStateEntry;
        public IDataListener<GameStateEntry> StateListener { get; }
        public event EyeStateEntryUpdate EntryUpdated;

        private EyeStateEntry _currentStateEntry;

        public EyeStateIntegrator(IDataListener<GameStateEntry> gameStateListener)
        {
            StateListener = gameStateListener;
            StateListener.DataReceived += GameStateDataReceived;
        }

        public void Start()
        {
            StateListener.Listen();
        }

        private void GameStateDataReceived(object sender, GameStateEntry entry)
        {
            _currentStateEntry = new EyeStateEntry(entry);

            OnEntryUpdated(_currentStateEntry);
        }

        protected virtual void OnEntryUpdated(EyeStateEntry entry)
        {
            EntryUpdated?.Invoke(this, entry);
        }
    }
}