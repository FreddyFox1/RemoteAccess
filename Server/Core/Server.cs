using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Core
{
    /// <summary>
    /// Server base function
    /// </summary>
    interface ServerCore
    {
        void StartServer();
        void StopServer();
    }

    public class Server : ServerCore
    {
        public void StartServer()
        {
            throw new NotImplementedException();
        }

        public void StopServer()
        {
            throw new NotImplementedException();
        }
    }
}
