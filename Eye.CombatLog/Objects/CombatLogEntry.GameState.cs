using Eye.CombatLog.Core;

namespace Eye.CombatLog.Objects
{
    public class CombatLogEntryGameState : CombatLogEntry
    {
        public int State { get; set; }

        public override void Make()
        {
            State = GetFirstValue();
        }
    }
}