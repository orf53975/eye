namespace Eye.CombatLog.Interfaces
{
    public interface ICombatLogEntryTargetable
    {
        string Target { get; set; }
        string TargetSource { get; set; }

        bool IsTargetIllusion { get; set; }
        bool IsTargetHero { get; set; }
    }
}