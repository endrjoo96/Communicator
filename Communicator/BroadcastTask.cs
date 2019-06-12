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
                UdpClient client = new UdpClient();
                IPEndPoint remoteEndPoint = new IPEndPoint(IPAddress.Broadcast, 45000);

                while (true)
                {
                    Thread.Sleep(3 * 1000);

                    string state;
                    if (SelectWindow.GetAppState().isBusy)
                    {
                        state = Definitions.BUSY;
                    }
                    else
                    {
                        state = Definitions.NAME;
                    }

                    byte[] data = Encoding.ASCII.GetBytes(state + SelectWindow.GetAppState().currentUsername);

                    client.SendAsync(data, data.Length, remoteEndPoint);

                }
            });
        }
    }
}
