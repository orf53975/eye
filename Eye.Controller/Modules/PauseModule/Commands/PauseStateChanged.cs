using System;
using Eye.CombatLog.Core;
using Eye.Events.Core;
using Eye.Objects;

namespace Eye.Controller.Modules.PauseModule.Commands
{
    public class PauseStateChanged : IEyePlayerCommand
    {
        public int Type => 12;
        public bool State { get; set; }
    }
}
