using System;
using System.IO;
using System.Media;
using System.Xml.Serialization;

namespace OddyseyUI
{
    [XmlRoot("AudioFile")]
    public class AudioFile
    {
        public string Name { get; set; }
        public string Author { get; set; }
        public string Album { get; set; }
        public string Year { get; set; }
        public string Lyrics { get; set; }
        public string Length { get; set; }
        public string Score { get; set; }
        public string Data { get; set; }
        public string About { get; set; }

        public void SetMainParameters(string name, string author)
        {
            Name = name;
            Author = author;
        }

        public void GetData()
        {
            string path = @"Temp\" + Name + "-" + Author;
            Data = Convert.ToBase64String(File.ReadAllBytes(@"Temp\" + Name + "-" + Author + ".mp3"));
        }
    }
}
