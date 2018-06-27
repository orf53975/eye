namespace Eye.Controller.Modules.SmokeModule.Commands
{
    public class SmokeModifierAdded : IEyePlayerCommand
    {
        public int Type => 8;
        public int Hero { get; set; }
    }
}
