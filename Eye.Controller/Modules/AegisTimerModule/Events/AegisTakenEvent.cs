using System;
using System.Linq;
using Eye.CombatLog.Core;
using Eye.Events.Core;
using Eye.Objects;

namespace Eye.Controller.Modules.AegisTimerModule.Events
{
    public class AegisTakenEvent : IEyeStateEntryEvent
    {
        public event EventHandler<Members.Member> AegisTaken;

        public void Execute(EyeStateEntry entry, CombatLogEntry combatLogEntry)
        {
            var member = entry.Members.First(m => m.Items.Slots.Any(i => i.Name == "item_aegis"));

            OnAegisTaken(member);
        }

        public bool EventPredicator(EyeStateEntry prev, EyeStateEntry entry)
        {
            /*if (prev == null || current.Draft != null) return false;

            try
            {
                var isAegisInPrev = prev.Members.SelectMany(member => member?.Items?.Slots)
                    .Any(item => item.Name == "item_aegis");
                var isAegisInCurrent = current.Members.SelectMany(member => member?.Items?.Slots)
                    .Any(item => item.Name == "item_aegis");

                return isAegisInPrev == false && isAegisInCurrent;
            }
            catch
            {
                return false;
            }*/

            return false;
        }

        protected virtual void OnAegisTaken(Members.Member e)
        {
            AegisTaken?.Invoke(this, e);
        }
    }
}