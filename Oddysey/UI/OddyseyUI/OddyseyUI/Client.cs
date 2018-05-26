using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;

namespace OddyseyUI
{
    class Client
    {
        private Socket clientSocket;
        private WMPLib.WindowsMediaPlayer Player;
        private Boolean Playing;
        private LinkedList<string[]> SongList = new LinkedList<string[]>();

        public Client ()
        {
            Player = new WMPLib.WindowsMediaPlayer();
        }

        public String SendMessage(String message, String OPCode)
        {

            // Testing
            CreateTestFile(message);

            // Main parameters
            IPEndPoint serverAddress = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 6000);
            clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            clientSocket.Connect(serverAddress);

            // Sending OPCode
            byte[] toSendCode = System.Text.Encoding.UTF8.GetBytes(OPCode);
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

            clientSocket.Close();

            return finalReply;
            
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

        public void Play(AudioFile audio)
        {
            if (Playing)
            {
                Stop();
            }
            else
            {
                Playing = false;
            }

            string url = @"Temp\" + audio.Name + "-" + audio.Author + ".mp3";
            if (!File.Exists(url))
            {
                File.WriteAllBytes(url, Convert.FromBase64String(audio.Data));
            }
            Player.URL = url;
            Player.controls.play();

        }

        public void Stop()
        {
            Playing = false;
            Player.URL = null;
            Player.controls.stop();
        }

        public void AddSong(string fileName)
        {
            // Recordar verificar si la canción ya existe
            XmlMessage m1 = new XmlMessage();
            AudioFile audio = new AudioFile();
            Form2 f2 = new Form2();
            f2.ShowDialog();
            audio.SetMainParameters(f2.name, f2.author);
            audio.Data = Convert.ToBase64String(File.ReadAllBytes(fileName));
            string toSend = m1.GetAddSongXML(audio);
            SendMessage(toSend, "001/null");
            UpdateSongs();
        }

        public void UpdateSongs()
        {
            string songMetadataXml = SendMessage("", "002/null");
            // Aquí se recibe el XML con los nombres de todas las canciones (falta)
            // Aquí se deserializa el XML (falta)

            // Una prueba del código:
            string[] breakApart = songMetadataXml.Split('\\');
            for (int i = 0; i < breakApart.Length; i += 4)
            {
                string[] song = { breakApart[i], breakApart[i + 1], breakApart[i + 2], breakApart[i + 3] };
                SongList.AddLast(song);
            }
        }

        public LinkedList<String[]> GetSongList()
        {
            return SongList;
        }

    }
}
