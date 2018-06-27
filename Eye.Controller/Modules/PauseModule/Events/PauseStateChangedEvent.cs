using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eye.CombatLog.Core;
using Eye.Events.Core;
using Eye.Objects;

namespace Eye.Controller.Modules.PauseModule.Events
{
    public class PauseStateChangedEvent : IEyeStateEntryEvent
    {
        public event EventHandler<bool> StateChanged;

        private bool _state;

        public void Execute(EyeStateEntry entry, CombatLogEntry combatLogEntry)
        {
            OnStateChanged(_state);
        }

        public bool EventPredicator(EyeStateEntry prev, EyeStateEntry entry)
        {
            if (prev == null) return false;

            if (prev.Map.Paused == false && entry.Map.Paused)
            {
                _state = true;
                return true;
            }
            if (prev.Map.Paused && entry.Map.Paused == false)
            {
                _state = false;
                return true;
            }

            return false;
        }

        protected virtual void OnStateChanged(bool e)
        {
            StateChanged?.Invoke(this, e);
        }
    }
}
