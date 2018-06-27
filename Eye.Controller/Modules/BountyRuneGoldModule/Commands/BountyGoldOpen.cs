using System.Collections.Generic;

namespace Eye.Controller.Modules.BountyRuneGoldModule.Commands
{
    public class Team
    {
        public int Bounties { get; set; }
        public int Gold { get; set; }
    }

    public class Minutes
    {
        public Team Radiant { get; set; }
        public Team Dire { get; set; }

        public int Minute { get; set; }
    }

    public class Data
    {
        public string Team1Logo { get; set; }
        public string Team2Logo { get; set; }

        public string Team1Name { get; set; }
        public string Team2Name { get; set; }

        public int Seconds { get; set; }
        public int RadiantGold { get; set; }
        public int DireGold { get; set; }

        public List<Minutes> Minutes { get; set; }
    }

    public class BountyGoldOpen : IEyePlayerCommand
    {
        public int Type => 13;

        public Data Data { get; set; }
    }
}
