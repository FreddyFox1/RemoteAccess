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
            var Setting = LoadSetting();

            //Создаем объект и загружаем настройки из файла с конфигом 
            Server server = new Server(Setting.IP, Setting.PORT);
            //Запускаем сервер в отдельном потоке
            new Thread(() => server.Start()).Start();
        }


        /// <summary>
        ///Получаем настройки из файла конфигурации и возвращаем кортеж значений
        /// </summary>
        public static (string IP, int PORT) LoadSetting()
        {
            return
                (
                    IP: ConfigurationSettings.AppSettings["ServerIP"],
                    PORT: int.Parse(ConfigurationSettings.AppSettings["ServerPort"])
                );
        }
    }
}

