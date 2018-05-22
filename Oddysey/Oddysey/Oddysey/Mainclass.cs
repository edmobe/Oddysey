using System;

namespace Oddysey
{
    class Mainclass
    {
        public static void Main(String[] args) {
            Client c = new Client();
            AudioFile s1 = new AudioFile();
            s1.SetMainParameters("Macarena", "Autores macarenos", "120");
            s1.Metadata = "akjshdfnuyg87!#@$%TFqdiuehwfung1873!@#$%%T1251891155/*--asdf46519234877....a/sdfujhqwerf";
            Console.WriteLine("Presione Enter para enviar la macarena :v");
            while (true)
            {
                if (Console.ReadKey().Key == ConsoleKey.Enter)
                {
                    c.SendAudioFile(s1);
                }
            }
        }
    }
}
