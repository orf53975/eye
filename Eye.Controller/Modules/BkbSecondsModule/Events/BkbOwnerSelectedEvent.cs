using System;
using System.Linq;
using Eye.CombatLog.Core;
using Eye.Events.Core;
using Eye.Objects;

namespace Eye.Controller.Modules.BkbSecondsModule.Events
{
    public class BkbOwnerSelectedEventArgs : EventArgs
    {
        public Members.Member Member { get; set; }
        public int Slot { get; set; }
    }

    public class BkbOwnerSelectedEvent : IEyeStateEntryEvent
    {
        public event EventHandler<BkbOwnerSelectedEventArgs> OwnerSelected;

        private Members.Member _member;
        private int _slot;

        public void Execute(EyeStateEntry entry, CombatLogEntry combatLogEntry)
        {
            OnOwnerSelected(new BkbOwnerSelectedEventArgs {Member = _member, Slot = _slot});
        }

        public bool EventPredicator(EyeStateEntry prev, EyeStateEntry entry)
        {
            if (prev == null) return false;

            var currentOwner =
                entry?.Members?.FirstOrDefault(m => m.Hero != null && m.Hero.SelectedUnit &&
                                                    m.Items.Slots.Any(i => i.Name == "item_black_king_bar"));
            if (currentOwner == null) return false;

            var prevOwner = prev.Members[currentOwner.Index];
            if (prevOwner.Hero.SelectedUnit &&
                prevOwner.Items.Slots.Any(i => i.Name == "item_black_king_bar")) return false;

            _member = currentOwner;
            _slot = currentOwner.Items.Slots.First(i => i.Name == "item_black_king_bar").Slot;
            return true;


            /*if (prevOwner?.Items != null && prevOwner.Items.Slots.All(i => i.Name != "item_black_king_bar"))
            {
                if (!prevOwner.Hero.SelectedUnit || !currentOwner.Hero.SelectedUnit) continue;

                _member = currentOwner;
                _slot = currentOwner.Items.Slots.First(i => i.Name == "item_black_king_bar").Slot;
                return true;
            }

            if (!prevOwner.Hero.SelectedUnit || !currentOwner.Hero.SelectedUnit) continue;

            _member = currentOwner;
            _slot = currentOwner.Items.Slots.First(i => i.Name == "item_black_king_bar").Slot;
            return true;*/
        }

        protected virtual void OnOwnerSelected(BkbOwnerSelectedEventArgs e)
        {
            OwnerSelected?.Invoke(this, e);
        }
    }
}