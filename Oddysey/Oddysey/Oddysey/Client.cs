using System;
using System.Net;
using System.Net.Sockets;

namespace Oddysey
{
    class Client
    {
        Socket clientSocket;

        public void SendMessage(String message)
        {

            IPEndPoint serverAddress = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 5000);
            clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            clientSocket.Connect(serverAddress);

            // Sending
            int toSendLen = System.Text.Encoding.ASCII.GetByteCount(message);
            byte[] toSendBytes = System.Text.Encoding.ASCII.GetBytes(message);
            byte[] toSendLenBytes = BitConverter.GetBytes(toSendLen);
            clientSocket.Send(toSendLenBytes);
            clientSocket.Send(toSendBytes);

            
            // Receiving
            byte[] rcvLenBytes = new byte[4];
            clientSocket.Receive(rcvLenBytes);
            int rcvLen = BitConverter.ToInt32(rcvLenBytes, 0);
            byte[] rcvBytes = new byte[rcvLen];
            clientSocket.Receive(rcvBytes);
            String rcv = System.Text.Encoding.ASCII.GetString(rcvBytes);
            Console.WriteLine("Mensaje recibido del servidor: " + rcv);

            clientSocket.Close();

        }
    }
}