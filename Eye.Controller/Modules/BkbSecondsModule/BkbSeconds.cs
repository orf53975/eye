using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eye.Controller.Modules.AegisTimerModule.Commands;
using Eye.Controller.Modules.BkbSecondsModule.Commands;
using Eye.Controller.Modules.BkbSecondsModule.Events;
using Eye.Objects;

namespace Eye.Controller.Modules.BkbSecondsModule
{
    public class BkbSeconds : IControllerModule
    {
        public string Name => "Действие бкб";

        public bool Enabled { get; private set; }

        private readonly EyeController _controller;

        private readonly BkbUsedEvent _usedEvent;
        private readonly BkbOwnerSelectedEvent _ownerSelectedEvent;
        private readonly BkbOwnerUnselectedEvent _ownerUnselectedEvent;
        private readonly BkbOwnerSlotChangedEvent _ownerSlotChangedEvent;

        private readonly Dictionary<int, int> _bkbsSeconds;

        public BkbSeconds(EyeController controller)
        {
            _bkbsSeconds = new Dictionary<int, int>();
            for (var i = 0; i < 10; i++)
                _bkbsSeconds.Add(i, 10);

            _usedEvent = new BkbUsedEvent();
            _usedEvent.BkbUsed += BkbUsed;
            _ownerSelectedEvent = new BkbOwnerSelectedEvent();
            _ownerSelectedEvent.OwnerSelected += OwnerSelected;
            _ownerUnselectedEvent = new BkbOwnerUnselectedEvent();
            _ownerUnselectedEvent.OwnerUnselected += OwnerUnselected;
            _ownerSlotChangedEvent = new BkbOwnerSlotChangedEvent();
            _ownerSlotChangedEvent.OwnerSlotChanged += OwnerSlotChanged;

            _controller = controller;

            Enable();
        }

        private void OwnerSlotChanged(object sender, BkbOwnerSlotChangedEventArgs e)
        {
            OwnerUnselected(this, EventArgs.Empty);
            OwnerSelected(this, new BkbOwnerSelectedEventArgs {Member = e.Member, Slot = e.Slot});
        }

        private void OwnerSelected(object sender, BkbOwnerSelectedEventArgs e)
        {
            var abilities = e.Member.Abilities.Abilities.Count.ToString();
            var slot = e.Slot;
            var seconds = _bkbsSeconds[e.Member.Index];

            if (e.Member.Hero.Name == "dota_npc_hero_morphling")
                abilities = "Morphling";

            _controller.PlayerController.Execute(new BkbOwnerSelected {Abilities = abilities, Slot = slot, Seconds = seconds, Member = e.Member.Index});
        }

        private void OwnerUnselected(object sender, EventArgs eventArgs)
        {
            _controller.PlayerController.Execute(new BkbOwnerUnselected());
        }

        private void BkbUsed(object sender, BkbUsedEventArgs e)
        {
            var index = e.Member.Index;
            _bkbsSeconds[index] = e.Seconds;

            _controller.PlayerController.Execute(new BkbUsed { Seconds = _bkbsSeconds[index], Member = index});
        }

        public void Enable()
        {
            if(Enabled) return;

            _controller.EventManager.Subscribe(_usedEvent);
            _controller.EventManager.Subscribe(_ownerUnselectedEvent);
            _controller.EventManager.Subscribe(_ownerSelectedEvent);
            _controller.EventManager.Subscribe(_ownerSlotChangedEvent);

            Enabled = true;
        }

        public void Disable()
        {
            if(!Enabled) return;

            OwnerUnselected(this, EventArgs.Empty);

            _controller.EventManager.Unsubscribe(_usedEvent);
            _controller.EventManager.Unsubscribe(_ownerUnselectedEvent);
            _controller.EventManager.Unsubscribe(_ownerSelectedEvent);
            _controller.EventManager.Unsubscribe(_ownerSlotChangedEvent);

            Enabled = false;
        }

        public void Reload()
        {
            for (var i = 0; i < 10; i++)
                _bkbsSeconds[i] = 10;


            OwnerUnselected(this, EventArgs.Empty);
        }
    }
}
