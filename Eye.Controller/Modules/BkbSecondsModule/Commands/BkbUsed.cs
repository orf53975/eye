namespace Eye.Controller.Modules.BkbSecondsModule.Commands
{
    public class BkbUsed : IEyePlayerCommand
    {
        public int Type => 5;

        public int Seconds { get; set; }
        public int Member { get; set; }
    }
}
