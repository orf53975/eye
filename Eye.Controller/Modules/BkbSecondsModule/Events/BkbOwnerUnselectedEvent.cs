using System;
using System.Linq;
using Eye.CombatLog.Core;
using Eye.Events.Core;
using Eye.Objects;

namespace Eye.Controller.Modules.BkbSecondsModule.Events
{
    public class BkbOwnerUnselectedEvent : IEyeStateEntryEvent
    {
        public event EventHandler OwnerUnselected;

        public void Execute(EyeStateEntry entry, CombatLogEntry combatLogEntry)
        {
            OnOwnerUnselected();
        }

        public bool EventPredicator(EyeStateEntry prev, EyeStateEntry entry)
        {
            if (prev == null) return false;

            var prevOwner =
                prev.Members?.FirstOrDefault(m => m.Hero != null && m.Hero.SelectedUnit &&
                                                  m.Items.Slots.Any(i => i.Name == "item_black_king_bar"));
            if (prevOwner == null) return false;

            var currentOwner = entry.Members[prevOwner.Index];
            return !currentOwner.Hero.SelectedUnit;

            /*try
            {
                var prevOwners = prev.Members.Where(m => m.Player != null && m.Items.Slots.Any(i => i.Name == "item_black_king_bar")).ToList();
                var currentOwners =
                    entry?.Members.Where(m => m.Player != null && m.Items.Slots.Any(i => i.Name == "item_black_king_bar")).ToList();

                if (!prevOwners.Any()) return false;

                foreach (var prevOwner in prevOwners)
                {
                    var currentOwner = currentOwners.FirstOrDefault(o => o.Index == prevOwner.Index);
                    if(currentOwner == null) continue;

                    if (!prevOwner.Hero.SelectedUnit || currentOwner.Hero.SelectedUnit) continue;

                    return true;
                }

                return false;
            }
            catch
            {
                return false;
            }*/
        }

        protected virtual void OnOwnerUnselected()
        {
            OwnerUnselected?.Invoke(this, EventArgs.Empty);
        }
    }
}