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

        Client client;
        public Boolean Logd;
        public Boolean Paused;
        public AudioFile Playing;

        public Form1()
        {
            Console.WriteLine("Hello world!");
            client = new Client();
            client.UpdateSongs();
            client.UpdateSongs();
            Logd = true;
            Playing = new AudioFile();
            InitializeComponent();
            for (int i = 0; i < client.GetSongList().Count; i++)
            {
                AudioFile song = client.GetSongList()[i]; // En lugar de 0 es i
                dataGridView1.Rows.Add(song.Name, song.Author, song.Album, song.Score);
            }         


        }
        public void ChangeLabel(String text)
        {

        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            //Toma el texto del search textbox y lo
            
        }

        private void Play_Click(object sender, EventArgs e) // If play button was pressed
        {
            if (!Paused) // If the music is playing
            {
                axWindowsMediaPlayer1.Ctlcontrols.pause(); // Pauses the song
                Paused = true; // Is paused
                Play.Text = "Play";
            }
            else
            {
                DataGridViewCellCollection currentRow = dataGridView1.CurrentRow.Cells; // Get the selected song information
                string name = currentRow[0].Value.ToString(); // Name of the song
                string author = currentRow[1].Value.ToString(); // Author of the song
                AudioFile audio = client.GetAudio(name, author); // Get the AudioFile object from the audio list available in the client
                if (Playing == null || !Playing.Equals(audio)) // If no song is being played or the selected song changed
                {
                    Playing = audio;
                    string url = @"Temp\" + Playing.Name + "-" + Playing.Author + ".mp3"; // The song URL
                    if (!File.Exists(url)) // If the song has not been downloaded
                    {
                        File.WriteAllBytes(url, Convert.FromBase64String(Playing.Data)); // Downloads the song
                    }
                    axWindowsMediaPlayer1.URL = url; // Adds the song to the player
                    axWindowsMediaPlayer1.Ctlcontrols.play(); // Plays the song
                    Paused = false; // Is not paused
                    Play.Text = "Pause";
                }
                else // If the song has not changed
                {
                    axWindowsMediaPlayer1.Ctlcontrols.play(); // Plays the song
                    Paused = false; // Is not paused
                    Play.Text = "Pause";
                }
            }

            
            
            
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
                client.AddSong(fileName);
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
            axWindowsMediaPlayer1.Ctlcontrols.stop();
            Playing = null;
            Paused = false;
            Play.Text = "Play";
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

        private void trackBar1_Scroll(object sender, EventArgs e)
        {

        }

        private void LoggedLabel_Click(object sender, EventArgs e)
        {
            Form3 Login = new Form3(this);
            Login.Show();
            
        }

        private void axWindowsMediaPlayer1_Enter(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Paused = true;
            axWindowsMediaPlayer1.Ctlcontrols.pause();
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
