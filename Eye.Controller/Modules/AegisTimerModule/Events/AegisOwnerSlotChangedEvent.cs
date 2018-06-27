using System;
using System.Linq;
using Eye.CombatLog.Core;
using Eye.Events.Core;
using Eye.Objects;

namespace Eye.Controller.Modules.AegisTimerModule.Events
{
    public class AegisOwnerSlotChangedEventArgs : EventArgs
    {
        public Members.Member Member { get; set; }
        public int Slot { get; set; }
    }

    public class AegisOwnerSlotChangedEvent : IEyeStateEntryEvent
    {
        public event EventHandler<AegisOwnerSlotChangedEventArgs> AegisOwnerSlotChanged;

        private Members.Member _member;
        private int _slot;

        public void Execute(EyeStateEntry entry, CombatLogEntry combatLogEntry)
        {
            OnAegisOwnerSlotChanged(new AegisOwnerSlotChangedEventArgs{ Member = _member, Slot = _slot });
        }

        public bool EventPredicator(EyeStateEntry prev, EyeStateEntry entry)
        {
            if (prev == null) return false;

            try
            {
                /*var prevAegisOwner = prev.Members?.FirstOrDefault(m => m.Player != null && m.Hero.SelectedUnit && m.Items.Slots.Any(i => i.Name == "item_aegis"));
                if (prevAegisOwner == null) return false;

                var currentAegisOwner =
                    entry.Members?.FirstOrDefault(m => m.Player != null && m.Hero.SelectedUnit && m.Items.Slots.Any(i => i.Name == "item_aegis"));
                if (currentAegisOwner == null) return false;

                var prevAegis = prevAegisOwner.Items.Slots.FirstOrDefault(i => i.Name == "item_aegis");
                var currentAegis = currentAegisOwner.Items.Slots.FirstOrDefault(i => i.Name == "item_aegis");

                if (prevAegis?.Slot == currentAegis?.Slot) return false;

                _slot = currentAegisOwner.Items.Slots.First(i => i.Name == "item_aegis").Slot;
                _member = currentAegisOwner;
                return true;*/

                var currentSelectedOwner = entry.Members?.FirstOrDefault(m => m.Hero.SelectedUnit && m.Items.Slots.Any(i => i.Name == "item_aegis"));
                var prevSelectedOwner = entry.Members?.FirstOrDefault(m => m.Hero.SelectedUnit && m.Items.Slots.Any(i => i.Name == "item_aegis"));

                if (currentSelectedOwner == null || prevSelectedOwner == null ||
                    currentSelectedOwner.Index != prevSelectedOwner.Index) return false;

                var currentItem = currentSelectedOwner.Items.SearchItemByName("item_aegis");
                var prevItem = prevSelectedOwner.Items.SearchItemByName("item_aegis");

                if (currentItem.Slot == prevItem.Slot) return false;

                _member = currentSelectedOwner;
                _slot = currentItem.Slot;
                return true;

            }
            catch
            {
                return false;
            }
        }

        protected virtual void OnAegisOwnerSlotChanged(AegisOwnerSlotChangedEventArgs e)
        {
            AegisOwnerSlotChanged?.Invoke(this, e);
        }
    }
}