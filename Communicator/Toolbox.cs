using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Communicator
{
    public static class Toolbox
    {
        public readonly static int BUFFERSIZE = (int)Math.Pow(2, 12) * 2;
        public readonly static int RATE = 22100;

        public static byte[] AddressStringToByte(string IP)
        {
            IPAddress address = IPAddress.Parse(IP);
            byte[] bytes = address.GetAddressBytes();
            return bytes;
        }

        public static byte[] StringToByte(string arg)
        {
            return Encoding.ASCII.GetBytes(arg);
        }

        public static IPAddress GetMachineIP()
        {
            using (Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, 0))
            {
                socket.Connect("8.8.8.8", 65530);
                IPEndPoint endPoint = socket.LocalEndPoint as IPEndPoint;
                return endPoint.Address;
            }
        }
    }
}
