using Eye.CombatLog.Interfaces;

namespace Eye.CombatLog.Core
{
    public static class CombatLogEntryExtensions
    {
        public static void MakeTargetable(this ICombatLogEntryTargetable targetable, CombatLogEntry entry)
        {
            targetable.Target = entry.GetStringField("target");
            targetable.TargetSource = entry.GetStringField("target_source");
            targetable.IsTargetIllusion = entry.GetBooleanField("is_target_illusion");
            targetable.IsTargetHero = entry.GetBooleanField("is_target_hero");
        }

        public static void MakeAttackable(this ICombatLogEntryAttackable attackable, CombatLogEntry entry)
        {
            attackable.AttackerName = entry.GetStringField("attacker_name");
            attackable.DamageSource = entry.GetStringField("damage_source");
            attackable.IsAttackerIllusion = entry.GetBooleanField("is_attacker_illusion");
            attackable.IsAttackerHero = entry.GetBooleanField("is_attacker_hero");
        }

        public static void MakeInflictorable(this ICombatLogEntryInflictorable inflictorable, CombatLogEntry entry)
        {
            inflictorable.Inflictor = entry.GetStringField("inflictor");
        }

        public static void MakeVisible(this ICombatLogEntryVisible visible, CombatLogEntry entry)
        {
            visible.IsVisibleRadiant = entry.GetBooleanField("is_visible_radiant");
            visible.IsVisibleDire = entry.GetBooleanField("is_visible_dire");
        }
    }
}