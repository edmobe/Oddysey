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

        public Form3(Form1 form)
        {
            form1 = form;
            InitializeComponent();
        }

        //Log in Button
        private void button1_Click(object sender, EventArgs e)
        {
            String user = LogUsername.Text;
            String passw = LogPassword.Text;
            //Validation process with the given data. Checks if the spaces are filled and if the user exists.


            if (string.IsNullOrEmpty(user) && string.IsNullOrEmpty(passw))
            {
                var result = MessageBox.Show("Please enter your username\r\nPlease enter your password");// message to ask to fill in the blanks
            }
            else if (string.IsNullOrEmpty(user) || string.IsNullOrEmpty(passw))
            {
                var result = MessageBox.Show("Please Fill in the blanks");
            }


            //Once Validated||
            else
            {
                form1.ChangeLabel(user);
                this.Close();
                form1.Logd = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            String name = RegName.Text;
            String lastname = RegLastName.Text;
            String username = RegUsername.Text;
            String password = RePassword.Text;
            String favorites = RegFavGen.Text;
            String age = textBox1.Text;
            String friends = RegFriends.Text;
            String ans = "Please fill in the following spaces: ";
            int auxi = 0;
            //Auxiliary arrays to check which Spaces are empty
            String[] form = { name, lastname, username, password, favorites, age, friends, age };
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


            //Complete the registration.
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }
    }
}
