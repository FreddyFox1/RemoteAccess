using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Configuration;
using System.Threading;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            var Configuration = ServerConfiguration.LoadSetting();
            //Создаем объект и загружаем настройки из файла с конфигом 
            Server server = new Server(Configuration.IP, Configuration.PORT);
            //Запускаем сервер в отдельном потоке
            new Thread(() => server.Start()).Start();
        }
    }
}

