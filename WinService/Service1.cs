using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Server;

namespace WinService
{
    public partial class Service1 : ServiceBase
    {
        public Server.Server server;
        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            var Configuration = Server.ServerConfiguration.LoadSetting();
            //Создаем объект и загружаем настройки из файла с конфигом 
            server = new Server.Server(Configuration.IP, Configuration.PORT);
            //Запускаем сервер в отдельном потоке
            new Thread(() => server.Start()).Start();
        }

        protected override void OnStop()
        {
            server.Stop();
        }
    }
}
