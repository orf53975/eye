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
    public class SmokeModifierAddedEvent : IEyeStateComatLogEvent
    {
        public event EventHandler<Members.Member> ModifierAdded; 

        private string _hero;

        public void Execute(EyeStateEntry entry, CombatLogEntry combatLogEntry)
        {
            OnModifierAdded(entry.Members.SearchByHeroName(_hero));
        }

        public bool EventPredicator(CombatLogEntry entry)
        {
            var modifierAdd = entry as CombatLogEntryModifierAdd;
            if (modifierAdd == null) return false;
            if (modifierAdd.Inflictor != "modifier_smoke_of_deceit") return false;
            if (!modifierAdd.Target.StartsWith("npc_dota_hero")) return false;

            _hero = modifierAdd.Target;
            return true;
        }

        protected virtual void OnModifierAdded(Members.Member e)
        {
            ModifierAdded?.Invoke(this, e);
        }
    }
}
