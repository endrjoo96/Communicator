using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Communicator
{
    public class User
    {
        private string _nickname;
        private IPAddress _address;
        private long _connTime;
        private bool _isBusy;

        public bool isBusy { get { return _isBusy; } set { _isBusy = value; } }
        public long ConnTime { get { return _connTime; } }

        public void UpdateConnTime()
        {
            _connTime = DateTimeOffset.Now.ToUnixTimeMilliseconds();
        }

        public string Nickname {
            get {
                if (IsValid())
                    return _nickname;
                else throw new NullReferenceException("User property is null (on calling _nickname)");
            }
            set => _nickname = value; }
        public IPAddress Address {
            get {
                if (IsValid())
                    return _address;
                else throw new NullReferenceException("User property is null (on calling _address)");
            }
            set => _address = value; }

        public User(string nickname, IPAddress address, bool busy)
        {
            _nickname = nickname;
            _address = address;
            _isBusy = busy;
            UpdateConnTime();
        }

        public User(string nickname, string address, bool busy)
        {
            _nickname = nickname;
            if (IPAddress.TryParse(address, out IPAddress ADDR))
            {
                _address = ADDR;
                UpdateConnTime();
            }
            else _address = null;
            _isBusy = busy;
        }

        public bool IsValid()
        {
            if (_address != null && _nickname != null) return true;
            return false;
        }
    }
}
