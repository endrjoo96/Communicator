﻿using System;
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
        private bool _stop = false;

        public ListenerTask()
        {

            task = new Thread(() =>
            {
                List<User> guestsList = new List<User>();

                UdpClient client = new UdpClient(45000);
                IPEndPoint remoteEndPoint = new IPEndPoint(IPAddress.Any, 0);
                string currentUser = SelectWindow.GetAppState().currentUsername;
                while (true)
                {
                        //Invoke(new MethodInvoker(() => { _stop = stop; }));

                    if (_stop) break;

                    Byte[] receivedBytes = client.Receive(ref remoteEndPoint);
                    string data = Encoding.ASCII.GetString(receivedBytes);
                    string sub = data.Substring(0, Definitions.NAME.Length);
                    if ((sub.Equals(Definitions.NAME) || sub.Equals(Definitions.BUSY)))
                    {
                        bool busy = false;
                        if (sub.Equals(Definitions.BUSY)) { busy = true; }
                        User incomingUser = new User(data.Substring(data.IndexOf("|")+1), remoteEndPoint.Address, busy);
                        bool add = true;
                        
                           // Invoke(new MethodInvoker(() => { guestsList = SelectWindow.GetCurrentGuests().ToList(); }));

                        Parallel.Invoke(new Action(() => { guestsList = SelectWindow.GetCurrentGuests().ToList(); }));

                        foreach(User u in guestsList)
                        {
                            if (u.Address.Equals(incomingUser.Address))
                            {
                                if (u.Nickname.Equals(incomingUser.Nickname))
                                {
                                    if (!(u.Nickname.Equals(currentUser)))
                                    {
                                        add = false;
                                        u.UpdateConnTime();
                                        //TODO: odświeżanie listy, jeśli busy
                                        break;
                                    }
                                }
                            }
                        }
                        if (add)
                        {
                            //if(InvokeRequired)
                            //Invoke(new MethodInvoker(() => { SelectWindow.UpdateCurrentGuests(incomingUser); }));
                            Parallel.Invoke(new Action(() => { SelectWindow.UpdateCurrentGuests(incomingUser); }));
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

        public void Terminate()
        {
            _stop = true;
        }
    }
}
