using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Core
{

    public static class SystemMessages
    {

        public static string WelcomeMsg
        {
            get
            {
                return "Welcome";
            }
        }
        public static string ServerStartMsg
        {
            get
            {
                return "Server started";
            }
        }
        public static string ServerStopMsg
        {
            get
            {
                return "Server stopped";
            }
        }
    }
}
