using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Employee_Managment_System
{
    public partial class View : Form
    {
        public View()
        {
            InitializeComponent();
        }
        readonly SqlConnection con = new SqlConnection(connectionString: @"Data Source=CASH;Initial Catalog=EmployeeDatabase;Integrated Security=True");
        private void Fetchemp()
        {
            try
            {
                con.Open();
                string query = "select * from ETBL WHERE EmpId = '" + textBox1.Text + "'";
                SqlCommand cmd = new SqlCommand(query, con);
                DataTable dt = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    label15.Text = dr["EmpId"].ToString();
                    label16.Text = dr["EmpName"].ToString();
                    label14.Text = dr["EmpGen"].ToString();
                    label13.Text = dr["EmpAdd"].ToString();
                    label12.Text = dr["EmpPos"].ToString();
                    label11.Text = dr["EmpDob"].ToString();
                    label10.Text = dr["EmpPhone"].ToString();


                    label15.Visible = true;
                    label16.Visible = true;
                    label14.Visible = true;
                    label13.Visible = true;
                    label12.Visible = true;
                    label11.Visible = true;
                    label10.Visible = true;
                }
                con.Close();
            }
            catch(Exception ex)
            {

            }
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void ExitBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            Fetchemp();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Home h = new Home();
            h.Show();
            this.Hide();
        }
    }
}
