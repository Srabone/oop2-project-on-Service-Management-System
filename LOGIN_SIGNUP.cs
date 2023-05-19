using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PROJECT
{
    public partial class LOGIN_SIGNUP : Form
    {
        public LOGIN_SIGNUP()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new LOGIN().Show();
            this.Hide();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            DialogResult dr1 = MessageBox.Show("Do you really want to close the Application?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr1 == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (rolecb.SelectedItem == null)
            {
                MessageBox.Show("Select the role first!");
            }

            else
            {
                string s = rolecb.SelectedItem.ToString();
                if (s == "Service Provider")
                {
                    new PROVIDERSIGNUP().Show();
                    this.Hide();
                }
                else if (s == "Customer")
                {
                    new USER_SIGNUP().Show();
                    this.Hide();
                }

            }
        }
    }
}
