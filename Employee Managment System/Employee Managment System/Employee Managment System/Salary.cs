using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Employee_Managment_System
{
    public partial class Salary : Form
    {
        public Salary()
        {
            InitializeComponent();
        }
        readonly SqlConnection con = new SqlConnection(connectionString: @"Data Source=CASH;Initial Catalog=EmployeeDatabase;Integrated Security=True");

        private void Fetchemp()
        {

            try
            {
                if (EId.Text == " ")
                {
                    MessageBox.Show("Enter Employee ID");
                }
                else { }
                con.Open();
                string query = "select * from ETBL WHERE EmpId = '" + EId.Text + "'";
                SqlCommand cmd = new SqlCommand(query, con);
                DataTable dt = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    EN.Text = dr["EmpName"].ToString();
                    EP.Text = dr["EmpId"].ToString();
                   

                }
                con.Close();


            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            } finally 
            { 
                con.Close(); 
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Home h = new Home();
            h.Show();
            this.Hide();
        }

        private void ExitBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        int dbase;
        int total;
        private void button1_Click(object sender, EventArgs e)
        {
            if(EP.Text == " ")
            {
                MessageBox.Show("Select an employee");
            }
            else if (wd.Text == " " || Convert.ToInt32(wd.Text) > 28)
            {
                MessageBox.Show("Enter a valid number of days");
            }
            else
            {
                if(EP.Text == "Manager")
                {
                    dbase = 1200;
                }
                else if (EP.Text == "Senior Developer")
                {
                    dbase = 1000;
                }
                else if (EP.Text == "Junior Developer")
                {
                    dbase = 400;
                }
                else
                {
                    dbase = 300;
                }
                total = dbase * Convert.ToInt32(wd.Text);
                richTextBox1.Text = "Employee Id: " + EId.Text + "\n" + "Employee Name: " + "\n" + "Employee Position: " + EP.Text + "\n" + "Daily Salary: " + dbase + "\n" + "Total Salary: " + total;
            }
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            Fetchemp();
        }

    }
}
