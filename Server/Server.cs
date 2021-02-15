using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Server
{
    public class Server
    {

        private IPAddress IPAddress;
        private int Port;
        private TcpListener ServerListener;

        public Server(string iPAddress, int port)
        {
            IPAddress = IPAddress.Parse(iPAddress);
            Port = port;
        }

        public void Start()
        {
            ServerListener = new TcpListener(IPAddress, Port);
            ServerListener.Start();

            while (true)
            {
                TcpClient client = ServerListener.AcceptTcpClient();

                if (client != null)
                {
                    ServerReceiver receiver = new ServerReceiver(client);
                    new Thread(() => receiver.StartReceive()).Start();
                }
            }
        }

        public void Stop()
        {
            ServerListener.Stop();
        }

    }
}
