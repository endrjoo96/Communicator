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
    class SendRequestTask
    {
        Thread task;
        public IPAddress IP { get; set; }

        public SendRequestTask()
        {
            task = new Thread(() =>
            {
                UdpClient client = new UdpClient();
                IPEndPoint remoteEndPoint = new IPEndPoint(IP, 45001);

                byte[] data = Toolbox.StringToByte(Definitions.WANT_TO_CONNECT+SelectWindow.GetAppState().currentUsername);

                client.SendAsync(data, data.Length, remoteEndPoint);

            });
            task.IsBackground = true;
        }

        public void Run()
        {
            task.Start();
        }
    }
}
