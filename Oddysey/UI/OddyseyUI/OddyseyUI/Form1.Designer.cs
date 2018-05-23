namespace OddyseyUI
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.NotiLabel = new System.Windows.Forms.Label();
            this.NotificationList = new System.Windows.Forms.ListBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.SongLabel = new System.Windows.Forms.Label();
            this.Search = new System.Windows.Forms.TextBox();
            this.SearchButton = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.LoggedLabel = new System.Windows.Forms.Label();
            this.UserLabel = new System.Windows.Forms.Label();
            this.FriendList = new System.Windows.Forms.ListBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.AlbumLabel = new System.Windows.Forms.Label();
            this.ArtistSortLabel = new System.Windows.Forms.Label();
            this.TitleLabel = new System.Windows.Forms.Label();
            this.vScrollBar2 = new System.Windows.Forms.VScrollBar();
            this.Songlist = new System.Windows.Forms.ListBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.ArtistLabel = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.NowPlaying = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.Equalizer = new System.Windows.Forms.Button();
            this.Play = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.NotiLabel);
            this.panel1.Controls.Add(this.NotificationList);
            this.panel1.Location = new System.Drawing.Point(-4, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(190, 661);
            this.panel1.TabIndex = 10;
            // 
            // NotiLabel
            // 
            this.NotiLabel.AutoSize = true;
            this.NotiLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.NotiLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.NotiLabel.Font = new System.Drawing.Font("Maiandra GD", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NotiLabel.ForeColor = System.Drawing.Color.GhostWhite;
            this.NotiLabel.Location = new System.Drawing.Point(17, 27);
            this.NotiLabel.Name = "NotiLabel";
            this.NotiLabel.Size = new System.Drawing.Size(102, 18);
            this.NotiLabel.TabIndex = 12;
            this.NotiLabel.Text = "Notifications";
            // 
            // NotificationList
            // 
            this.NotificationList.FormattingEnabled = true;
            this.NotificationList.ItemHeight = 16;
            this.NotificationList.Location = new System.Drawing.Point(16, 66);
            this.NotificationList.Name = "NotificationList";
            this.NotificationList.Size = new System.Drawing.Size(152, 500);
            this.NotificationList.TabIndex = 11;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.panel2.Controls.Add(this.SongLabel);
            this.panel2.Controls.Add(this.Search);
            this.panel2.Controls.Add(this.SearchButton);
            this.panel2.Location = new System.Drawing.Point(185, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(659, 97);
            this.panel2.TabIndex = 13;
            // 
            // SongLabel
            // 
            this.SongLabel.AutoSize = true;
            this.SongLabel.Font = new System.Drawing.Font("Maiandra GD", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SongLabel.ForeColor = System.Drawing.Color.Black;
            this.SongLabel.Location = new System.Drawing.Point(27, 9);
            this.SongLabel.Name = "SongLabel";
            this.SongLabel.Size = new System.Drawing.Size(133, 51);
            this.SongLabel.TabIndex = 2;
            this.SongLabel.Text = "Songs";
            // 
            // Search
            // 
            this.Search.Location = new System.Drawing.Point(24, 66);
            this.Search.Name = "Search";
            this.Search.Size = new System.Drawing.Size(170, 22);
            this.Search.TabIndex = 1;
            this.Search.Text = "Search";
            // 
            // SearchButton
            // 
            this.SearchButton.Font = new System.Drawing.Font("Maiandra GD", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SearchButton.Location = new System.Drawing.Point(200, 67);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(75, 27);
            this.SearchButton.TabIndex = 0;
            this.SearchButton.Text = "Search";
            this.SearchButton.UseVisualStyleBackColor = true;
            this.SearchButton.Click += new System.EventHandler(this.SearchButton_Click);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.panel4.Controls.Add(this.button1);
            this.panel4.Controls.Add(this.LoggedLabel);
            this.panel4.Controls.Add(this.UserLabel);
            this.panel4.Controls.Add(this.FriendList);
            this.panel4.Location = new System.Drawing.Point(842, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(194, 661);
            this.panel4.TabIndex = 14;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Olive;
            this.button1.Font = new System.Drawing.Font("Maiandra GD", 7.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.button1.Location = new System.Drawing.Point(113, 37);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Log out";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // LoggedLabel
            // 
            this.LoggedLabel.AutoSize = true;
            this.LoggedLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.LoggedLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.LoggedLabel.Font = new System.Drawing.Font("Maiandra GD", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoggedLabel.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.LoggedLabel.Location = new System.Drawing.Point(3, 9);
            this.LoggedLabel.Name = "LoggedLabel";
            this.LoggedLabel.Size = new System.Drawing.Size(103, 18);
            this.LoggedLabel.TabIndex = 2;
            this.LoggedLabel.Text = "Logged in as:";
            // 
            // UserLabel
            // 
            this.UserLabel.AutoSize = true;
            this.UserLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.UserLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.UserLabel.Font = new System.Drawing.Font("Maiandra GD", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UserLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.UserLabel.Location = new System.Drawing.Point(118, 9);
            this.UserLabel.Name = "UserLabel";
            this.UserLabel.Size = new System.Drawing.Size(68, 18);
            this.UserLabel.TabIndex = 1;
            this.UserLabel.Text = "USER ID";
            this.UserLabel.Click += new System.EventHandler(this.UserLabel_Click);
            // 
            // FriendList
            // 
            this.FriendList.FormattingEnabled = true;
            this.FriendList.ItemHeight = 16;
            this.FriendList.Location = new System.Drawing.Point(23, 66);
            this.FriendList.Name = "FriendList";
            this.FriendList.Size = new System.Drawing.Size(158, 500);
            this.FriendList.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Olive;
            this.panel3.Controls.Add(this.AlbumLabel);
            this.panel3.Controls.Add(this.ArtistSortLabel);
            this.panel3.Controls.Add(this.TitleLabel);
            this.panel3.Controls.Add(this.vScrollBar2);
            this.panel3.Controls.Add(this.Songlist);
            this.panel3.Location = new System.Drawing.Point(185, 97);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(657, 563);
            this.panel3.TabIndex = 17;
            // 
            // AlbumLabel
            // 
            this.AlbumLabel.AutoSize = true;
            this.AlbumLabel.Font = new System.Drawing.Font("Maiandra GD", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AlbumLabel.Location = new System.Drawing.Point(494, 30);
            this.AlbumLabel.Name = "AlbumLabel";
            this.AlbumLabel.Size = new System.Drawing.Size(72, 20);
            this.AlbumLabel.TabIndex = 13;
            this.AlbumLabel.Text = "ALBUM";
            this.AlbumLabel.Click += new System.EventHandler(this.AlbumLabel_Click);
            // 
            // ArtistSortLabel
            // 
            this.ArtistSortLabel.AutoSize = true;
            this.ArtistSortLabel.Font = new System.Drawing.Font("Maiandra GD", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ArtistSortLabel.Location = new System.Drawing.Point(267, 27);
            this.ArtistSortLabel.Name = "ArtistSortLabel";
            this.ArtistSortLabel.Size = new System.Drawing.Size(69, 20);
            this.ArtistSortLabel.TabIndex = 12;
            this.ArtistSortLabel.Text = "ARTIST";
            this.ArtistSortLabel.Click += new System.EventHandler(this.ArtistSortLabel_Click);
            // 
            // TitleLabel
            // 
            this.TitleLabel.AutoSize = true;
            this.TitleLabel.Font = new System.Drawing.Font("Maiandra GD", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitleLabel.Location = new System.Drawing.Point(59, 27);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(56, 20);
            this.TitleLabel.TabIndex = 11;
            this.TitleLabel.Text = "TITLE";
            this.TitleLabel.Click += new System.EventHandler(this.TitleLabel_Click);
            // 
            // vScrollBar2
            // 
            this.vScrollBar2.Location = new System.Drawing.Point(597, 60);
            this.vScrollBar2.Name = "vScrollBar2";
            this.vScrollBar2.Size = new System.Drawing.Size(21, 432);
            this.vScrollBar2.TabIndex = 1;
            // 
            // Songlist
            // 
            this.Songlist.BackColor = System.Drawing.Color.DimGray;
            this.Songlist.FormattingEnabled = true;
            this.Songlist.ItemHeight = 16;
            this.Songlist.Location = new System.Drawing.Point(20, 58);
            this.Songlist.Name = "Songlist";
            this.Songlist.Size = new System.Drawing.Size(606, 436);
            this.Songlist.TabIndex = 0;
            this.Songlist.SelectedIndexChanged += new System.EventHandler(this.Songlist_SelectedIndexChanged);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Gray;
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel5.Controls.Add(this.trackBar1);
            this.panel5.Controls.Add(this.ArtistLabel);
            this.panel5.Controls.Add(this.label6);
            this.panel5.Controls.Add(this.NowPlaying);
            this.panel5.Controls.Add(this.pictureBox1);
            this.panel5.Controls.Add(this.progressBar1);
            this.panel5.Controls.Add(this.Equalizer);
            this.panel5.Controls.Add(this.Play);
            this.panel5.Location = new System.Drawing.Point(0, 660);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1036, 143);
            this.panel5.TabIndex = 1;
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(824, 85);
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(104, 56);
            this.trackBar1.TabIndex = 14;
            // 
            // ArtistLabel
            // 
            this.ArtistLabel.AutoSize = true;
            this.ArtistLabel.Font = new System.Drawing.Font("Maiandra GD", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ArtistLabel.ForeColor = System.Drawing.Color.GhostWhite;
            this.ArtistLabel.Location = new System.Drawing.Point(113, 81);
            this.ArtistLabel.Name = "ArtistLabel";
            this.ArtistLabel.Size = new System.Drawing.Size(52, 16);
            this.ArtistLabel.TabIndex = 6;
            this.ArtistLabel.Text = "ARTIST";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Maiandra GD", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.GhostWhite;
            this.label6.Location = new System.Drawing.Point(113, 55);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(91, 16);
            this.label6.TabIndex = 5;
            this.label6.Text = "SONG NAME";
            // 
            // NowPlaying
            // 
            this.NowPlaying.AutoSize = true;
            this.NowPlaying.Font = new System.Drawing.Font("Maiandra GD", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NowPlaying.ForeColor = System.Drawing.Color.GhostWhite;
            this.NowPlaying.Location = new System.Drawing.Point(113, 34);
            this.NowPlaying.Name = "NowPlaying";
            this.NowPlaying.Size = new System.Drawing.Size(122, 16);
            this.NowPlaying.TabIndex = 4;
            this.NowPlaying.Text = "NOW PLAYING:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(7, 24);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 98);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // progressBar1
            // 
            this.progressBar1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.progressBar1.Location = new System.Drawing.Point(203, 94);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(606, 15);
            this.progressBar1.TabIndex = 2;
            // 
            // Equalizer
            // 
            this.Equalizer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.Equalizer.Font = new System.Drawing.Font("Maiandra GD", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Equalizer.ForeColor = System.Drawing.Color.GhostWhite;
            this.Equalizer.Location = new System.Drawing.Point(934, 108);
            this.Equalizer.Name = "Equalizer";
            this.Equalizer.Size = new System.Drawing.Size(94, 27);
            this.Equalizer.TabIndex = 1;
            this.Equalizer.Text = "Equalizer";
            this.Equalizer.UseVisualStyleBackColor = false;
            this.Equalizer.Click += new System.EventHandler(this.Equalizer_Click);
            // 
            // Play
            // 
            this.Play.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.Play.Font = new System.Drawing.Font("Maiandra GD", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Play.ForeColor = System.Drawing.Color.GhostWhite;
            this.Play.Location = new System.Drawing.Point(474, 44);
            this.Play.Name = "Play";
            this.Play.Size = new System.Drawing.Size(75, 27);
            this.Play.TabIndex = 0;
            this.Play.Text = "Play";
            this.Play.UseVisualStyleBackColor = false;
            this.Play.Click += new System.EventHandler(this.Play_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1037, 803);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "odysseyClient";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListBox NotificationList;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.ListBox FriendList;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ListBox Songlist;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.TextBox Search;
        private System.Windows.Forms.Button SearchButton;
        private System.Windows.Forms.Button Equalizer;
        private System.Windows.Forms.Button Play;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.VScrollBar vScrollBar2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label UserLabel;
        private System.Windows.Forms.Label NotiLabel;
        private System.Windows.Forms.Label SongLabel;
        private System.Windows.Forms.Label LoggedLabel;
        private System.Windows.Forms.Label NowPlaying;
        private System.Windows.Forms.Label ArtistLabel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label TitleLabel;
        private System.Windows.Forms.Label AlbumLabel;
        private System.Windows.Forms.Label ArtistSortLabel;
        private System.Windows.Forms.TrackBar trackBar1;
    }
}

