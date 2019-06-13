using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Communicator
{
    class TcpListenerTask
    {
        public delegate void ReceivedConnection();
        public event ReceivedConnection ReceivedConnectionEvent;

        public IPAddress receivedIP;

        private Thread task;

        public TcpListenerTask()
        {
            task = new Thread(() =>
            {
                UdpClient client = new UdpClient(45001);
                IPEndPoint remoteEndPoint = new IPEndPoint(IPAddress.Any, 0);

                while (true)
                {
                    if (!SelectWindow.GetAppState().isBusy)
                    {
                        Byte[] rec = client.Receive(ref remoteEndPoint);

                        string recstr = Encoding.ASCII.GetString(rec);
                        string header = recstr.Substring(0, Definitions.WANT_TO_CONNECT.Length);
                        if (header.Equals(Definitions.WANT_TO_CONNECT))
                        {
                            byte[] data = Toolbox.StringToByte(Definitions.OK_TALK + SelectWindow.GetAppState().currentUsername);
                            client.Send(data, data.Length, new IPEndPoint(remoteEndPoint.Address, 45001));

                            receivedIP = remoteEndPoint.Address;
                            ReceivedConnectionEvent?.Invoke();
                            client.Close();
                            break;
                        }
                        else if (header.Equals(Definitions.OK_TALK))
                        {
                            receivedIP = remoteEndPoint.Address;
                            ReceivedConnectionEvent?.Invoke();
                            client.Close();
                            
                            break;
                        }
                    }
                }


            });
            task.IsBackground = true;
        }

        public void Run()
        {
            task.Start();
        }
    }
}
