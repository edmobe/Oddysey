﻿using System;
using System.IO;
using System.Media;

namespace OddyseyUI
{
    public class AudioFile
    {
        public String Name { get; set; }
        public String Author { get; set; }
        public String Album { get; set; }
        public String Year { get; set; }
        public String Lyrics { get; set; }
        public String Time { get; set; }
        public String Score { get; set; }
        public String Data { get; set; }

        public void SetMainParameters(String name, String author)
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
