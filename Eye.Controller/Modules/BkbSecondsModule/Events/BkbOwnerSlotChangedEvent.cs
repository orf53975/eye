using System;
using System.Linq;
using Eye.CombatLog.Core;
using Eye.Events.Core;
using Eye.Objects;

namespace Eye.Controller.Modules.BkbSecondsModule.Events
{
    public class BkbOwnerSlotChangedEventArgs : EventArgs
    {
        public Members.Member Member { get; set; }
        public int Slot { get; set; }
    }

    public class BkbOwnerSlotChangedEvent : IEyeStateEntryEvent
    {
        public event EventHandler<BkbOwnerSlotChangedEventArgs> OwnerSlotChanged;

        private Members.Member _member;
        private int _slot;

        public void Execute(EyeStateEntry entry, CombatLogEntry combatLogEntry)
        {
            OnOwnerSlotChanged(new BkbOwnerSlotChangedEventArgs { Member = _member, Slot = _slot});
        }

        public bool EventPredicator(EyeStateEntry prev, EyeStateEntry entry)
        {
            if (prev == null) return false;

            try
            {
                /*var currentSelectedOwner = entry.Members?.FirstOrDefault(m => m.Hero.SelectedUnit && m.Items.Slots.Any(i => i.Name == "item_black_king_bar"));
                var prevSelectedOwner = entry.Members?.FirstOrDefault(m => m.Hero.SelectedUnit && m.Items.Slots.Any(i => i.Name == "item_black_king_bar"));

                if (currentSelectedOwner == null || prevSelectedOwner == null ||
                    currentSelectedOwner != prevSelectedOwner) return false;

                var currentItem = currentSelectedOwner.Items.SearchItemByName("item_black_king_bar");
                var prevItem = prevSelectedOwner.Items.SearchItemByName("item_black_king_bar");

                if (currentItem.Slot == prevItem.Slot) return false;

                _member = currentSelectedOwner;
                return true;*/

                var currentSelectedOwner = entry.Members?.FirstOrDefault(m => m.Hero.SelectedUnit && m.Items.Slots.Any(i => i.Name == "item_black_king_bar"));
                var prevSelectedOwner = entry.Members?.FirstOrDefault(m => m.Hero.SelectedUnit && m.Items.Slots.Any(i => i.Name == "item_black_king_bar"));

                if (currentSelectedOwner == null || prevSelectedOwner == null ||
                    currentSelectedOwner.Index != prevSelectedOwner.Index) return false;

                var currentItem = currentSelectedOwner.Items.SearchItemByName("item_black_king_bar");
                var prevItem = prevSelectedOwner.Items.SearchItemByName("item_black_king_bar");

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

        protected virtual void OnOwnerSlotChanged(BkbOwnerSlotChangedEventArgs e)
        {
            OwnerSlotChanged?.Invoke(this, e);
        }
    }
}