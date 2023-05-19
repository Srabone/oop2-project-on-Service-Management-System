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
using System.Xml.Linq;

namespace PROJECT
{
    public partial class USER_2 : Form
    {
        public USER_2()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            new USER_MANAGEMENT().Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string firstName = f_name.Text;
            string lastName = l_name.Text;
            string userName = user_name.Text;
            string password = user_pass.Text;
            string contactNo = user_contact.Text;
            string email = user_email.Text;
            string gender = user_gender.Text;

            string query = "INSERT INTO USER_TABLE (first_name, last_name, contact_no, gender, email, user_name, password) " +
                           "VALUES (@FirstName, @LastName, @ContactNo, @Gender, @Email, @UserName, @Password)";

            string connectionString = "Data Source=ZADUMAN\\SQLEXPRESS;Initial Catalog=\"4 tables\";Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@FirstName", firstName);
                command.Parameters.AddWithValue("@LastName", lastName);
                command.Parameters.AddWithValue("@ContactNo", contactNo);
                command.Parameters.AddWithValue("@Gender", gender);
                command.Parameters.AddWithValue("@Email", email);
                command.Parameters.AddWithValue("@UserName", userName);
                command.Parameters.AddWithValue("@Password", password);

                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    MessageBox.Show(rowsAffected + " Data Added Successfully..!");
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void f_name_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
