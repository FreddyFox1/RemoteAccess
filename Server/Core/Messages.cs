using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Core
{
    /// <summary>
    /// 
    /// </summary>
    interface MessageCore
    {
        void Send(string Adress, string Message);
        void Receive(string Message);
    }

    public class Message : MessageCore
    {
        public void Receive(string Message)
        {
            throw new NotImplementedException();
        }

        public void Send(string Adress, string Message)
        {
            throw new NotImplementedException();
        }
    }
}
