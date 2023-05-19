using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace PROJECT
{
    
    public partial class Change_Pass_User : Form
    {
        string connectionString = "Data Source=SHAMIM\\SQLEXPRESS;Initial Catalog=C#Project;Integrated Security=True";
        public string userName;
        public Change_Pass_User(string userName)
        {
            InitializeComponent();
            this.userName = userName;
        }

        public void button7_Click(object sender, EventArgs e)
        {
            string oldPassword = opf.Text;
            string newPassword = npf.Text;
            string userName = this.userName; //USER_name is a property in the USER_PANEL form

            if (string.IsNullOrEmpty(oldPassword) || string.IsNullOrEmpty(newPassword))
            {
                MessageBox.Show("Please enter both the old and new passwords.");
                return;
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string checkPasswordQuery = "SELECT password FROM USER_TABLE WHERE user_name=@username AND password=@password";
                SqlCommand checkPasswordCommand = new SqlCommand(checkPasswordQuery, connection);
                checkPasswordCommand.Parameters.AddWithValue("@username", userName);
                checkPasswordCommand.Parameters.AddWithValue("@password", oldPassword);
                SqlDataReader reader = checkPasswordCommand.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Close();

                    // Update the password
                    string updatePasswordQuery = "UPDATE USER_TABLE SET password=@newPassword WHERE user_name=@username";
                    SqlCommand command = new SqlCommand(updatePasswordQuery, connection);
                    command.Parameters.AddWithValue("@newPassword", newPassword);
                    command.Parameters.AddWithValue("@username", userName);
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Password has been changed successfully.");
                    }
                    else
                    {
                        MessageBox.Show("Error: Password could not be changed.");
                    }
                }
                else
                {
                    reader.Close();
                    MessageBox.Show("Error: Old password is incorrect.");
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Change_Pass_User_Load(object sender, EventArgs e)
        {

        }
    }
}
