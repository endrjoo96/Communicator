using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
    class ListenerTask
    {
        private Thread task;
        private bool stop = false;

        public ListenerTask()
        {

            task = new Thread(() =>
            {
                List<User> guestsList = new List<User>();
                bool _stop = false;

                UdpClient client = new UdpClient(45000);
                IPEndPoint remoteEndPoint = new IPEndPoint(IPAddress.Any, 0);
                while (true)
                {
                    
                    Parallel.Invoke(new Action(() => { _stop = stop; }));
                    if (_stop) break;

                    Byte[] receivedBytes = client.Receive(ref remoteEndPoint);
                    string data = Encoding.ASCII.GetString(receivedBytes);
                    string sub = data.Substring(0, Definitions.NAME.Length);
                    if (sub.Equals(Definitions.NAME) || sub.Equals(Definitions.BUSY))
                    {
                        bool busy = false;
                        if (sub.Equals(Definitions.BUSY)) { busy = true; }
                        User incomingUser = new User(data.Substring(data.IndexOf("|")+1), remoteEndPoint.Address, busy);
                        bool add = true;

                        Parallel.Invoke(new Action(() => { guestsList = SelectWindow.GetCurrentGuests().ToList(); }));

                        foreach(User u in guestsList)
                        {
                            if (u.Address.Equals(incomingUser.Address))
                            {
                                if (u.Nickname.Equals(incomingUser.Nickname))
                                {
                                    add = false;
                                    u.UpdateConnTime();
                                    break;
                                }
                            }
                        }
                        if (add)
                        {
                            Parallel.Invoke(new Action(() => { SelectWindow.UpdateCurrentGuests(incomingUser); }));
                        }
                    }
                }
            });
        }

        public void Run()
        {
            task.Start();
        }

        public void Terminate()
        {
            stop = true;
        }
    }
}
