using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eye.CombatLog.Core;
using Eye.Gsi.Objects;
using Eye.Objects;
using Eye.Shared;

namespace Eye.Events.Core
{
    public class EyeStateEventManager
    {
        public List<string> Tokens => _tokens;
        public string CurrentToken { get; set; }
        public event EventHandler<string> NewToken; 

        private readonly List<IEyeStateEvent> _events;
        private readonly List<string> _tokens;

        private EyeStateEntry _entry;

        public EyeStateEventManager(IDataListener<EyeStateEntry> eyeStateEntryListener, IDataListener<CombatLogEntry> combatlogListener)
        {
            _events = new List<IEyeStateEvent>();
            _tokens = new List<string>();

            eyeStateEntryListener.DataReceived += EyeStateEntryReceived;
            combatlogListener.DataReceived += CombatLogEventReceived;
        }

        public void Subscribe(IEyeStateEvent stateEvent)
        {
            _events.Add(stateEvent);
        }

        public void Unsubscribe(IEyeStateEvent stateEvent)
        {
            _events.Remove(stateEvent);
        }

        public void SetCurrentToken(string token)
        {
            CurrentToken = token;
        }

        private void AddToken(string token)
        {
            if (_tokens.Contains(token)) return;

            _tokens.Add(token);
            if (_tokens.Count == 1)
                CurrentToken = token;

            OnNewToken(token);
        }

        private void CombatLogEventReceived(object sender, CombatLogEntry combatLogEntry)
        {
            AddToken(combatLogEntry.Token);

            if (combatLogEntry.Token != CurrentToken) return;

            var combatlogEvents = _events.Where(e => e is IEyeStateComatLogEvent);

            foreach (IEyeStateComatLogEvent combatlogEvent in combatlogEvents)
            {
                if (combatlogEvent.EventPredicator(combatLogEntry))
                    combatlogEvent.Execute(_entry, combatLogEntry);
            }
        }

        private void EyeStateEntryReceived(object sender, EyeStateEntry entry)
        {
            if (entry.Map == null ||
                entry.Map.State != Map.GameState.DOTA_GAMERULES_STATE_PRE_GAME &&
                entry.Map.State != Map.GameState.DOTA_GAMERULES_STATE_GAME_IN_PROGRESS &&
                entry.Map.State != Map.GameState.DOTA_GAMERULES_STATE_POST_GAME) return;

            AddToken(entry.Auth.Token);

            if (entry.Auth.Token != CurrentToken) return;

            var prev = default(EyeStateEntry);
            if (_entry != null) prev = (EyeStateEntry)_entry.Clone();

            _entry = entry;

            var entryEvents = _events.Where(e => e is IEyeStateEntryEvent);

            foreach (IEyeStateEntryEvent combatlogEvent in entryEvents)
            {
                if (combatlogEvent.EventPredicator(prev, entry))
                    combatlogEvent.Execute(entry, null);
            }
        }

        protected virtual void OnNewToken(string e)
        {
            NewToken?.Invoke(this, e);
        }
    }
}
