using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eye.Objects;

namespace Eye.Events.Core
{
    public interface IEyeStateEntryEvent : IEyeStateEvent
    {
        bool EventPredicator(EyeStateEntry prev, EyeStateEntry entry);
    }
}
