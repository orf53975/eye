using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Eye.Gsi.Objects
{
    public partial class Items
    {
        public static readonly Dictionary<string, Type> ItemLinks = new Dictionary<string, Type>
        {
            {"item_blink", typeof(BlinkDagger)},
            {"item_branches", typeof(IronBranch)},
            {"item_bottle", typeof(Bottle)},
            {"item_tpscroll", typeof(TownPortalScroll)}
        };

        public class TownPortalScroll : Item, IActiveItem, ICooldownableItem, IChargeableItem
        {
            /*public bool CanCast { get; set; }
            public int Charges { get; set; }
            public int Cooldown { get; set; }*/
        }

        public class BlinkDagger : Item, IActiveItem, ICooldownableItem
        {
            /*public bool CanCast { get; set; }
            public int Cooldown { get; set; }*/
        }

        public class IronBranch : Item, IActiveItem
        {
            /*public uint Cooldown { get; set; }
            public bool CanCast { get; set; }*/
        }

        public class Bottle : Item, IActiveItem, ICooldownableItem, IChargeableItem
        {
            [JsonProperty("contains_rune")]
            public string ContainsRune { get; set; }

            /*public bool CanCast { get; set; }
            public int Charges { get; set; }
            public int Cooldown { get; set; }*/
        }
    }
}