using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Communicator
{
    public class AppState
    {
        public IPAddress MachineIP { get; set; }
        public readonly int RefreshInterval = 3 * 1000;
    }
}
