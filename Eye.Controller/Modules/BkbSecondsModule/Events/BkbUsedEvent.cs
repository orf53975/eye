using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eye.CombatLog.Core;
using Eye.CombatLog.Objects;
using Eye.Events.Core;
using Eye.Objects;

namespace Eye.Controller.Modules.BkbSecondsModule.Events
{
    public class BkbUsedEventArgs : EventArgs
    {
        public Members.Member Member { get; set; }
        public int Seconds { get; set; }
    }

    public class BkbUsedEvent : IEyeStateComatLogEvent
    {
        public event EventHandler<BkbUsedEventArgs> BkbUsed; 

        private string _hero;

        public void Execute(EyeStateEntry entry, CombatLogEntry combatLogEntry)
        {
            var item = (CombatLogEntryItem)combatLogEntry;

            var seconds = 10;
            switch (item.AbilityLevel)
            {
                case 1:
                    seconds = 9;
                    break;
                case 2:
                    seconds = 8;
                    break;
                case 3:
                    seconds = 7;
                    break;
                case 4:
                    seconds = 6;
                    break;
                case 5:
                    seconds = 5;
                    break;
                case 6:
                    seconds = 5;
                    break;
                default:
                    break;
            }

            var args = new BkbUsedEventArgs
            {
                Member = entry.Members.SearchByHeroName(_hero),
                Seconds = seconds
            };

            OnBkbUsed(args);
        }

        public bool EventPredicator(CombatLogEntry entry)
        {
            if (entry.Type != CombatLogEntryTypes.Item) return false;

            var item = (CombatLogEntryItem)entry;
            if (item.Inflictor != "item_black_king_bar") return false;

            _hero = item.AttackerName;

            return true;
        }

        protected virtual void OnBkbUsed(BkbUsedEventArgs e)
        {
            BkbUsed?.Invoke(this, e);
        }
    }
}
