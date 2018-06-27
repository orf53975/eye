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
    public class WardsPlaced : IData
    {
        public string Name => "Вардов установлено";
        public IReadOnlyList<IEyeStateEvent> Events => _events;

        private readonly IEyeStateEvent[] _events = new IEyeStateEvent[255];

        private readonly WardsPlacedReceiver _wardsPlacedReceiver;

        public WardsPlaced()
        {
            _events[0] = _wardsPlacedReceiver = new WardsPlacedReceiver();
        }

        public TextValue GetText()
        {
            return new TextValue
            {
                Datas = _wardsPlacedReceiver.HeroesWardsPlaced.Select(w => w.ToString()),
                Color = "white",
                Name = "WARDS PLACED"
            };
        }

        public DataValue GetData()
        {
            return null;
        }

        public void Reload()
        {

        }
    }
}
