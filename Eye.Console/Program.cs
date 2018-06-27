using System;
using System.Collections.Generic;
using System.Linq;
using Eye.CombatLog.Core;
using Eye.CombatLog.Objects;
using Eye.Events.Core;
using Eye.Gsi.Core;
using Eye.Gsi.Objects;
using Eye.Objects;
using Eye.Shared;

namespace Eye.Main
{
    public class EmptyCombatLogListener : IDataListener<CombatLogEntry>
    {
        public event EventHandler<Exception> Error;
        public event EventHandler<CombatLogEntry> DataReceived;

        public void Listen()
        {
            //throw new NotImplementedException();
        }

        public void Stop()
        {
            //throw new NotImplementedException();
        }
    }

    internal class Program
    {
        private static EyeStateEventManager _eyeStateEventManager;
        private static EyeStateIntegrator _eyeStateIntegrator;

        static void Main(string[] args)
        {
            //Console.SetWindowPosition(1920 + 200, 200);
            //Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);

            var gsl = new GameStateListener();
            var cll = new CombatLogListener(@"C:\Program Files (x86)\Steam\steamapps\common\dota 2 beta\game\dota\combat.log");

            _eyeStateIntegrator = new EyeStateIntegrator(gsl, cll);
            _eyeStateEventManager = new EyeStateEventManager(_eyeStateIntegrator);

            _eyeStateIntegrator.Start();

            Console.ReadLine();
        }

        private static void CombatLogEventReceived(object sender, CombatLogEntry entry)
        {
            var stateEntry = _eyeStateIntegrator.StateEntry;

            if (entry.Type == CombatLogEntryTypes.Damage)
            {
                var entryDamage = entry as CombatLogEntryDamage;

                var attacker = stateEntry.Members.SearchByHeroName(entryDamage.AttackerName);
                if(attacker == null) return;

                var target = stateEntry.Members.SearchByHeroName(entryDamage.Target);
                Console.WriteLine($"{attacker.Player.Name}[{attacker.Hero.Name}] hit {(target != null ? target.Player.Name + $"[{target.Hero.Name}]" : entryDamage.Target)}");
            }
            /*if (entry.Type == CombatLogEntryTypes.ModifierAdd ||
                entry.Type == CombatLogEntryTypes.ModifierRemove)
            {
                var entryModifierChanged = entry as CombatLogEntryModifierAdd;

                var member = stateEntry.Members.SearchByHeroName(entryModifierChanged.Target);
                if(member == null) return;

                var name = member.Hero.Name;
                var modifiers = string.Join(", ", member.Modifiers.ActiveModifiers.Select(m => m.Name));


                Console.SetCursorPosition(0, member.Index);
                Console.Write(" ".PadLeft(Console.LargestWindowWidth - 1));
                Console.SetCursorPosition(0, member.Index + 1);
                Console.Write(" ".PadLeft(Console.LargestWindowWidth - 1));


                Console.SetCursorPosition(0, member.Index * 2);
                Console.Write(member.Hero.Alive ? 
                    $"{name} have {modifiers}!" :
                    $"{name} dead!");

            }*/
        }
    }
}
