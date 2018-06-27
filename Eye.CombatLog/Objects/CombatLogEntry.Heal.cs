using Eye.CombatLog.Core;
using Eye.CombatLog.Interfaces;

namespace Eye.CombatLog.Objects
{
    public class CombatLogEntryHeal : CombatLogEntry,
        ICombatLogEntryTargetable,
        ICombatLogEntryAttackable,
        ICombatLogEntryInflictorable,
        ICombatLogEntryVisible
    {
        public string Target { get; set; }
        public string TargetSource { get; set; }
        public bool IsTargetIllusion { get; set; }
        public bool IsTargetHero { get; set; }

        public string AttackerName { get; set; }
        public string DamageSource { get; set; }
        public bool IsAttackerIllusion { get; set; }
        public bool IsAttackerHero { get; set; }

        public string Inflictor { get; set; }

        public bool IsVisibleRadiant { get; set; }
        public bool IsVisibleDire { get; set; }

        public int Heal { get; set; }
        public int TargetHealth { get; set; }

        public int LastHits { get; set; }

        public override void Make()
        {
            this.MakeTargetable(this);
            this.MakeAttackable(this);
            this.MakeInflictorable(this);
            this.MakeVisible(this);

            Heal = GetFirstValue();
            TargetHealth = GetSecondValue();

            LastHits = GetIntField("last_hits");
        }
    }
}