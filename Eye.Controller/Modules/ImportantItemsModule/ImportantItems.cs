using System.Diagnostics;
using Eye.Controller.Modules.ImportantItemsModule.Events;
using Eye.Controller.Modules.ImportantItemsModule.ImportantItemsCommands;
using Eye.Controller.Modules.ImportantItemsModule.ImportantItemsEvents;

namespace Eye.Controller.Modules.ImportantItemsModule
{
    public class ImportantItems : IControllerModule
    {
        public string Name => "Важные предметы";

        private readonly ImportantItemAddedEvent _itemAddedEvent;
        private readonly ImportantItemRemovedEvent _itemRemovedEvent;

        private readonly EyeController _controller;

        public ImportantItems(EyeController controller)
        {
            _itemAddedEvent = new ImportantItemAddedEvent();
            _itemAddedEvent.ImportantItemAdded += ImportantItemAdded;

            _itemRemovedEvent = new ImportantItemRemovedEvent();
            _itemRemovedEvent.ImportantItemRemoved += ImportantItemRemoved;

            _controller = controller;

            Enable();
        }

        private void ImportantItemAdded(object sender, ImportantItemAddedEventArgs e)
        {
            var item = "";
            if (e.IsGemAdded)
                item = "gem";
            else if (e.IsAegisAdded)
                item = "aegis";
            else if (e.IsRapierAdded)
                item = "rapier";

            _controller.PlayerController.Execute(new ImportantItemAdded {Item = item, Member = e.Member.Index});
        }

        private void ImportantItemRemoved(object sender, ImportantItemRemovedEventArgs e)
        {
            var item = "";
            if (e.IsGemAdded)
                item = "gem";
            else if (e.IsAegisAdded)
                item = "aegis";
            else if (e.IsRapierAdded)
                item = "rapier";

            _controller.PlayerController.Execute(new ImportantItemRemoved { Item = item, Member = e.Member.Index });
        }

        public bool Enabled { get; private set; }

        public void Enable()
        {
            if (Enabled) return;

            _controller.EventManager.Subscribe(_itemAddedEvent);
            _controller.EventManager.Subscribe(_itemRemovedEvent);

            Enabled = true;
        }

        public void Disable()
        {
            if (!Enabled) return;

            _controller.EventManager.Unsubscribe(_itemAddedEvent);
            _controller.EventManager.Unsubscribe(_itemRemovedEvent);

            Enabled = false;
        }

        public void Reload()
        {

        }
    }
}
