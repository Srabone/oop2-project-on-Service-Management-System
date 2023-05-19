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
    public partial class PROVIDERSIGNUP : Form
    {
        public PROVIDERSIGNUP()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            new LOGIN_SIGNUP().Show();
            this.Close(); 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string PfirstName = Pfnametxt.Text;
            string PlastName = Plnametxt.Text;
            string PuserName = Pusertxt.Text;
            string Ppassword = Ppasstxt.Text;
            string PcontactNo = Pcontacttxt.Text;
            string Pgender = Pgendercb.Text;
            string Pemail = Pemailtxt.Text;
            string Pcategory = PCategorytxt.Text;
            string Paddress = Paddresstxt.Text;

            string query = "INSERT INTO PROVIDER_TABLE (PfirstName, PlastName, PuserName, Ppassword, PcontactNo, Pgender, Pemail, Pcategory, Paddress) " +
                           "VALUES (@p1, @p2, @p3, @p4, @p5, @p6, @p7, @p8, @p9)";

            string connectionString = "Data Source=ZADUMAN\\SQLEXPRESS;Initial Catalog=\"4 tables\";Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@p1", PfirstName);
                command.Parameters.AddWithValue("@p2", PlastName);
                command.Parameters.AddWithValue("@p3", PuserName);
                command.Parameters.AddWithValue("@p4", Ppassword);
                command.Parameters.AddWithValue("@p5", PcontactNo);
                command.Parameters.AddWithValue("@p6", Pgender);
                command.Parameters.AddWithValue("@p7", Pemail);
                command.Parameters.AddWithValue("@p8", Pcategory);
                command.Parameters.AddWithValue("@p9", Paddress);

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

        private void PROVIDERSIGNUP_Load(object sender, EventArgs e)
        {

        }
    }
}
