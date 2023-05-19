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
    public partial class LOGIN : Form
    {
        public LOGIN()
        {
            InitializeComponent();
        }
        string connectionString = "Data Source=ZADUMAN\\SQLEXPRESS;Initial Catalog=\"4 tables\";Integrated Security=True";
        private void pictureBox4_Click(object sender, EventArgs e)
        {
            new LOGIN_SIGNUP().Show();
            this.Hide();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            new LOGIN_SIGNUP().Show();
            this.Close();
        }

        public void button1_Click(object sender, EventArgs e)
        {
            string userName = login_text.Text;
            string password = login_pass.Text;

            if (rolecb2.SelectedItem == null)
            {
                MessageBox.Show("Select the role first!");
            }
            else
            {
                string s = rolecb2.SelectedItem.ToString();
                if (s == "Provider")
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        SqlCommand command = new SqlCommand("SELECT PuserName FROM PROVIDER_TABLE WHERE PuserName=@userName AND Ppassword=@password", connection);
                        command.Parameters.AddWithValue("@userName", userName);
                        command.Parameters.AddWithValue("@password", password);
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.Read())
                        {
                            string username2 = reader.GetString(0);
                            PROVIDER_PANEL newpanel2 = new PROVIDER_PANEL(username2);
                            newpanel2.Show();
                            this.Hide();
                        }
                        else
                        {                            
                            MessageBox.Show("Invalid username or password. Please try again.");
                        }
                    }
                }
                else if (s == "Customer")
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        SqlCommand command = new SqlCommand("SELECT user_name FROM USER_TABLE WHERE user_name=@userName AND password=@password", connection);
                        command.Parameters.AddWithValue("@userName", userName);
                        command.Parameters.AddWithValue("@password", password);
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.Read())
                        {
                            string username = reader.GetString(0);
                            USER_PANEL newpanel = new USER_PANEL(username);
                            newpanel.Show();
                            this.Hide();
                        }
                        else
                        {                            
                            MessageBox.Show("Invalid username or password. Please try again.");
                        }
                    }
                }
                else if (s == "ADMIN")
                {                     
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        SqlCommand command = new SqlCommand("SELECT * FROM ADMIN_CHECK WHERE user_name=@userName AND password=@password", connection);
                        command.Parameters.AddWithValue("@userName", userName);
                        command.Parameters.AddWithValue("@password", password);
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.HasRows)
                        {
                            new ADMIN().Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Invalid username or password. Please try again.");
                        }
                    }
                }
            }
        }

        private void label9_Click(object sender, EventArgs e)
        {
            login_pass.Clear();
            login_text.Clear();
            login_text.Select();
        }

        private void button2_Click(object sender, EventArgs e)
        {
          /*  string role = rolecb2.Text;
            string uname = login_text.Text;
            if(rolecb2.Text!=null && rolecb2.SelectedItem!=null && login_text.Text!="")
            {
                if (role == "Customer")
                {
                    string cs = login_text.Text;

                    Change_Pass_User cpu = new Change_Pass_User(cs);
                    cpu.Show();
                }
                else if (role == "Provider")
                {
                    string pv = login_text.Text;

                    Change_Provider_Pass cpp = new Change_Provider_Pass(pv);
                    cpp.Show();
                }
            }
            else
            {
                MessageBox.Show("Please Fill up Username and Select Role");
            }
            */
        }
    }
}
