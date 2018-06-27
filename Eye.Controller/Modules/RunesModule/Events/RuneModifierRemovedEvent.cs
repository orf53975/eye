using System;
using Eye.CombatLog.Core;
using Eye.CombatLog.Objects;
using Eye.Events.Core;
using Eye.Objects;

namespace Eye.Controller.Modules.RunesModule.Events
{
    public class RuneModifierRemovedEventArgs : EventArgs
    {
        public Members.Member Member { get; set; }
        public string Rune { get; set; }
    }

    public class RuneModifierRemovedEvent : IEyeStateComatLogEvent
    {
        public event EventHandler<RuneModifierRemovedEventArgs> ModifierRemoved;

        private string _hero;
        private string _rune;

        public void Execute(EyeStateEntry entry, CombatLogEntry combatLogEntry)
        {
            OnModifierRemoved(new RuneModifierRemovedEventArgs
            {
                Member = entry.Members.SearchByHeroName(_hero),
                Rune = _rune
            });
        }

        public bool EventPredicator(CombatLogEntry entry)
        {
            var modifierAdd = entry as CombatLogEntryModifierRemove;
            if (modifierAdd == null) return false;

            if (!modifierAdd.Inflictor.StartsWith("modifier_rune")) return false;
            if (!modifierAdd.Target.StartsWith("npc_dota_hero")) return false;

            _hero = modifierAdd.Target;
            _rune = modifierAdd.Inflictor.Replace("modifier_rune_", "");
            return true;
        }

        protected virtual void OnModifierRemoved(RuneModifierRemovedEventArgs e)
        {
            ModifierRemoved?.Invoke(this, e);
        }
    }
}
