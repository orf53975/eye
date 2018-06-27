namespace Eye.CombatLog.Interfaces
{
    public interface ICombatLogEntryVisible
    {
        bool IsVisibleRadiant { get; set; }
        bool IsVisibleDire { get; set; }
    }
}