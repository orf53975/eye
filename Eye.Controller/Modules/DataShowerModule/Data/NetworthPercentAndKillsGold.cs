using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eye.Controller.Modules.DataShowerModule.Commands;
using Eye.Controller.Modules.DataShowerModule.Events;
using Eye.Events.Core;
using Eye.Objects;

namespace Eye.Controller.Modules.DataShowerModule.Data
{
    public class NetworthPercentAndKillsGold : IData
    {
        public string Name => "Золото с убийств/процент нетворсов";
        public IReadOnlyList<IEyeStateEvent> Events => _events;

        private readonly IEyeStateEvent[] _events = new IEyeStateEvent[255];

        private readonly NetworthPercentCalculator _networthPercentCalculator;
        private readonly KillsGoldEvent _killsGoldEvent;

        private int[] _golds;
        
        public NetworthPercentAndKillsGold()
        {
            _golds = new int[10];

            _events[0] = _networthPercentCalculator = new NetworthPercentCalculator();
            _events[1] = _killsGoldEvent = new KillsGoldEvent();


            _killsGoldEvent.Gold += (sender, e) => _golds[e.Member.Index] += e.Gold;
        }

        public TextValue GetText()
        {
            return new TextValue
            {
                Name = "% OF NETWORTH",
                Color = "gold",
                Datas = _networthPercentCalculator.Networthes.Select((networth, index) => $"{Math.Round((double)_golds[index] / networth * 100d, 1)}%")
            };
        }

        public DataValue GetData()
        {
            return new DataValue
            {
                Name = "GOLD FROM KILLS",
                Color = "gold",
                Icon = "gold",
                Datas = _golds.Select(DataUtils.NumberFormat)
            };
        }

        public void Reload()
        {
            _golds = new int[10];
        }
    }
}
