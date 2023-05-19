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
    public partial class USER_PROFILE_DIALOG : Form
    {
        string connectionString = "Data Source=ZADUMAN\\SQLEXPRESS;Initial Catalog=\"4 tables\";Integrated Security=True";
        public USER_PROFILE_DIALOG()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void LoadUserProfile(string username)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT first_name, last_name, gender, contact_no, email, user_name FROM USER_TABLE WHERE user_name=@username";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@username", username);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        t1.Text = reader["first_name"].ToString();
                        t2.Text = reader["last_name"].ToString();
                        t3.Text = reader["gender"].ToString();
                        t4.Text = reader["contact_no"].ToString();
                        t5.Text = reader["email"].ToString();
                        t6.Text = reader["user_name"].ToString();
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void USER_PROFILE_DIALOG_Load(object sender, EventArgs e)
        {

        }
    }
}
