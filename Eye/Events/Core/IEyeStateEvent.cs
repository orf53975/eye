using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eye.CombatLog.Core;
using Eye.Objects;

namespace Eye.Events.Core
{
    public interface IEyeStateEvent
    {
        void Execute(EyeStateEntry entry, CombatLogEntry combatLogEntry);
    }
}
