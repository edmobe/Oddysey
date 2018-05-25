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
            // Recordar verificar si la canción ya existe
            XmlMessage m1 = new XmlMessage();
            AudioFile audio = new AudioFile();
            audio.SetMainParameters("Macarena", "Los del Rio", "120");
            audio.Data = Convert.ToBase64String(File.ReadAllBytes("macarena.mp3"));

            c1.Play(audio);
            //Console.WriteLine(audio.Data);
            //String toSend = m1.GetAddSongXML(audio);
            //c1.SendMessage(toSend, "001");
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

            OpenFileDialog Open = new OpenFileDialog();
            Open.Filter = "mp3 Files (*.mp3) | *.mp3";

            
            if (Open.ShowDialog() == DialogResult.OK) // Sends the song
            {
                string fileName = Open.FileName;
                // Recordar verificar si la canción ya existe
                XmlMessage m1 = new XmlMessage();
                AudioFile audio = new AudioFile();
                Form2 f2 = new Form2();
                f2.ShowDialog();
                audio.SetMainParameters(f2.name, f2.author, "120");
                audio.Data = Convert.ToBase64String(File.ReadAllBytes(fileName));
                String toSend = m1.GetAddSongXML(audio);
                c1.SendMessage(toSend, "001");
            }

            // c1.Play(audio);
            //Console.WriteLine(audio.Data);

        }

        private void UserLabel_Click(object sender, EventArgs e)
        {
            /*Variable logged in o algo asi que este en false cuando no hay usuario conectado.
             * Si el usuario se conecta loggedIn= true y cambia el texto al nombre de la persona que se conecto.
             */
            Form3 login = new Form3();
            login.Show();

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

        private void NotificationList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void NowPlaying_Click(object sender, EventArgs e)
        {
            
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {

            System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
            messageBoxCS.AppendFormat("{0} = {1}", "CloseReason", e.CloseReason);
            messageBoxCS.AppendLine();
            messageBoxCS.AppendFormat("{0} = {1}", "Cancel", e.Cancel);
            messageBoxCS.AppendLine();
            MessageBox.Show(messageBoxCS.ToString(), "FormClosing Event");
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            c1.Stop();
        }

        /*
        private void form_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {   // User clicked 'X' button
                string[] filePaths = Directory.GetFiles(@"Temp\");
                foreach (string filePath in filePaths)
                    File.Delete(filePath);
            }
        }
        */
    }
}
