namespace Eye.Controller.Modules.BkbSecondsModule.Commands
{
    public class BkbOwnerSelected : IEyePlayerCommand
    {
        public int Type => 6;

        public int Member { get; set; }
        public string Abilities { get; set; }
        public int Slot { get; set; }
        public int Seconds { get; set; }
    }
}