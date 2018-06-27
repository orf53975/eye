namespace Eye.Controller.Modules.SmokeModule.Commands
{
    public class SmokeModifierRemoved : IEyePlayerCommand
    {
        public int Type => 9;
        public int Hero { get; set; }
    }
}
