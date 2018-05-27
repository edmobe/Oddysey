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
        private List<AudioFile> SongList;

        public Client ()
        {
            SongList = new List<AudioFile>();
            UpdateSongs();
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

        public void AddSong(string fileName)
        {
            // Recordar verificar si la canción ya existe
            XmlMessage m1 = new XmlMessage();
            AudioFile audio = new AudioFile();
            Form2 f2 = new Form2();
            f2.ShowDialog();
            audio.SetMainParameters(f2.name, f2.author, f2.album, f2.score);
            audio.Data = Convert.ToBase64String(File.ReadAllBytes(fileName));
            string toSend = m1.GetAddSongXML(audio);
            SendMessage(toSend, "001/null");
            UpdateSongs();
        }

        public void UpdateSongs()
        {
            SongList = new List<AudioFile>();
            string songMetadataXml = SendMessage("", "002/null");
            // Aquí se recibe el XML con los nombres de todas las canciones (falta)
            // Aquí se deserializa el XML (falta)

            // Una prueba del código:
            string[] breakApart = songMetadataXml.Split('\\');
            for (int i = 0; i < breakApart.Length; i += 4)
            {
                string[] song = { breakApart[i], breakApart[i + 1], breakApart[i + 2], breakApart[i + 3] };
                AudioFile audio = new AudioFile();
                audio.SetMainParameters(song[0], song[1], song[2], song[3]);
                if (!SongList.Contains(audio))
                {
                    SongList.Add(audio);
                }
            }
        }

        public List<AudioFile> GetSongList()
        {
            return SongList;
        }

        public AudioFile GetAudio(string name, string author)
        {
            for (int i = 0; i < SongList.Count; i++)
            {
                var song = SongList[i];
                if(song.Name == name && song.Author == author)
                {
                    return song;
                }
            }
            return null;
        }

    }
}
