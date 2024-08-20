using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace Employee_Managment_System
{
    public partial class Employee : Form
    {
        public Employee()
        {
            InitializeComponent();
            DisplayEmp();
        }
        readonly SqlConnection con = new SqlConnection(connectionString: @"Data Source = CASH\MSSQLSERVER01; Initial Catalog = EmployeeDatabase; Integrated Security = True ");

        private void DisplayEmp()
        {
            try
            {
                con.Open();
                string Query = "select * from ETBL";
                SqlDataAdapter sda = new SqlDataAdapter(Query, con);
                SqlCommandBuilder builder = new SqlCommandBuilder(sda); 
                var ds = new DataSet();
                sda.Fill(ds);
                dataGridView1.DataSource= ds.Tables[0];
                con.Close();
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void ExitBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void HomeBtn_Click(object sender, EventArgs e)
        {
            Home h = new Home();
            h.Show();
            this.Hide();
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(textBox1.Text) ||
                    string.IsNullOrWhiteSpace(textBox2.Text) ||
                    string.IsNullOrWhiteSpace(textBox3.Text) ||
                    string.IsNullOrWhiteSpace(textBox4.Text))
                {
                    MessageBox.Show("Missing Information");
                    return;
                }

                if (comboBox1 == null || comboBox2 == null || comboBox4 == null)
                {
                    MessageBox.Show("One or more combo boxes are not initialized.");
                    return;
                }

                string selectedGender = comboBox2.SelectedItem != null ? comboBox2.SelectedItem.ToString() : string.Empty;
                string selectedEducation = comboBox4.SelectedItem != null ? comboBox4.SelectedItem.ToString() : string.Empty;
                string selectedSomething = comboBox1.SelectedItem != null ? comboBox1.SelectedItem.ToString() : string.Empty;

                if (string.IsNullOrWhiteSpace(selectedGender) ||
                    string.IsNullOrWhiteSpace(selectedEducation) ||
                    string.IsNullOrWhiteSpace(selectedSomething))
                {
                    MessageBox.Show("Please select all required fields from dropdowns.");
                    return;
                }

                con.Open();
                string query = "INSERT INTO ETBL (EmpId, EmpName, EmpAdd, EmpGen, EmpDob, EmpPhone, EmpEdu) VALUES (@EmpId, @EmpName, @EmpAdd, @EmpGen, @EmpDob, @EmpPhone, @EmpEdu)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@EmpId", textBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@EmpName", textBox2.Text.Trim());
                cmd.Parameters.AddWithValue("@EmpAdd", textBox3.Text.Trim());
                cmd.Parameters.AddWithValue("@EmpGen", selectedGender);
                cmd.Parameters.AddWithValue("@EmpDob", dateTimePicker1.Value.Date);
                cmd.Parameters.AddWithValue("@EmpPhone", textBox4.Text.Trim());
                cmd.Parameters.AddWithValue("@EmpEdu", selectedEducation);

                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Record Entered Successfully");
                DisplayEmp();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }


        private void Employee_Load(object sender, EventArgs e)
        {
            DisplayEmp();
        }

        private void DelBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if(textBox1.Text == " ")
                {
                    MessageBox.Show("Enter the Employee ID");
                }
                else
                {
                    con.Open();
                    string query = "delete from ETBL WHERE EmpId = '" + textBox1.Text + "';";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Record Deleted Successfully");
                    DisplayEmp();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void ResetBtn_Click(object sender, EventArgs e)
        {
            textBox1.Text = " ";
            textBox2.Text = " ";
            comboBox1.Text = " ";
            textBox3.Text = " ";
            comboBox2.Text = " ";
            textBox4.Text = " ";
            comboBox4.Text = " ";
        }

        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                string query = "delete from ETBL WHERE EmpId = '" + textBox1.Text + "',EmpName = '" + textBox2.Text + "', EmpAdd = '" + textBox3.Text + "', '" + comboBox2.SelectedItem.ToString() + "' , EmpDob ='" + dateTimePicker1.Value.Date + "', EmpPhone = '" + textBox4.Text + "', EmpGen= '" + comboBox1.SelectedItem.ToString() + "', EmpEdu= '" + comboBox4.SelectedItem.ToString() + "' ";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Record Deleted Successfully");
                DisplayEmp();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close() ;
            }
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            comboBox2.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            textBox4.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            comboBox1.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
            comboBox4.Text = dataGridView1.SelectedRows[0].Cells[7].Value.ToString();
        }
    }
}
