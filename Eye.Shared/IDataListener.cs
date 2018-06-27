using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eye.Shared
{
    public interface IDataListener<T> where T : IDataEntry
    {
        event EventHandler<Exception> Error;
        event EventHandler<T> DataReceived;

        void Listen();
        void Stop();
    }
}
