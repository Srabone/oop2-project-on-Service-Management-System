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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace PROJECT
{
    public partial class PROVIDER_PROFILE_DIALOG : Form
    {
        string connectionString = "Data Source=ZADUMAN\\SQLEXPRESS;Initial Catalog=\"4 tables\";Integrated Security=True";
        public PROVIDER_PROFILE_DIALOG()
        {
            InitializeComponent();
        }

        public void profileShowP(string username)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT PfirstName, PlastName, Pgender, PcontactNo, Pemail, Pcategory FROM PROVIDER_TABLE WHERE PuserName =@username";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@username", username);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        t1.Text = reader["PfirstName"].ToString();
                        t2.Text = reader["PlastName"].ToString();
                        t3.Text = reader["Pcategory"].ToString();
                        t4.Text = reader["PcontactNo"].ToString();
                        t5.Text = reader["Pemail"].ToString();
                        t6.Text = reader["Pgender"].ToString();
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PROVIDER_PROFILE_DIALOG_Load(object sender, EventArgs e)
        {

        }
    }
}
