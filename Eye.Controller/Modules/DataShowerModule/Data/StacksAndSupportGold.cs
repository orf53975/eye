using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eye.Controller.Modules.DataShowerModule.Commands;
using Eye.Controller.Modules.DataShowerModule.Events;
using Eye.Events.Core;

namespace Eye.Controller.Modules.DataShowerModule.Data
{
    public class StacksAndSupportGold : IData
    {
        public string Name => "Стаки и суппорт голда";
        public IReadOnlyList<IEyeStateEvent> Events => _events;

        private readonly IEyeStateEvent[] _events = new IEyeStateEvent[255];

        private readonly StacksCountReceiver _stacksCountReceiver;
        private readonly SupportGoldReceiver _supportGoldReceiver;

        public StacksAndSupportGold()
        {
            _events[0] = _stacksCountReceiver = new StacksCountReceiver();
            _events[1] = _supportGoldReceiver = new SupportGoldReceiver();
        }

        public TextValue GetText()
        {
            return new TextValue
            {
                Name = "STACKS",
                Color = "white",
                Datas = _stacksCountReceiver.Stacks.Select(count => count.ToString())
            };
        }

        public DataValue GetData()
        {
            return new DataValue
            {
                Name = "SUPPORT GOLD SPENT",
                Color = "gold",
                Icon = "gold",
                Datas = _supportGoldReceiver.SupportGold.Select(DataUtils.NumberFormat)
            };
        }

        public void Reload()
        {

        }
    }
}
