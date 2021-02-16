using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    interface Receiver
    {
        void StartReceive();
        //void SendAnswer(string Message);
    }

    public class ServerReceiver : Receiver
    {
        private TcpClient client;
        private NetworkStream stream;

        public ServerReceiver(TcpClient _client)
        {
            client = _client;
            stream = client.GetStream();
        }

        public void StartReceive()
        {
            try
            {
                if (stream.CanRead)
                {
                    byte[] myReadBuffer = new byte[1024];
                    StringBuilder myCompleteMessage = new StringBuilder();
                    int numberOfBytesRead = 0;
                    do
                    {
                        numberOfBytesRead = stream.Read(myReadBuffer, 0, myReadBuffer.Length);
                        myCompleteMessage.AppendFormat("{0}", Encoding.UTF8.GetString(myReadBuffer, 0, numberOfBytesRead));
                    }
                    while (stream.DataAvailable);
                    //new Task(() => CommandManager.CommandLine(myCompleteMessage.ToString())).Start();
                    CommandManager.CommandLine(myCompleteMessage.ToString());

                    Console.WriteLine(myCompleteMessage);

                }
            }
            finally
            {
                //stream.Close();
                //client.Close();
            }
        }

        //public void SendAnswer(string Message)
        //{
        //    Byte[] responseData = Encoding.UTF8.GetBytes(Message);
        //    stream.Write(responseData, 0, responseData.Length);
        //}

    }
}
