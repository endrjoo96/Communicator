using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Communicator
{
    class BroadcastTask
    {
        private Thread task;
        private bool stop = false;

        public BroadcastTask()
        {
            task = new Thread(() =>
            {
                UdpClient client = new UdpClient(45000);
                IPEndPoint remoteEndPoint = new IPEndPoint(IPAddress.Any, 0);
            });
        }
    }
}
