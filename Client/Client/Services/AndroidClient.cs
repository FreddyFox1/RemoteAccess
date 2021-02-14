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
        }

        public string PowerOff(string Message)
        {
            ClientSender = new TcpClient(IPAddress, Port);
            Byte[] data = Encoding.UTF8.GetBytes(Message);
            NetworkStream stream = ClientSender.GetStream();

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
                return responseData;
            }
            finally
            {
                stream.Close();
                ClientSender.Close();
            }
        }

    }
}
