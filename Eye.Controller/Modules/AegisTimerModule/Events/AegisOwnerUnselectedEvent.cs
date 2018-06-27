using System;
using System.Linq;
using Eye.CombatLog.Core;
using Eye.Events.Core;
using Eye.Objects;

namespace Eye.Controller.Modules.AegisTimerModule.Events
{
    public class AegisOwnerUnselectedEvent : IEyeStateEntryEvent
    {
        public event EventHandler AegisOwnerUnselected;

        public void Execute(EyeStateEntry entry, CombatLogEntry combatLogEntry)
        {
            OnAegisOwnerUnselected();
        }

        public bool EventPredicator(EyeStateEntry prev, EyeStateEntry entry)
        {
            if (prev == null) return false;

            try
            {
                var prevAegisOwner = prev.Members?.FirstOrDefault(m => m.Player != null && m.Items.Slots.Any(i => i.Name == "item_aegis"));
                if (prevAegisOwner == null) return false;

                var currentAegisOwner =
                    entry?.Members?.FirstOrDefault(m => m.Player != null && m.Items.Slots.Any(i => i.Name == "item_aegis"));
                if (currentAegisOwner == null) return false;

                return prevAegisOwner.Hero.SelectedUnit && currentAegisOwner.Hero.SelectedUnit == false;
            }
            catch
            {
                return false;
            }
        }

        protected virtual void OnAegisOwnerUnselected()
        {
            AegisOwnerUnselected?.Invoke(this, EventArgs.Empty);
        }
    }
}