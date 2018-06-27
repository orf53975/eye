using System;
using System.Collections.Generic;
using System.Linq;
using Eye.CombatLog.Core;
using Eye.Controller.Modules.ImportantItemsModule.ImportantItemsEvents;
using Eye.Events.Core;
using Eye.Gsi.Objects;
using Eye.Objects;

namespace Eye.Controller.Modules.ImportantItemsModule.Events
{
    public class ImportantItemRemovedEventArgs : EventArgs
    {
        public Members.Member Member { get; set; }

        public bool IsAegisAdded { get; set; }
        public bool IsRapierAdded { get; set; }
        public bool IsGemAdded { get; set; }
    }

    public class ImportantItemRemovedEvent : IEyeStateEntryEvent
    {
        public event EventHandler<ImportantItemRemovedEventArgs> ImportantItemRemoved;

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
                        OnImportantItemRemoved(new ImportantItemRemovedEventArgs { Member = member, IsGemAdded = true });
                        break;
                    case "item_rapier":
                        OnImportantItemRemoved(new ImportantItemRemovedEventArgs { Member = member, IsRapierAdded = true });
                        break;
                    case "item_aegis":
                        OnImportantItemRemoved(new ImportantItemRemovedEventArgs { Member = member, IsAegisAdded = true });
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

                if (currentMember.Items.Slots.All(i => i.Name != "item_gem") &&
                    prevMember.Items.Slots.Any(i => i.Name == "item_gem"))
                {
                    var item = prevMember.Items.SearchItemByName("item_gem");

                    _items.Add(new KeyValuePair<Members.Member, Items.Item>(currentMember, item));
                    flag = true;
                }

                if (currentMember.Items.Slots.All(i => i.Name != "item_rapier") &&
                    prevMember.Items.Slots.Any(i => i.Name == "item_rapier"))
                {
                    var item = prevMember.Items.SearchItemByName("item_rapier");

                    _items.Add(new KeyValuePair<Members.Member, Items.Item>(currentMember, item));
                    flag = true;
                }

                if (currentMember.Items.Slots.All(i => i.Name != "item_aegis") &&
                    prevMember.Items.Slots.Any(i => i.Name == "item_aegis"))
                {
                    var item = prevMember.Items.SearchItemByName("item_aegis");

                    _items.Add(new KeyValuePair<Members.Member, Items.Item>(currentMember, item));
                    flag = true;
                }
            }

            return flag;
        }

        protected virtual void OnImportantItemRemoved(ImportantItemRemovedEventArgs e)
        {
            ImportantItemRemoved?.Invoke(this, e);
        }
    }
}
