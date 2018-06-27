using System;
using System.Collections.Generic;
using System.Linq;
using Eye.CombatLog.Core;
using Eye.Events.Core;
using Eye.Gsi.Objects;
using Eye.Objects;

namespace Eye.Controller.Modules.ImportantItemsModule.ImportantItemsEvents
{
    public class ImportantItemAddedEventArgs : EventArgs
    {
        public Members.Member Member { get; set; }

        public bool IsAegisAdded { get; set; }
        public bool IsRapierAdded { get; set; }
        public bool IsGemAdded { get; set; }
    }

    public class ImportantItemAddedEvent : IEyeStateEntryEvent
    {
        public event EventHandler<ImportantItemAddedEventArgs> ImportantItemAdded;

        private List<KeyValuePair<Members.Member, Items.Item>> _items;

        public void Execute(EyeStateEntry entry, CombatLogEntry combatLogEntry)
        {
            foreach (var memberItem in _items)
            {
                var member = memberItem.Key;
                var item = memberItem.Value;

                switch (item.Name)
                {
                    case "item_gem":
                        OnImportantItemAdded(new ImportantItemAddedEventArgs { Member = member, IsGemAdded = true });
                        break;
                    case "item_rapier":
                        OnImportantItemAdded(new ImportantItemAddedEventArgs { Member = member, IsRapierAdded = true });
                        break;
                    case "item_aegis":
                        OnImportantItemAdded(new ImportantItemAddedEventArgs { Member = member, IsAegisAdded = true });
                        break;
                }
            }
        }

        public bool EventPredicator(EyeStateEntry prev, EyeStateEntry entry)
        {
            if (prev == null) return false;

            var flag = false;
            _items = new List<KeyValuePair<Members.Member, Items.Item>>();

            foreach (var currentMember in entry.Members)
            {
                var prevMember = prev.Members[currentMember.Index];

                if (currentMember.Items.Slots.Any(i => i.Name == "item_gem") &&
                    prevMember.Items.Slots.All(i => i.Name != "item_gem"))
                {
                    var item = currentMember.Items.SearchItemByName("item_gem");

                    _items.Add(new KeyValuePair<Members.Member, Items.Item>(currentMember, item));
                    flag = true;
                }

                if (currentMember.Items.Slots.Any(i => i.Name == "item_rapier") &&
                    prevMember.Items.Slots.All(i => i.Name != "item_rapier"))
                {
                    var item = currentMember.Items.SearchItemByName("item_rapier");

                    _items.Add(new KeyValuePair<Members.Member, Items.Item>(currentMember, item));
                    flag = true;
                }

                if (currentMember.Items.Slots.Any(i => i.Name == "item_aegis") &&
                    prevMember.Items.Slots.All(i => i.Name != "item_aegis"))
                {
                    var item = currentMember.Items.SearchItemByName("item_aegis");

                    _items.Add(new KeyValuePair<Members.Member, Items.Item>(currentMember, item));
                    flag = true;
                }
            }

            return flag;
        }

        protected virtual void OnImportantItemAdded(ImportantItemAddedEventArgs e)
        {
            ImportantItemAdded?.Invoke(this, e);
        }
    }
}
