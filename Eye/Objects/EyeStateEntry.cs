using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eye.CombatLog.Core;
using Eye.CombatLog.Objects;
using Eye.Gsi.Objects;
using Eye.Shared;

namespace Eye.Objects
{
    public class EyeStateEntry : IDataEntry, ICloneable
    {
        public Members Members { get;  }
        public Buildings Buildings { get; }
        public Map Map { get; }

        public Provider Provider { get;  }
        public Auth Auth { get; }
        public Draft Draft { get; }

        public EyeStateEntry Previously { get; }

        public EyeStateEntry(GameStateEntry entry)
        {
            /*if (entry.Players.Radiant != null &&
                entry.Players.Dire != null &&
                entry.Heroes.Radiant != null &&
                entry.Heroes.Dire != null &&
                entry.Abilities.Radiant != null &&
                entry.Abilities.Dire != null &&
                entry.Items.Radiant != null &&
                entry.Items.Dire != null)
            {
                if (Members != null)
                    Members.Update(entry.Players, entry.Heroes, entry.Abilities, entry.Items);
                else
                    Members = new Members();
            }*/

            Members = new Members(entry.Players, entry.Heroes, entry.Abilities, entry.Items);

            Buildings = entry.Buildings;
            Map = entry.Map;

            Draft = entry.Draft;

            Provider = entry.Provider;
            Auth = entry.Auth;

            if(entry.Previously != null)
                Previously = new EyeStateEntry(entry.Previously);
        }

        /*public static EyeStateEntry From(IDataEntry entry)
        {
            var eyeState = new EyeStateEntry();

            return null;
        }

        internal void UpdateFromGameStateEntry(GameStateEntry entry)
        {
            if (entry.Players.Radiant != null &&
                entry.Players.Dire != null &&
                entry.Heroes.Radiant != null &&
                entry.Heroes.Dire != null &&
                entry.Abilities.Radiant != null &&
                entry.Abilities.Dire != null &&
                entry.Items.Radiant != null &&
                entry.Items.Dire != null)
            {
                if (Members != null)
                    Members.Update(entry.Players, entry.Heroes, entry.Abilities, entry.Items);
                else
                    Members = new Members(this);
            }

            Buildings = entry.Buildings;
            Map = entry.Map;

            Draft = entry.Draft;

            Provider = entry.Provider;
            Auth = entry.Auth;
        }

        internal void UpdateFromCombatLogEntry(CombatLogEntry entry)
        {
            //if(entry.GetType() == typeof(CombatLogEntryModifierAdd) || entry.GetType() == typeof(CombatLogEntryModifierRemove))
            Members.Update(entry);
        }*/

        public object Clone()
        {
            return MemberwiseClone();
        }
    }

    public static class ItemsExtensions
    {
        public static Items.Item SearchItemByName(this Items.HeroItems items, string name)
        {
            return items?.Slots?.FirstOrDefault(i => i != null && i.Name == name);
        }
    }

    public class Members : IReadOnlyList<Members.Member>
    {
        public class Member
        {
            public int Index { get; }
            public Players.Player Player { get; private set; }
            public Heroes.Hero Hero { get; private set; }
            public Abilities.HeroAbilities Abilities { get; private set; }
            public Items.HeroItems Items { get; private set; }

            public Member(int index)
            {
                Index = index;
            }

            internal void Update(Players.Player player,
                Heroes.Hero hero,
                Abilities.HeroAbilities abilities,
                Items.HeroItems items)
            {
                Player = player;
                Hero = hero;
                Abilities = abilities;

                Items = items;

                if (items == null || items.Slots.Any(s => s == null)) return;

                for (var index = 0; index < Items.Slots.Count; index++)
                    Items.Slots[index].Slot = index;
            }
        }

        private readonly List<Member> _members;

        public Member Slot0 => _members[0];
        public Member Slot1 => _members[1];
        public Member Slot2 => _members[2];
        public Member Slot3 => _members[3];
        public Member Slot4 => _members[4];
        public Member Slot5 => _members[5];
        public Member Slot6 => _members[6];
        public Member Slot7 => _members[7];
        public Member Slot8 => _members[8];
        public Member Slot9 => _members[9];

        public Members(Players players, Heroes heroes, Abilities abilities, Items items)
        {
            _members = new List<Member>();
            for (var i = 0; i < 10; i++)
                _members.Add(new Member(i));

            _members[0].Update(players?.Radiant?.Slot0, heroes?.Radiant?.Slot0, abilities?.Radiant?.Hero0, items?.Radiant?.Hero0);
            _members[1].Update(players?.Radiant?.Slot1, heroes?.Radiant?.Slot1, abilities?.Radiant?.Hero1, items?.Radiant?.Hero1);
            _members[2].Update(players?.Radiant?.Slot2, heroes?.Radiant?.Slot2, abilities?.Radiant?.Hero2, items?.Radiant?.Hero2);
            _members[3].Update(players?.Radiant?.Slot3, heroes?.Radiant?.Slot3, abilities?.Radiant?.Hero3, items?.Radiant?.Hero3);
            _members[4].Update(players?.Radiant?.Slot4, heroes?.Radiant?.Slot4, abilities?.Radiant?.Hero4, items?.Radiant?.Hero4);

            _members[5].Update(players?.Dire?.Slot5, heroes?.Dire?.Slot5, abilities?.Dire?.Hero5, items?.Dire?.Hero5);
            _members[6].Update(players?.Dire?.Slot6, heroes?.Dire?.Slot6, abilities?.Dire?.Hero6, items?.Dire?.Hero6);
            _members[7].Update(players?.Dire?.Slot7, heroes?.Dire?.Slot7, abilities?.Dire?.Hero7, items?.Dire?.Hero7);
            _members[8].Update(players?.Dire?.Slot8, heroes?.Dire?.Slot8, abilities?.Dire?.Hero8, items?.Dire?.Hero8);
            _members[9].Update(players?.Dire?.Slot9, heroes?.Dire?.Slot9, abilities?.Dire?.Hero9, items?.Dire?.Hero9);
        }

        public Member SearchByHeroName(string name)
        {
            return _members?.FirstOrDefault(m => m.Hero.Name == name);
        }

        #region ReadOnlyImplementation

        public IEnumerator<Member> GetEnumerator()
        {
            return _members.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _members.GetEnumerator();
        }

        public int Count => _members.Count;
        public Member this[int index] => _members[index];

        #endregion
    }
}
