using Eye.CombatLog.Core;
using Eye.CombatLog.Interfaces;

namespace Eye.CombatLog.Objects
{
    public class CombatLogEntryAbility : CombatLogEntry,
        ICombatLogEntryAttackable,
        ICombatLogEntryInflictorable,
        ICombatLogEntryVisible
    {
        public string AttackerName { get; set; }
        public string DamageSource { get; set; }

        public bool IsAttackerIllusion { get; set; }
        public bool IsAttackerHero { get; set; }

        public string Inflictor { get; set; }

        public bool IsVisibleRadiant { get; set; }
        public bool IsVisibleDire { get; set; }

        public int AbilityLevel { get; set; }

        public int LastHits { get; set; }

        public override void Make()
        {
            this.MakeAttackable(this);
            this.MakeInflictorable(this);
            this.MakeVisible(this);

            AbilityLevel = GetIntField("ability_level");
            LastHits = GetIntField("last_hits");
        }
    }
}