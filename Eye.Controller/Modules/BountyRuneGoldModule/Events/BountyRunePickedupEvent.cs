using System;
using Eye.CombatLog.Core;
using Eye.CombatLog.Objects;
using Eye.Events.Core;
using Eye.Objects;

namespace Eye.Controller.Modules.BountyRuneGoldModule.Events
{
    public class BountyRunePickedupEventAegs : EventArgs
    {
        public Members.Member Member { get; set; }
        public int Gold { get; set; }
    }

    public class BountyRunePickedupEvent : IEyeStateComatLogEvent
    {
        public const double AlchemistBountyRuneMultiplier = 3.5;

        public event EventHandler<BountyRunePickedupEventAegs> PickedUp;

        private readonly BountyRuneGold _bountyRuneGold;

        public BountyRunePickedupEvent(BountyRuneGold bountyRuneGold)
        {
            _bountyRuneGold = bountyRuneGold;
        }

        public void Execute(EyeStateEntry entry, CombatLogEntry combatLogEntry)
        {
            var entryGold = combatLogEntry as CombatLogEntryGold;

            var currentTime = entry.Map.ClockTime;
            var additionalGold = currentTime / 30;
            var predictedGold = 40 + additionalGold;

            /*|| predictedGold + 2 >= entryGold.Gold &&
            predictedGold - 2 <= entryGold.Gold*/

            if ((entryGold.Target != "npc_dota_hero_alchemist" ||
                !(predictedGold * AlchemistBountyRuneMultiplier + 2 >= entryGold.Gold) ||
                !(predictedGold * AlchemistBountyRuneMultiplier - 2 <= entryGold.Gold)) &&
                (predictedGold + 2 < entryGold.Gold || predictedGold - 2 > entryGold.Gold)) return;


            /*if (predictedGold + 2 < entryGold.Gold || entryGold.Gold < predictedGold - 2) return;*/

            var member = entry.Members.SearchByHeroName(entryGold.Target);
            var gold = entryGold.Gold;

            Console.WriteLine($"{member.Hero.Name} got {gold} gold for someone picked up the bounty rune");
            OnPickedUp(new BountyRunePickedupEventAegs {Gold = gold, Member = member});
        }

        public bool EventPredicator(CombatLogEntry entry)
        {
            var entryGold = entry as CombatLogEntryGold;
            if (entryGold == null) return false;
            if (entryGold.GoldReason != GoldReason.Unspecified) return false;

            return true;
        }

        protected virtual void OnPickedUp(BountyRunePickedupEventAegs e)
        {
            PickedUp?.Invoke(this, e);
        }
    }
}
