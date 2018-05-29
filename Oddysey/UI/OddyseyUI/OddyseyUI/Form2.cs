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
    public partial class Form2 : Form
    {

        public string name;
        public string author;
        public string album;
        public string score;

        public Form2()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox1.Text.Trim() == string.Empty || textBox2.Text.Trim() == string.Empty)
            {
                MessageBox.Show("You must fill all the spaces");
            } else
            {
                name = textBox1.Text;
                author = textBox2.Text;
                Close();
            }


        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }
    }
}
