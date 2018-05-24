using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml;

namespace OddyseyUI
{
    public partial class Form1 : Form
    {

        Client c1;

        public Form1()
        {
            c1 = new Client();
            InitializeComponent();
        }

        public String CleanInvalidXmlCharacters(String characters)
        {
            //char[] validXmlChars = characters.Where(ch => XmlConvert.IsXmlChar(ch)).ToArray();
            //return new string(validXmlChars);

            //var invalidXmlCharactersRegex = new Regex("[^\u0009\u000a\u000d\u0020-\ud7ff\ue000-\ufffd]|([\ud800-\udbff](?![\udc00-\udfff]))|((?<![\ud800-\udbff])[\udc00-\udfff])");
            //return invalidXmlCharactersRegex.Replace(characters, "");

            /*
            StringBuilder textOut = new StringBuilder(); // Used to hold the output.
            char current; // Used to reference the current character.


            if (characters == null || characters == string.Empty) return string.Empty; // vacancy test.
            for (int i = 0; i < characters.Length; i++)
            {
                current = characters[i];


                if ((current == 0x9 || current == 0xA || current == 0xD) ||
                    ((current >= 0x20) && (current <= 0xD7FF)) ||
                    ((current >= 0xE000) && (current <= 0xFFFD)) ||
                    ((current >= 0x10000) && (current <= 0x10FFFF)))
                {
                    textOut.Append(current);
                }
            }
            return textOut.ToString();
            */

            // From xml spec valid chars: 
            // #x9 | #xA | #xD | [#x20-#xD7FF] | [#xE000-#xFFFD] | [#x10000-#x10FFFF]     
            // any Unicode character, excluding the surrogate blocks, FFFE, and FFFF. 
            string re = @"[^\x09\x0A\x0D\x20-\uD7FF\uE000-\uFFFD\u10000-\u10FFFF]";
            return Regex.Replace(characters, re, "");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            XmlMessage m1 = new XmlMessage();
            AudioFile audio = new AudioFile();
            audio.SetMainParameters("Macarena", "Los del Rio", "120");
            audio.Data = CleanInvalidXmlCharacters(Convert.ToBase64String(File.ReadAllBytes("macarena.mp3")));
            Console.WriteLine(audio.Data);
            String toSend = m1.GetAddSongXML(audio);
            c1.SendMessage(toSend);
        }
    }
}
