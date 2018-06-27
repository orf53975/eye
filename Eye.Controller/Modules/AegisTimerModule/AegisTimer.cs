using System;
using System.Linq;
using System.Threading.Tasks;
using Eye.Controller.Modules.AegisTimerModule.Commands;
using Eye.Controller.Modules.AegisTimerModule.Events;
using Eye.Gsi.Objects;
using Eye.Objects;

namespace Eye.Controller.Modules.AegisTimerModule
{
    public class AegisTimer : IControllerModule
    {
        public string Name => "Таймер аегиса";

        public event EventHandler AegisTaken;

        private readonly AegisTakenEvent _takenEvent;
        private readonly AegisOwnerSelectedEvent _onwerSelectedEvent;
        private readonly AegisOwnerUnselectedEvent _ownerUnselectedEvent;
        private readonly AegisOwnerSlotChangedEvent _ownerSlotChangedEvent;

        private readonly EyeController _controller;
        private readonly int _aegisTime = 5 * 60 * 1000;

        public AegisTimer(EyeController controller)
        {
            _takenEvent = new AegisTakenEvent();
            _takenEvent.AegisTaken += OnAegisTaken;

            _onwerSelectedEvent = new AegisOwnerSelectedEvent();;
            _onwerSelectedEvent.AegisOwnerSelected += AegisOwnerSelected;

            _ownerUnselectedEvent = new AegisOwnerUnselectedEvent();
            _ownerUnselectedEvent.AegisOwnerUnselected += AegisOwnerUnselected;

            _ownerSlotChangedEvent = new AegisOwnerSlotChangedEvent();
            _ownerSlotChangedEvent.AegisOwnerSlotChanged += AegisOwnerSlotChanged;

            _controller = controller;

            _controller.EventManager.Subscribe(_onwerSelectedEvent);
            _controller.EventManager.Subscribe(_ownerUnselectedEvent);
            _controller.EventManager.Subscribe(_ownerSlotChangedEvent);
        }

        private void AegisOwnerSlotChanged(object sender, AegisOwnerSlotChangedEventArgs e)
        {
            AegisOwnerUnselected(this, EventArgs.Empty);
            AegisOwnerSelected(this, new AegisOwnerSelectedEventArgs {Member = e.Member, Slot = e.Slot});
        }

        private void AegisOwnerUnselected(object sender, EventArgs e)
        {
            _controller.PlayerController.Execute(new AegisOwnerUnselected());
        }

        private void AegisOwnerSelected(object sender, AegisOwnerSelectedEventArgs e)
        {
            _controller.PlayerController.Execute(new AegisOwnerSelected { Abilities = e.Member.Abilities.Abilities.Count, Slot = e.Slot });
        }

        private void OnAegisTaken(object sender, Members.Member member)
        {
            /*_aegisTaken = true;
            _aegisTakenAt = _controller.StateIntegrator.StateEntry.Map.ClockTime;

            Task.Delay(_aegisTime).ContinueWith(t => Refresh());

            _controller.PlayerController.Execute(new AegisTaken());

            OnAegisTaken();*/
        }

        protected virtual void OnAegisTaken()
        {
            AegisTaken?.Invoke(this, EventArgs.Empty);
        }

        public bool Enabled { get; private set; } = true;

        public void Enable()
        {
            if(Enabled) return;

            //_controller.EventManager.Subscribe(_takenEvent);

            _controller.EventManager.Subscribe(_onwerSelectedEvent);
            _controller.EventManager.Subscribe(_ownerUnselectedEvent);
            _controller.EventManager.Subscribe(_ownerSlotChangedEvent);

            Enabled = true;
        }

        public void Disable()
        {
            if (!Enabled) return;

            AegisOwnerUnselected(this, EventArgs.Empty);


            //_controller.EventManager.Unsubscribe(_takenEvent);

            _controller.EventManager.Unsubscribe(_onwerSelectedEvent);
            _controller.EventManager.Unsubscribe(_ownerUnselectedEvent);
            _controller.EventManager.Unsubscribe(_ownerSlotChangedEvent);

            Enabled = false;
        }

        public void Reload()
        {
            AegisOwnerUnselected(this, EventArgs.Empty);
        }
    }
}