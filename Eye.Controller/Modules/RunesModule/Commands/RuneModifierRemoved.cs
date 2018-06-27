namespace Eye.Controller.Modules.RunesModule.Commands
{
    public class RuneModifierRemoved : IEyePlayerCommand
    {
        public int Type => 11;
        public int Hero { get; set; }
        public string Rune { get; set; }
    }
}
