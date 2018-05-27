using System;
using System.IO;
using System.Media;

namespace OddyseyUI
{
    public class AudioFile
    {
        public string Name { get; set; }
        public string Author { get; set; }
        public string Album { get; set; }
        public string Year { get; set; }
        public string Lyrics { get; set; }
        public string Time { get; set; }
        public string Score { get; set; }
        public string Data { get; set; }

        public void SetMainParameters(string name, string author, string album, string score)
        {
            Name = name;
            Author = author;
            Album = album;
            Score = score;
        }

        public void GetData()
        {
            string path = @"Temp\" + Name + "-" + Author;
            Data = Convert.ToBase64String(File.ReadAllBytes(@"Temp\" + Name + "-" + Author + ".mp3"));
        }
    }
}
