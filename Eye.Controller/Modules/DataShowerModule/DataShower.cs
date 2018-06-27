using System.Collections.Generic;
using System.Linq;
using Eye.Controller.Modules.DataShowerModule.Commands;
using Eye.Controller.Modules.DataShowerModule.Data;

namespace Eye.Controller.Modules.DataShowerModule
{
    public class DataShower : IControllerModule
    {
        public string Name => "Показ данных";
        public bool Enabled { get; private set; }

        public List<IData> Datas { get; }

        private readonly EyeController _controller;

        public DataShower(EyeController controller)
        {
            _controller = controller;

            Datas = new List<IData>
            {
                new NetworthPercentAndKillsGold(),
                new StacksAndSupportGold(),
                new HeroDamage(),
                new WardsPlaced()
            };

            Enable();
        }

        public void Show(IData data)
        {
            if(data == null) return;

            _controller.PlayerController.Execute(new DataShow
            {
                TextValue = data.GetText(),
                DataValue = data.GetData()
            });
        }

        public void Hide()
        {
            _controller.PlayerController.Execute(new DataHide());
        }

        public void Enable()
        {
            if (Enabled) return;

            Datas.ForEach(data =>
            {
                foreach (var dataEvent in data.Events)
                    _controller.EventManager.Subscribe(dataEvent);
            });

            Enabled = true;
        }

        public void Disable()
        {
            if(!Enabled) return;

            Datas.ForEach(data =>
            {
                foreach (var dataEvent in data.Events)
                    _controller.EventManager.Unsubscribe(dataEvent);
            });

            Enabled = false;
        }

        public void Reload()
        {
            Datas.ForEach(data => data.Reload());
        }
    }
}
