using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eye.CombatLog.Core;
using Eye.CombatLog.Objects;
using Eye.Events.Core;
using Eye.Objects;

namespace Eye.Controller.Modules.DataShowerModule.Events
{
    public class KillsGoldEventArgs : EventArgs
    {
        public Members.Member Member { get; set; }
        public int Gold { get; set; }
    }

    public class KillsGoldEvent : IEyeStateComatLogEvent
    {
        public event EventHandler<KillsGoldEventArgs> Gold;

        public void Execute(EyeStateEntry entry, CombatLogEntry combatLogEntry)
        {
            var gold = combatLogEntry as CombatLogEntryGold;

            OnGold(new KillsGoldEventArgs { Member = entry.Members.SearchByHeroName(gold.Target), Gold = gold.Gold});
        }

        public bool EventPredicator(CombatLogEntry entry)
        {
            if (entry.Type != CombatLogEntryTypes.Gold) return false;

            var gold = entry as CombatLogEntryGold;
            if (gold.GoldReason != GoldReason.HeroKill) return false;

            return true;
        }

        protected virtual void OnGold(KillsGoldEventArgs e)
        {
            Gold?.Invoke(this, e);
        }
    }
}
