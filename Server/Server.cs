using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
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
            Printer.Print("Сервер запущен");
        }

        public void Stop()
        {
            ServerListener.Stop();
            Printer.Print("Сервер выключен");
        }




    }
}
