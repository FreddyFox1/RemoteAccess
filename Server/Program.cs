using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            ///Config server
            Server server = new Server("192.168.31.211", 21);
            server.Start();
            Console.ReadLine();
        }
    }
}

