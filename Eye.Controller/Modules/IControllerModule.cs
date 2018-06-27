using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eye.Controller.Modules
{
    public interface IControllerModule
    {
        string Name { get; }
        bool Enabled { get; }

        void Enable();
        void Disable();

        void Reload();
    }
}
