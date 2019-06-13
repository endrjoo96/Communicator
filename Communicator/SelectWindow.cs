using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Communicator
{
    public partial class SelectWindow : Form
    {
        private static ObservableCollection<User> guestList = null;

        private ListenerTask listener;
        private CleanerTask cleaner;
        private BroadcastTask broadcaster;
        private TcpListenerTask tcplistener;
        private TalkingTask talking;

        private static AppState appstate;

        public SelectWindow()
        {
            InitializeComponent();
            guestList = new ObservableCollection<User>();
            guestList.CollectionChanged += GuestList_CollectionChanged;
            
            appstate = new AppState
            {
                MachineIP = Toolbox.GetMachineIP()
            };
            listener = new ListenerTask();
            listener.Run();
            cleaner = new CleanerTask();
            cleaner.RemovingIdlers += Cleaner_RemovingIdlers;
            cleaner.Run();
            broadcaster = new BroadcastTask();
            broadcaster.Run();
            tcplistener = new TcpListenerTask();
            tcplistener.ReceivedConnectionEvent += Tcplistener_ReceivedConnectionEvent;
            tcplistener.Run();

            if (Label_Username.Text.Equals(""))
            {
                EnterNameForm form = new EnterNameForm();
                if (form.ShowDialog() == DialogResult.OK)
                {
                    Label_Username.Text = form.result;
                    appstate.currentUsername = form.result;
                }
            }

            listView_guests.Scrollable = true;
            listView_guests.View = View.Details;
            listView_guests.Columns.Add(new ColumnHeader { Text = "", Name = "col" });
            listView_guests.HeaderStyle = ColumnHeaderStyle.None;
            listView_guests.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            User usr = new User("genericuser1", "0.0.0.0", true);
            guestList.Add(usr);
        }

        private void Tcplistener_ReceivedConnectionEvent()
        {
            appstate.isBusy = true;
            talking = new TalkingTask(tcplistener.receivedIP);
            talking.Run();
            string usr="";
            foreach (User u in guestList.ToList())
            {
                if (u.Address.Equals(tcplistener.receivedIP)) { usr = u.Nickname; }
            }
            connectedWith_label.Text = "Połączono z " + usr;
            disconnect_button.Enabled = true;
        }

        private void Cleaner_RemovingIdlers()
        {
            if (InvokeRequired)
            {
                Invoke(new MethodInvoker(() =>
                {
                    guestList = cleaner.CleanIdleUsers(guestList);
                    GuestList_CollectionChanged(null, null);
                }));
            }
        }

        private void refreshListView()
        {
            listView_guests.Items.Clear();
            foreach (User u in guestList.ToList())
            {
                ListViewItem li = new ListViewItem();
                if (u.isBusy) li.ForeColor = Color.DarkGray;
                li.Text = u.Nickname + " @" + u.Address.ToString();
                li.ImageKey = u.Address.ToString();
                listView_guests.Items.Add(li);
            }
        }

        private void GuestList_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new MethodInvoker(refreshListView));
            }
            else refreshListView();
        }

        public static AppState GetAppState()
        {
            return appstate;
        }

        public static User[] GetCurrentGuests()
        {
            return guestList.ToArray();
        }

        public static ref ObservableCollection<User> GetGuestList()
        {
            return ref guestList;
        }

        public static void UpdateCurrentGuests(User arg)
        {
            if(arg.Nickname!=appstate.currentUsername)
                guestList.Add(arg);
        }

        private void listView_guests_DoubleClick(object sender, EventArgs e)
        {
            IPAddress address = IPAddress.Parse(listView_guests.SelectedItems[0].ImageKey);
            SendRequestTask sendertask = new SendRequestTask() { IP = address };
            sendertask.Run();
        }
    }
}
