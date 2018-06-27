using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eye.CombatLog.Core;

namespace Eye.CombatLog.Objects
{
    public enum GoldReason
    {
        Unspecified	= 0,
        Death = 1,
        Buyback = 2,
        PurchaseConsumable = 3,
        PurchaseItem = 4,
        AbandonedRedistribute = 5,
        SellItem = 6,
        AbilityCost = 7,
        CheatCommand = 8,
        SelectionPenalty = 9,
        GameTick = 10,
        Building = 11,
        HeroKill = 12,
        CreepKill = 13,
        RoshanKill = 14,
        CourierKill = 15,
        SharedGold = 16,
    }

    public class CombatLogEntryGold : CombatLogEntry
    {
        public string Target { get; set; }

        public GoldReason GoldReason { get; set; }
        public int Gold { get; set; }

        public override void Make()
        {
            Target = GetStringField("target");

            GoldReason = (GoldReason)GetIntField("gold_reason");
            Gold = GetFirstValue();
        }
    }
}
