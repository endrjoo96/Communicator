using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Communicator
{
    class CleanerTask
    {
        public delegate void RemoveIdlers();
        public event RemoveIdlers RemovingIdlers;

        private Thread task;

        public CleanerTask()
        {
            int waitTime = SelectWindow.GetAppState().RefreshInterval;
            task = new Thread(() =>
            {
                while (true)
                {
                    Thread.Sleep(waitTime);
                    RemovingIdlers?.Invoke();
                }
            });
            task.IsBackground = true;
        }

        public void Run()
        {
            task.Start();
        }

        public ObservableCollection<User> CleanIdleUsers(ObservableCollection<User> list)
        {
            var current = DateTimeOffset.Now.ToUnixTimeMilliseconds();
            var threshold = SelectWindow.GetAppState().RefreshInterval;
            foreach(User u in list.ToList())
            {
                long calc = current - u.ConnTime;
                if (calc >= threshold)
                {
                    list.Remove(u);
                }
            }
            return list;
        }
    }
}
