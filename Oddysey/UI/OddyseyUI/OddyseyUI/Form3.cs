﻿using System;
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

        private void button1_Click(object sender, EventArgs e)
        {
            String user = LogUsername.Text;
            String passw = LogPassword.Text;
            //Validation process with the given data.

            //Once Validated
            form1.ChangeLabel(user);
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            String name = RegName.Text;
            String lastname = RegLastName.Text;
            String username = RegUsername.Text;
            String password = RePassword.Text;
            String favorites = RegFavGen.Text;
            String friends = RegFriends.Text;
            //Validation process of the username(can not already exist)


            //Complete the registration.
        }
    }
}
