using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace PROJECT
{
    public partial class USER_PANEL : Form
    {
        public string USER_name;
        public USER_PANEL(string username)
        {
            InitializeComponent();
            this.USER_name = username;
        }
        string connectionString = "Data Source=ZADUMAN\\SQLEXPRESS;Initial Catalog=\"4 tables\";Integrated Security=True";
        private void button7_Click(object sender, EventArgs e)
        {
            if (PCategorytxt.SelectedItem == null)
            {
                MessageBox.Show("Select the category first!");
            }

            else
            {
                string s = PCategorytxt.SelectedItem.ToString();

                if (s == "Plumber")
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {

                        string query = "SELECT PfirstName, PlastName, PcontactNo, PuserName, Pgender, Pemail, Pcategory, Paddress FROM PROVIDER_TABLE WHERE Pcategory= 'Plumber'";
                        SqlCommand command = new SqlCommand(query, connection);
                        try
                        {
                            connection.Open();
                            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                            DataTable dataTable = new DataTable();
                            dataAdapter.Fill(dataTable);
                            dataGridView1.DataSource = dataTable;
                        }
                        catch (SqlException ex)
                        {
                            MessageBox.Show("Error: " + ex.Message);
                        }
                    }
                }
                else if (s == "Electrician")
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {

                        string query = "SELECT PfirstName, PlastName, PcontactNo, PuserName, Pgender, Pemail, Pcategory, Paddress FROM PROVIDER_TABLE WHERE Pcategory= 'Electrician'";
                        SqlCommand command = new SqlCommand(query, connection);
                        try
                        {
                            connection.Open();
                            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                            DataTable dataTable = new DataTable();
                            dataAdapter.Fill(dataTable);
                            dataGridView1.DataSource = dataTable;
                        }
                        catch (SqlException ex)
                        {
                            MessageBox.Show("Error: " + ex.Message);
                        }
                    }
                }

                else if (s == "Repair Technician")
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {

                        string query = "SELECT PfirstName, PlastName, PcontactNo, PuserName, Pgender, Pemail, Pcategory, Paddress FROM PROVIDER_TABLE WHERE Pcategory= 'Repair Technician'";
                        SqlCommand command = new SqlCommand(query, connection);
                        try
                        {
                            connection.Open();
                            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                            DataTable dataTable = new DataTable();
                            dataAdapter.Fill(dataTable);
                            dataGridView1.DataSource = dataTable;
                        }
                        catch (SqlException ex)
                        {
                            MessageBox.Show("Error: " + ex.Message);
                        }
                    }
                }
                else if (s == "Painter")
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {

                        string query = "SELECT PfirstName, PlastName, PcontactNo, PuserName, Pgender, Pemail, Pcategory, Paddress FROM PROVIDER_TABLE WHERE Pcategory= 'Painter'";
                        SqlCommand command = new SqlCommand(query, connection);
                        try
                        {
                            connection.Open();
                            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                            DataTable dataTable = new DataTable();
                            dataAdapter.Fill(dataTable);
                            dataGridView1.DataSource = dataTable;
                        }
                        catch (SqlException ex)
                        {
                            MessageBox.Show("Error: " + ex.Message);
                        }
                    }
                }

                else if (s == "House Cleaner")
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {

                        string query = "SELECT PfirstName, PlastName, PcontactNo, PuserName, Pgender, Pemail, Pcategory, Paddress FROM PROVIDER_TABLE WHERE Pcategory= 'House Cleaner'";
                        SqlCommand command = new SqlCommand(query, connection);
                        try
                        {
                            connection.Open();
                            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                            DataTable dataTable = new DataTable();
                            dataAdapter.Fill(dataTable);
                            dataGridView1.DataSource = dataTable;
                        }
                        catch (SqlException ex)
                        {
                            MessageBox.Show("Error: " + ex.Message);
                        }
                    }
                }
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Get the selected row
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

                // Get the value in the user_name column of the selected row
                string firstName = selectedRow.Cells["PfirstName"].Value.ToString();
                string lastName = selectedRow.Cells["PlastName"].Value.ToString();
                string category = selectedRow.Cells["Pcategory"].Value.ToString();
                string pusername = selectedRow.Cells["PuserName"].Value.ToString();
                decimal hourlyRate = 0;
                
                switch (category)
                {
                    case "Electrician":
                        hourlyRate = 100m;
                        break;
                    case "Plumber":
                        hourlyRate = 80m;
                        break;
                    case "House Cleaner":
                        hourlyRate = 90m;
                        break;
                    case "Painter":
                        hourlyRate = 150m;
                        break;
                    case "Repair Technician":
                        hourlyRate = 100m;
                        break;
                }

                Dialog InfoForm = new Dialog(USER_name);

                // Set the values of the textboxes and labels in the WorkerInfoForm form
                InfoForm.fname.Text = firstName;
                InfoForm.lname.Text = lastName;
                InfoForm.category.Text = category;
                InfoForm.date.Text = DateTime.Now.ToString("dd/MM/yyyy");
                InfoForm.rate.Text = hourlyRate.ToString();
                InfoForm.user_rating.Text = "0";
                InfoForm.t1.Text = pusername;

                // Display the WorkerInfoForm form as a dialog
                InfoForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please select a row first to Appoint..");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            new LOGIN().Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            USER_PROFILE_DIALOG profileDialog = new USER_PROFILE_DIALOG();
            profileDialog.LoadUserProfile(USER_name);
            profileDialog.ShowDialog();
        }

        private void USER_PANEL_Load(object sender, EventArgs e)
        {
            label3.Text = USER_name;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Change_Pass_User changePassForm = new Change_Pass_User(USER_name);
            changePassForm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string sqlQuery = "SELECT * FROM Appointment_Table WHERE who_booked = @UserName";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(sqlQuery, connection);
                cmd.Parameters.AddWithValue("@UserName", USER_name);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                string who_booked = dataGridView1.SelectedRows[0].Cells["who_booked"].Value.ToString();
                string who_will_provide = dataGridView1.SelectedRows[0].Cells["who_will_provide"].Value.ToString();
              
                Payment_Entry paymentForm = new Payment_Entry(who_booked, who_will_provide);
                paymentForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please select a row from the appointments list first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
