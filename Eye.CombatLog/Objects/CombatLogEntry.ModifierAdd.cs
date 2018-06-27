using Eye.CombatLog.Core;
using Eye.CombatLog.Interfaces;

namespace Eye.CombatLog.Objects
{
    public class CombatLogEntryModifierAdd : CombatLogEntry, 
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


        public bool Debuff { get; set; }
        public int TargetHealth { get; set; }

        public override void Make()
        {
            this.MakeTargetable(this);
            this.MakeAttackable(this);
            this.MakeInflictorable(this);
            this.MakeVisible(this);

            Debuff = GetFirstValue() == 1;
            TargetHealth = GetSecondValue();
        }
    }
}