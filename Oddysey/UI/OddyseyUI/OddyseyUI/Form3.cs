using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OddyseyUI
{
    public partial class Form3 : Form
    {
        private Form1 form1;
        Client client;
        public string name;
        public string lastname;
        public string nickname;
        public string password;
        public string favorites;
        public string age;
        string friends;

        public Form3(Form1 form)
        {
            form1 = form;
            client = new Client();
            InitializeComponent();
        }

        //Log in Button
        private void button1_Click(object sender, EventArgs e)
        {
            nickname = LogUsername.Text;
            password = LogPassword.Text;
            //Validation process with the given data. Checks if the spaces are filled and if the user exists.


            if (string.IsNullOrEmpty(nickname) && string.IsNullOrEmpty(password))
            {
                var result = MessageBox.Show("Please enter your username\r\nPlease enter your password");// message to ask to fill in the blanks
            }
            else if (string.IsNullOrEmpty(nickname) || string.IsNullOrEmpty(password))
            {
                var result = MessageBox.Show("Please Fill in the blanks");
            }


            //Once Validated||
            else
            {
                client.CheckUser(this);
                form1.ChangeLabel(nickname);
                form1.Logd = true;
                this.Close();
                
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            name = RegName.Text;
            lastname = RegLastName.Text;
            nickname = RegUsername.Text;
            password = RePassword.Text;
            favorites = RegFavGen.Text;
            age = textBox1.Text;
            friends = RegFriends.Text;
            String ans = "Please fill in the following spaces: ";
            int auxi = 0;
            //Auxiliary arrays to check which Spaces are empty
            String[] form = { name, lastname, nickname, password, favorites, age, friends, age };
            String[] aux = { "Name", "Last Name", "Username", "Password", "Favorite Genres", "Friends", "Age", "" };


            //Validation process of the username(can not already exist)
            for (int i = 0; i < form.Length; i++)
            {
                if (string.IsNullOrEmpty(form[i]))
                {
                    //var result = MessageBox.Show("Please Fill in the " + aux[i] + " space");
                    if (i < 6)
                    {
                        ans += " " + aux[i] + ",";
                        auxi += 1;
                    }
                    else if (i == 6)
                    {
                        ans += " " + aux[i] + ".";
                    }
                }
            }
            if (auxi > 0)
            {
                var result = MessageBox.Show(ans);
            }
            else
            {
                client.AddUser(this);
            }


            //Complete the registration.
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }
    }
}
