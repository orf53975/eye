using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eye.CombatLog.Core;
using Eye.CombatLog.Objects;
using Eye.Events.Core;
using Eye.Objects;

namespace Eye.Controller.Modules.SmokeModule.Events
{
    public class SmokeModifierRemovedEvent : IEyeStateComatLogEvent
    {
        public event EventHandler<Members.Member> ModifierRemoved;

        private string _hero;

        public void Execute(EyeStateEntry entry, CombatLogEntry combatLogEntry)
        {
            OnModifierRemoved(entry.Members.SearchByHeroName(_hero));
        }

        public bool EventPredicator(CombatLogEntry entry)
        {
            var modifierAdd = entry as CombatLogEntryModifierRemove;
            if (modifierAdd == null) return false;
            if (modifierAdd.Inflictor != "modifier_smoke_of_deceit") return false;
            if (!modifierAdd.Target.StartsWith("npc_dota_hero")) return false;

            _hero = modifierAdd.Target;
            return true;
        }

        protected virtual void OnModifierRemoved(Members.Member e)
        {
            ModifierRemoved?.Invoke(this, e);
        }
    }
}
