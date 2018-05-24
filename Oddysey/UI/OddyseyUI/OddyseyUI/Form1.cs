using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OddyseyUI
{
    public partial class Form1 : Form
    {

        Client c1;

        public Form1()
        {
            Console.WriteLine("Hello world!");
            c1 = new Client();
            InitializeComponent();
        }


        

        private void SearchButton_Click(object sender, EventArgs e)
        {
            //Toma el texto del search textbox y lo
            
        }

        private void Play_Click(object sender, EventArgs e)
        {
            //Reproduce la cancion
        }

        private void Equalizer_Click(object sender, EventArgs e)
        {
            // Enciende/Apaga el equalizador
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            XmlMessage m1 = new XmlMessage();
            AudioFile audio = new AudioFile();
            audio.SetMainParameters("Macarena", "Los del Rio", "120");
            audio.Data = Convert.ToBase64String(File.ReadAllBytes("macarena.mp3"));
            Console.WriteLine(audio.Data);
            String toSend = m1.GetAddSongXML(audio);
            c1.SendMessage(toSend);
        }

        private void UserLabel_Click(object sender, EventArgs e)
        {
            /*Variable logged in o algo asi que este en false cuando no hay usuario conectado.
             * Si el usuario se conecta loggedIn= true y cambia el texto al nombre de la persona que se conecto.
             */

        }
        
        private void TitleLabel_Click(object sender, EventArgs e)
        {
            //Used to sort the songs by title
        }

        private void ArtistSortLabel_Click(object sender, EventArgs e)
        {
            //Used to sort the songs by Artist's Name
            ArtistSortLabel.Text = "SORTED";
        }

        private void AlbumLabel_Click(object sender, EventArgs e)
        {
            //Used to sort the songs by Album
        }

        private void Songlist_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
