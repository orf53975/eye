using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eye.Controller.Modules.ImportantItemsModule.ImportantItemsCommands
{
    public class ImportantItemAdded : IEyePlayerCommand
    {
        public int Type => 3;

        public int Member { get; set; }
        public string Item { get; set; }
    }
}
