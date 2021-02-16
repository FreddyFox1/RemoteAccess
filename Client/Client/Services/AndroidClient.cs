using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Client.Services
{
    public class AndroidClient
    {

        private string IPAddress;
        private int Port;
        private TcpClient ClientSender;

        public AndroidClient(string iPAddress, string port)
        {
            IPAddress = iPAddress;
            Port = int.Parse(port);
            //ClientSender = new TcpClient(IPAddress, Port);
        }

        public string SendRequest(string Message)
        {
            ClientSender = new TcpClient(IPAddress, Port);
            NetworkStream stream = ClientSender.GetStream();
            Byte[] data = Encoding.UTF8.GetBytes(Message);
            try
            {
                // Отправка сообщения
                stream.Write(data, 0, data.Length);
                // Получение ответа
                Byte[] readingData = new Byte[256];
                String responseData = String.Empty;
                StringBuilder completeMessage = new StringBuilder();
                int numberOfBytesRead = 0;
                do
                {
                    numberOfBytesRead = stream.Read(readingData, 0, readingData.Length);
                    completeMessage.AppendFormat("{0}", Encoding.UTF8.GetString(readingData, 0, numberOfBytesRead));
                }
                while (stream.DataAvailable);
                responseData = completeMessage.ToString();
                if (!(String.IsNullOrEmpty(responseData)))
                {
                    return responseData;
                }
                else return "Сообщение не доставлено";
            }
            finally
            {
                stream.Close();
                ClientSender.Close();
            }
        }

    }
}
