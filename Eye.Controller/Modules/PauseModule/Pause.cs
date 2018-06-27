using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Eye.Controller.Modules.PauseModule.Commands;
using Eye.Controller.Modules.PauseModule.Events;

namespace Eye.Controller.Modules.PauseModule
{
    public class Pause : IControllerModule
    {
        public string Name => "Детектор пауз";
        public bool Enabled { get; private set; }

        private readonly EyeController _controller;

        private readonly PauseStateChangedEvent _stateChangedEvent;

        public Pause(EyeController controller)
        {
            _stateChangedEvent = new PauseStateChangedEvent();
            _stateChangedEvent.StateChanged += StateChanged;

            _controller = controller;

            Enable();
        }

        private void StateChanged(object sender, bool state)
        {
            _controller.PlayerController.Execute(new PauseStateChanged { State = state});
        }

        public void Enable()
        {
            if(Enabled) return;

            _controller.EventManager.Subscribe(_stateChangedEvent);

            Enabled = true;
        }

        public void Disable()
        {
            if (!Enabled) return;

            _controller.EventManager.Unsubscribe(_stateChangedEvent);

            Enabled = false;
        }

        public void Reload()
        {

        }
    }
}
