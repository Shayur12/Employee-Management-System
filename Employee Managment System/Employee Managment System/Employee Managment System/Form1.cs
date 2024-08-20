using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Employee_Managment_System
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void ExitBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ClearBtn_Click(object sender, EventArgs e)
        {
            Admin.Text = " ";
            Password.Text = " ";
        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            if (Admin.Text == " " || Password.Text == " ")
            {
                MessageBox.Show("Missing Information");
            }
            else if (Admin.Text == "Admin" || Password.Text == "Password")
            {
                Home h = new Home();
                h.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Please enter correct Username and Password");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
