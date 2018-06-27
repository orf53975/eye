using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eye.Controller.Modules.SmokeModule.Commands;
using Eye.Controller.Modules.SmokeModule.Events;
using Eye.Objects;

namespace Eye.Controller.Modules.SmokeModule
{
    public class Smoke : IControllerModule
    {
        public string Name => "Смока";

        private readonly SmokeModifierAddedEvent _modifierAddedEvent;
        private readonly SmokeModifierRemovedEvent _modifierRemovedEvent;

        private readonly EyeController _controller;

        public Smoke(EyeController controller)
        {
            _modifierAddedEvent = new SmokeModifierAddedEvent();
            _modifierAddedEvent.ModifierAdded += ModifierAdded;

            _modifierRemovedEvent = new SmokeModifierRemovedEvent();
            _modifierRemovedEvent.ModifierRemoved += ModifierRemoved;

            _controller = controller;

            Enable();
        }

        private void ModifierAdded(object sender, Members.Member member)
        {
            _controller.PlayerController.Execute(new SmokeModifierAdded { Hero = member.Index});
        }

        private void ModifierRemoved(object sender, Members.Member member)
        {
            _controller.PlayerController.Execute(new SmokeModifierRemoved { Hero = member.Index });
        }

        public bool Enabled { get; private set; }

        public void Enable()
        {
            if (Enabled) return;

            _controller.EventManager.Subscribe(_modifierAddedEvent);
            _controller.EventManager.Subscribe(_modifierRemovedEvent);

            Enabled = true;
        }

        public void Disable()
        {
            if (!Enabled) return;

            _controller.EventManager.Unsubscribe(_modifierAddedEvent);
            _controller.EventManager.Unsubscribe(_modifierRemovedEvent);

            Enabled = false;
        }

        public void Reload()
        {
            
        }
    }
}
