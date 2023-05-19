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
    public partial class Dialog : Form
    {
        string connectionString = "Data Source=SHAMIM\\SQLEXPRESS;Initial Catalog=C#Project;Integrated Security=True";
        public string USER_name;
        public Dialog(string USER_name)
        {
            InitializeComponent();
            this.USER_name = USER_name;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string providerUsername = t1.Text;
            DateTime appointmentDate = DateTime.Now;

            string bookedByUsername = USER_name;

            // check for duplicate request
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT COUNT(*) FROM Appointment_Table WHERE who_will_provide=@pUserName and who_booked = @puuserName";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@pUserName", providerUsername);
                    command.Parameters.AddWithValue("@puuserName", USER_name);
                    connection.Open();
                    int existingCount = (int)command.ExecuteScalar();
                    if (existingCount > 0)
                    {
                        MessageBox.Show("Duplicate request");
                        return;
                    }
                }
            }

            //store
            using (SqlConnection connection = new SqlConnection(connectionString))
            {                
                int appointmentCount = 1;
                connection.Open();

                // Insert the new appointment into the table
                SqlCommand insertCommand = new SqlCommand("INSERT INTO Appointment_Table (count, date, who_booked, who_will_provide, notes, payment_status) VALUES (@count, @date, @whoBooked, @whoWillProvide, @notes, @paymentStatus)", connection);
                insertCommand.Parameters.AddWithValue("@count", appointmentCount);
                insertCommand.Parameters.AddWithValue("@date", appointmentDate);
                insertCommand.Parameters.AddWithValue("@whoBooked", bookedByUsername);
                insertCommand.Parameters.AddWithValue("@whoWillProvide", providerUsername);
                insertCommand.Parameters.AddWithValue("@notes", "");
                insertCommand.Parameters.AddWithValue("@paymentStatus", 0);
                insertCommand.ExecuteNonQuery();
            }

            MessageBox.Show("Booking confirmed!");
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
