using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eye.Controller.Modules.DataShowerModule.Commands;
using Eye.Events.Core;

namespace Eye.Controller.Modules.DataShowerModule
{
    public interface IData
    {
        string Name { get; }
        IReadOnlyList<IEyeStateEvent> Events { get; }

        TextValue GetText();
        DataValue GetData();

        void Reload();
    }
}
