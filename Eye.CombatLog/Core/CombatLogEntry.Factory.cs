using System;
using System.Collections.Generic;
using Eye.CombatLog.Objects;

namespace Eye.CombatLog.Core
{
    public static class CombatLogEntryFactory
    {
        public static CombatLogEntry Create(CombatLogEntryTypes type)
        {
            switch (type)
            {
                case CombatLogEntryTypes.Invalid:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
                case CombatLogEntryTypes.Damage:
                    return new CombatLogEntryDamage();
                case CombatLogEntryTypes.Heal:
                    return new CombatLogEntryHeal();
                case CombatLogEntryTypes.ModifierAdd:
                    return new CombatLogEntryModifierAdd();
                case CombatLogEntryTypes.ModifierRemove:
                    return new CombatLogEntryModifierRemove();
                case CombatLogEntryTypes.Death:
                    return new CombatLogEntryDeath();
                case CombatLogEntryTypes.Ability:
                    return new CombatLogEntryAbility();
                case CombatLogEntryTypes.Item:
                    return new CombatLogEntryItem();
                case CombatLogEntryTypes.GameState:
                    return new CombatLogEntryGameState();
                case CombatLogEntryTypes.Gold:
                    return new CombatLogEntryGold();
                default:
                    return new CombatLogEntry();
            }
        }

        public static CombatLogEntry Create(CombatLogEntryTypes type, List<KeyValuePair<string, string>> fields)
        {
            var entry = Create(type);

            entry.Type = type;

            entry.Fields = fields;
            entry.Timestamp = entry.GetDoubleField("timestamp");
            entry.Make();

            return entry;
        }
    }
}