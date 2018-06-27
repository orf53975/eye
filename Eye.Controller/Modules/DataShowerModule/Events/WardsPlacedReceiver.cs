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
    public class WardsPlacedReceiver : IEyeStateEntryEvent
    {
        public IEnumerable<int> HeroesWardsPlaced { get; private set; }

        public void Execute(EyeStateEntry entry, CombatLogEntry combatLogEntry)
        {
            HeroesWardsPlaced = entry.Members.Select(m => m.Player.WardsPlaced);
        }

        public bool EventPredicator(EyeStateEntry prev, EyeStateEntry entry)
        {
            return true;
        }
    }
}
