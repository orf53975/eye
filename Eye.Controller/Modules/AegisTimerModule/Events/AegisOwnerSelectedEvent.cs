using System;
using System.Linq;
using Eye.CombatLog.Core;
using Eye.Events.Core;
using Eye.Objects;

namespace Eye.Controller.Modules.AegisTimerModule.Events
{
    public class AegisOwnerSelectedEventArgs : EventArgs
    {
        public Members.Member Member { get; set; }
        public int Slot { get; set; }
    }

    public class AegisOwnerSelectedEvent : IEyeStateEntryEvent
    {
        public event EventHandler<AegisOwnerSelectedEventArgs> AegisOwnerSelected;

        private Members.Member _member;
        private int _slot;

        public void Execute(EyeStateEntry entry, CombatLogEntry combatLogEntry)
        {
            OnAegisOwnerSelected(new AegisOwnerSelectedEventArgs { Member = _member, Slot = _slot });
        }

        public bool EventPredicator(EyeStateEntry prev, EyeStateEntry entry)
        {
            if (prev == null) return false;

            try
            {
                var prevAegisOwner =
                    prev.Members?.FirstOrDefault(m => m.Player != null && m.Items.Slots.Any(i => i.Name == "item_aegis"));

                var currentAegisOwner =
                    entry?.Members?.FirstOrDefault(m => m.Player != null && m.Items.Slots.Any(i => i.Name == "item_aegis"));

                if (currentAegisOwner == null) return false;
                if (prevAegisOwner == null)
                {
                    if (!currentAegisOwner.Hero.SelectedUnit) return false;

                    _slot = currentAegisOwner.Items.Slots.First(i => i.Name == "item_aegis").Slot;
                    _member = currentAegisOwner;
                    return true;
                }
                if (prevAegisOwner.Hero.SelectedUnit || !currentAegisOwner.Hero.SelectedUnit) return false;

                _slot = currentAegisOwner.Items.Slots.First(i => i.Name == "item_aegis").Slot;
                _member = currentAegisOwner;
                return true;
            }
            catch
            {
                return false;
            }
        }


        protected virtual void OnAegisOwnerSelected(AegisOwnerSelectedEventArgs e)
        {
            AegisOwnerSelected?.Invoke(this, e);
        }
    }
}