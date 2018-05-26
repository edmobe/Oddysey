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
            c1.UpdateSongs();
            InitializeComponent();
            for (int i = 0; i < c1.GetSongList().Count; i++)
            {
                string[] song = c1.GetSongList().ElementAt(i); // En lugar de 0 es i
                dataGridView1.Rows.Add(song[0], song[1], song[2], song[3]);
            }         


        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            //Toma el texto del search textbox y lo
            
        }

        private void Play_Click(object sender, EventArgs e)
        {
            // Validar que la canción existe no es necesario
            XmlMessage m1 = new XmlMessage();
            AudioFile audio = new AudioFile();
            DataGridViewCellCollection currentRow = dataGridView1.CurrentRow.Cells;
            string name = currentRow[0].Value.ToString();
            string author = currentRow[1].Value.ToString();
            audio.SetMainParameters(name, author);
            audio.GetData();
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
                c1.AddSong(fileName);
            }

            // c1.Play(audio);
            //Console.WriteLine(audio.Data);
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

            StringBuilder messageBoxCS = new StringBuilder();
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

        private void button4_Click_1(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

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
