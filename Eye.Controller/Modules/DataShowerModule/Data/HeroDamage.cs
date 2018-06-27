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
    public class HeroDamage : IData
    {
        public string Name => "Урон по героям";
        public IReadOnlyList<IEyeStateEvent> Events => _events;

        private readonly IEyeStateEvent[] _events = new IEyeStateEvent[255];

        private readonly HeroDamageReceiver _heroDamageReceiver;

        public HeroDamage()
        {
            _events[0] = _heroDamageReceiver = new HeroDamageReceiver();
        }

        public TextValue GetText()
        {
            return new TextValue
            {
                Color = "white",
                Datas = _heroDamageReceiver.HeroesDamage.Select(DataUtils.NumberFormat),
                Name = "HERO DAMAGE"
            };
        }

        public DataValue GetData()
        {
            return null;

            /*return new DataValue
            {
                Color = "white",
                Datas = _heroDamageReceiver.HeroesDamage.Select(d => d.ToString()),
            }*/
        }

        public void Reload()
        {

        }
    }
}
