using iTextSharp.text.pdf;
using iTextSharp.text;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PROJECT
{
    public partial class Payment_Entry : Form
    {
        string connectionString = "Data Source=ZADUMAN\\SQLEXPRESS;Initial Catalog=\"4 tables\";Integrated Security=True";
        public string who_booked;
        public string who_will_provide;
        public Payment_Entry(string who_booked, string who_will_provide)
        {
            InitializeComponent();
            this.who_booked = who_booked;
            this.who_will_provide = who_will_provide;

            textBox1.Text = who_booked;
            textBox2.Text = who_will_provide;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void know_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Electrician       - 100/Hourly\n" +
                            "Plumber           - 80/Hourly\n" +
                            "House Cleaner     - 90/Hourly\n" +
                            "Painter           - 150/Hourly\n" +
                            "Repair Technician - 100/Hourly\n");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string userName = textBox1.Text;
            string providerName = textBox2.Text;
            string morc = textBox3.Text;
            string pin = textBox4.Text;
            string ammount = textBox5.Text;

            Document document = new Document(PageSize.A4, 25, 25, 30, 30);
            PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(@"D:\PaySlip.pdf", FileMode.Create));
            document.Open();

            Paragraph paragraph = new Paragraph("Payment Details");
            document.Add(paragraph);
            document.Add(new Chunk("\n"));
            document.Add(new Chunk("User Name: " + userName));
            document.Add(new Chunk("\n"));
            document.Add(new Chunk("Provider Name: " + providerName));
            document.Add(new Chunk("\n"));
            document.Add(new Chunk("Mobile or Card No: " + morc));
            document.Add(new Chunk("\n"));
            document.Add(new Chunk("PIN: " + pin));
            document.Add(new Chunk("\n"));
            document.Add(new Chunk("Amount: " + ammount));

            document.Add(new Paragraph("Thanks for using our System."));

            document.Close();

            /* ------------------*/

            decimal amountPaid = decimal.Parse(textBox5.Text);

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string updateQuery = $"UPDATE Appointment_Table SET payment_status = 1, amount = '{amountPaid}' WHERE who_booked = '{userName}' AND who_will_provide = '{providerName}'";
                SqlCommand cmd = new SqlCommand(updateQuery, conn);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Payment successful, Receipt generated!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
                conn.Close();
            }
        }
    }
}
