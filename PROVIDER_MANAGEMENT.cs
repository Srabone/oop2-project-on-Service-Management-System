using PROJECT.Properties;
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

namespace PROJECT
{
    public partial class PROVIDER_MANAGEMENT : Form
    {
        public PROVIDER_MANAGEMENT()
        {
            InitializeComponent();
        }
        string connectionString = "Data Source=ZADUMAN\\SQLEXPRESS;Initial Catalog=\"4 tables\";Integrated Security=True";
        private void pictureBox5_Click(object sender, EventArgs e)
        {
            DialogResult dr1 = MessageBox.Show("Do you really want to close the Application?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr1 == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            new ADMIN().Show();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            new PROVIDER_SIGNUP_2().Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string PuserName = textBox1.Text.Trim();

            string query = "SELECT * FROM PROVIDER_TABLE WHERE PuserName = @UserName";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@UserName", PuserName);

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

        private void button2_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("SELECT * FROM PROVIDER_TABLE", connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable table = new DataTable();
                adapter.Fill(table);
                dataGridView1.DataSource = table;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Get the selected row
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

                // Get the value in the user_name column of the selected row
                string PuserName = selectedRow.Cells["PuserName"].Value.ToString();

                // Confirm with the user before deleting
                DialogResult result = MessageBox.Show($"Are you sure you want to delete user '{PuserName}'?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    // Delete the selected row from the database
                    string query = "DELETE FROM PROVIDER_TABLE WHERE PuserName = @userName";

                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            // Add parameter for the user_name
                            command.Parameters.AddWithValue("@userName", PuserName);

                            // Open the connection
                            connection.Open();

                            // Execute the command
                            command.ExecuteNonQuery();
                        }
                    }

                    // Remove the selected row from the DataGridView
                    dataGridView1.Rows.Remove(selectedRow);
                }
            }
            else
            {
                MessageBox.Show("Please select a row first to DELETE..");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
