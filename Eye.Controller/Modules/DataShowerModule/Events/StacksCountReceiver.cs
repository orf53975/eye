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
    public class StacksCountReceiver : IEyeStateEntryEvent
    {
        public IEnumerable<int> Stacks { get; private set; }

        public void Execute(EyeStateEntry entry, CombatLogEntry combatLogEntry)
        {
            Stacks = entry.Members.Select(m => m.Player.CampsStacked);
        }

        public bool EventPredicator(EyeStateEntry prev, EyeStateEntry entry)
        {
            return true;
        }
    }
}
