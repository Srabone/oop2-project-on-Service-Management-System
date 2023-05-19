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
    public partial class ADMIN : Form
    {
        string connectionString = "Data Source=ZADUMAN\\SQLEXPRESS;Initial Catalog=\"4 tables\";Integrated Security=True";

        public decimal amountCollected=0;
        public ADMIN()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new PROVIDER_MANAGEMENT().Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new USER_MANAGEMENT().Show();
            this.Hide();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            new LOGIN().Show();
            this.Close();
        }

        private void ADMIN_Load(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM Appointment_Table WHERE count = 1";
                SqlCommand cmd = new SqlCommand(query, connection);
                int count = (int)cmd.ExecuteScalar();
                label4.Text = count.ToString();
                connection.Close();
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT SUM(amount) FROM Appointment_Table";
                SqlCommand cmd = new SqlCommand(query, conn);
                object result = cmd.ExecuteScalar();
                if (result != DBNull.Value)
                {
                    decimal totalAmount = Convert.ToDecimal(result);
                    label5.Text = $"{totalAmount:C}";
                }
                conn.Close();
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT SUM(amount*0.3) FROM Appointment_Table";
                SqlCommand cmd = new SqlCommand(query, conn);
                object result = cmd.ExecuteScalar();
                if (result != DBNull.Value)
                {
                    decimal totalAmount = Convert.ToDecimal(result);
                    label6.Text = $"{totalAmount:C}";
                }
                conn.Close();
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel2.Visible= true;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void buttonEnter_Click(object sender, EventArgs e)
        {
            string uname = textBoxUName.Text;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                //
                string query = $"select who_will_provide,payment_status,work_status,amount,amount_payable from Appointment_Table Where who_will_provide='{uname}'";
                SqlCommand cmd = new SqlCommand(query, conn);
                DataSet ds = new DataSet();
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(ds);
                DataTable dt = ds.Tables[0];
                //string val = dt.Rows[0]["X"].ToString();
                dataGridView1.DataSource = dt;
                dataGridView1.Refresh();


                //
                conn.Close();
            }
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            panel2.Visible= false;
        }

        private void buttonPayment_Click(object sender, EventArgs e)
        {
            string uname = textBoxUName.Text;
            if(textBoxUName.Text!=null &&
                comboBox1.Text!= null &&
                comboBox1.SelectedText!= null) 
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    //
                    string query = $"UPDATE Appointment_Table SET amount_payable = amount * 0.7 WHERE who_will_provide = '{uname}' AND work_status = 1 AND payment_status = 1;";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    DataSet ds = new DataSet();
                    SqlDataAdapter adp = new SqlDataAdapter(cmd);
                    adp.Fill(ds);
                    DataTable dt = ds.Tables[0];
                    //string val = dt.Rows[0]["X"].ToString();
                    dataGridView1.DataSource = dt;
                    dataGridView1.Refresh();


                    //
                    conn.Close();
                }
            }
            else
            {
                MessageBox.Show(" Fill up the information ");
            }
            
        }
    }
}
