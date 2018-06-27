namespace Eye.Controller.Modules.RunesModule.Commands
{
    public class RuneModifierAdded : IEyePlayerCommand
    {
        public int Type => 10;
        public int Hero { get; set; }
        public string Rune { get; set; }
    }
}
