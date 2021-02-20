using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{

    public static class ServerConfiguration
    {
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
