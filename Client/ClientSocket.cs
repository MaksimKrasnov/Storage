using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    internal class ClientSocket
    {
        public ClientSocket() { }
        Socket socket;
        static IPAddress ip = IPAddress.Parse("127.0.0.1");
        static IPEndPoint ep = new IPEndPoint(ip, 1024);
        public void startClient()
        {
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            try
            {
                socket.Connect(ep);
            }
            catch (SocketException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally { }
        }
        public string sendMsg(string msg)
        {
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            try
            {
                socket.Connect(ep);
                if (socket.Connected)
                {
                    socket.Send(System.Text.Encoding.Default.
                    GetBytes(msg));
                    string str = "";
                    byte[] buffer = new byte[15024];
                    int l;
                    l = socket.Receive(buffer);
                    str += System.Text.Encoding.Default.GetString(buffer, 0, l);
                    return str;
                }
            }
            catch (SocketException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                socket.Close();
            }
            return "nothing";
        }
        public void stopClient()
        {
            if (socket.Connected)
            {
                socket.Close();
            }
        }
    }
}

