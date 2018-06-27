namespace Eye.CombatLog.Interfaces
{
    public interface ICombatLogEntryAttackable
    {
        string AttackerName { get; set; }
        string DamageSource { get; set; }

        bool IsAttackerIllusion { get; set; }
        bool IsAttackerHero { get; set; }
    }
}