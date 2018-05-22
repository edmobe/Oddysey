using System;
using System.IO;

namespace Oddysey
{
    class Mainclass
    {
        public static void Main(String[] args) {

            Client c = new Client();
            AudioFile s1 = new AudioFile();
            s1.SetMainParameters("Macarena", "Autores macarenos", "120");
            Console.WriteLine("Presione Enter para enviar la macarena o X para borrar macarena");
            while (true)
            {
                if (Console.ReadKey().Key == ConsoleKey.Enter)
                {
                    XMLMessage m1 = new XMLMessage();
                    c.SendMessage(m1.GetAddSongXML(s1));
                }
                else if (Console.ReadKey().Key == ConsoleKey.X)
                {
                    XMLMessage m1 = new XMLMessage();
                    c.SendMessage(m1.GetDeleteSongXML(s1.Name, s1.Author));
                }
            }

            // var data = File.ReadAllBytes("Macarena.mp3");
        }
    }
}
