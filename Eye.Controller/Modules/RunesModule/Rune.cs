using Eye.Controller.Modules.RunesModule.Commands;
using Eye.Controller.Modules.RunesModule.Events;
using Eye.Controller.Modules.SmokeModule.Events;
using Eye.Objects;

namespace Eye.Controller.Modules.RunesModule
{
    public class Rune : IControllerModule
    {
        public string Name => "Руны";

        private readonly RuneModifierAddedEvent _modifierAddedEvent;
        private readonly RuneModifierRemovedEvent _modifierRemovedEvent;

        private readonly EyeController _controller;

        public Rune(EyeController controller)
        {
            _modifierAddedEvent = new RuneModifierAddedEvent();
            _modifierAddedEvent.ModifierAdded += ModifierAdded;

            _modifierRemovedEvent = new RuneModifierRemovedEvent();
            _modifierRemovedEvent.ModifierRemoved += ModifierRemoved;

            _controller = controller;

            Enable();
        }

        private void ModifierAdded(object sender, RuneModifierAddedEventArgs e)
        {
            _controller.PlayerController.Execute(new RuneModifierAdded { Hero = e.Member.Index, Rune = e.Rune});
        }

        private void ModifierRemoved(object sender, RuneModifierRemovedEventArgs e)
        {
            _controller.PlayerController.Execute(new RuneModifierRemoved { Hero = e.Member.Index, Rune = e.Rune});
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
