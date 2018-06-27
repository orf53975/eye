using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eye.CombatLog.Core;
using Eye.CombatLog.Objects;
using Eye.Events.Core;
using Eye.Gsi.Objects;
using Eye.Objects;

namespace Eye.Controller.Modules.BountyRuneGoldModule.Events
{
    public class GameStartedEvent : IEyeStateComatLogEvent
    {
        public event EventHandler<double> GameStarted; 

        public void Execute(EyeStateEntry entry, CombatLogEntry combatLogEntry)
        {
            OnGameStarted(combatLogEntry.Timestamp);
        }

        public bool EventPredicator(CombatLogEntry entry)
        {
            var gameState = entry as CombatLogEntryGameState;
            if (gameState == null) return false;
            if (gameState.State != (int) Map.GameState.DOTA_GAMERULES_STATE_GAME_IN_PROGRESS) return false;

            return true;
        }

        protected virtual void OnGameStarted(double e)
        {
            GameStarted?.Invoke(this, e);
        }
    }
}
