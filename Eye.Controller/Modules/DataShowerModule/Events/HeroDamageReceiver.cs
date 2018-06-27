using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eye.CombatLog.Core;
using Eye.Events.Core;
using Eye.Objects;

namespace Eye.Controller.Modules.DataShowerModule.Events
{
    public class HeroDamageReceiver : IEyeStateEntryEvent
    {
        public IEnumerable<int> HeroesDamage { get; private set; }

        public void Execute(EyeStateEntry entry, CombatLogEntry combatLogEntry)
        {
            HeroesDamage = entry.Members.Select(m => m.Player.HeroDamage);
        }

        public bool EventPredicator(EyeStateEntry prev, EyeStateEntry entry)
        {
            return true;
        }
    }
}
