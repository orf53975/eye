using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eye.Controller.Modules.DataShowerModule.Commands
{
    public class TextValue
    {
        public string Name { get; set; }
        
        public string Color { get; set; } = "gold";

        public IEnumerable<string> Datas { get; set; }
    }

    public class DataValue
    {
        public string Name { get; set; }

        public string Icon { get; set; } = "";
        public string Color { get; set; } = "gold";

        public IEnumerable<string> Datas { get; set; }
    }

    public class DataShow : IEyePlayerCommand
    {
        public int Type => 15;

        public TextValue TextValue { get; set; }
        public DataValue DataValue { get; set; }
    }
}
