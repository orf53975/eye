using System;
using System.Collections.Generic;
using System.Linq;
using Eye.CombatLog.Core;
using Eye.Events.Core;
using Eye.Objects;

namespace Eye.Controller.Modules.DataShowerModule.Events
{
    public class NetworthPercentCalculator : IEyeStateEntryEvent
    {
        public IEnumerable<int> Networthes { get; private set; }

        public void Execute(EyeStateEntry entry, CombatLogEntry combatLogEntry)
        {
            /*var radiant = entry.Members.Where(m => m.Player.TeamName == "radiant");
            var dire = entry.Members.Where(m => m.Player.TeamName == "dire");

            var networthRadiant = radiant.Sum(m => (double)m.Player.NetWorth);
            var networthDire = dire.Sum(m => (double)m.Player.NetWorth);

            var networthesRadiant = radiant.Select(member => Math.Round(member.Player.NetWorth / networthRadiant * 100, 1));
            var networthesDire = dire.Select(member => Math.Round(member.Player.NetWorth / networthDire * 100, 1));

            Percentages = networthesRadiant.Concat(networthesDire);*/

            Networthes = entry.Members.Select(m => m.Player.NetWorth);
        }

        public bool EventPredicator(EyeStateEntry prev, EyeStateEntry entry)
        {
            return true;
        }
    }
}