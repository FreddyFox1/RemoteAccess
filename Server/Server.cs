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
            ServerListener.Start();

            while (true)
            {
                TcpClient client = ServerListener.AcceptTcpClient();
                NetworkStream stream = client.GetStream();
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
                        Byte[] responseData = Encoding.UTF8.GetBytes("УСПЕШНО!");
                        stream.Write(responseData, 0, responseData.Length);
                        Console.WriteLine(myCompleteMessage);
                    }
                }
                catch
                {
                    Stop();
                }

                finally
                {
                    stream.Close();
                    client.Close();
                }
            }
        }

        public void Stop()
        {
            ServerListener.Stop();
        }

    }
}
