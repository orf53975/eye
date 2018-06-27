namespace Eye.Controller.Modules.AegisTimerModule.Commands
{
    public class AegisOwnerSelected : IEyePlayerCommand
    {
        public int Type => 1;

        public int Abilities { get; set; }
        public int Slot { get; set; }
    }
}