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
    public partial class PROVIDER_PANEL : Form
    {
        public string gettedP;
        public string connectionString = "Data Source=ZADUMAN\\SQLEXPRESS;Initial Catalog=\"4 tables\";Integrated Security=True";
        public PROVIDER_PANEL(string gettedP)
        {
            InitializeComponent();
            this.gettedP = gettedP;
        }

        private void PROVIDER_PANEL_Load(object sender, EventArgs e)
        {
            label3.Text = gettedP;
        }

        private void MyProfile_Click(object sender, EventArgs e)
        {
            PROVIDER_PROFILE_DIALOG loadF= new PROVIDER_PROFILE_DIALOG();
            loadF.profileShowP(gettedP);
            loadF.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Change_Provider_Pass cchh = new Change_Provider_Pass(gettedP);
            cchh.ShowDialog();
        }

        private void gghh_Click(object sender, EventArgs e)
        {
            new LOGIN().Show();
            this.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string query = "SELECT * FROM Appointment_Table WHERE who_will_provide = @gettedP";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@gettedP", gettedP);
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable datatable = new DataTable();
                    adapter.Fill(datatable);
                    dataGridView1.DataSource = datatable;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

                string query = "UPDATE Appointment_Table SET work_status = 1 WHERE who_will_provide = @gettedP";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@gettedP", gettedP);
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }

                dataGridView1.Rows.Remove(selectedRow);
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
