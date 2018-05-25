using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;

namespace OddyseyUI
{
    class Client
    {
        Socket clientSocket;

        public void SendMessage(String message)
        {

            //Testing
            CreateTestFile(message);

            // Main parameters
            IPEndPoint serverAddress = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 6000);
            clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            clientSocket.Connect(serverAddress);

            // Sending OPCode
            byte[] toSendCode = System.Text.Encoding.UTF8.GetBytes("001");
            clientSocket.Send(toSendCode);

            clientSocket.Close();

            // Re-open (literally the one and only way I found to make this work)
            clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            clientSocket.Connect(serverAddress);

            // Sending data based on OPCode
            byte[] toSendBytes = System.Text.Encoding.UTF8.GetBytes(message);
            clientSocket.Send(toSendBytes);

            // Receiving
            byte[] replyBytes = new byte[10000000];
            clientSocket.Receive(replyBytes);
            string reply = System.Text.Encoding.UTF8.GetString(replyBytes);
            string finalReply = reply.Replace("\0", "");
            MessageBox.Show("Reply: " + finalReply);
            
            clientSocket.Close();

        }

        // Testing
        public void CreateTestFile(String message)
        {
            string path = @"Sending.txt";

            // This text is added only once to the file.
            if (!File.Exists(path))
            {
                // Create a file to write to.
                File.WriteAllText(path, message);
            }
        }

    }
}
