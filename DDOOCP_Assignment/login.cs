using DDOOCP_Assignment.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace DDOOCP_Assignment
{
    public partial class login : Form
    {
        private readonly DatabaseConnection db;
        private int failedAttempts = 0; // Initialize the failed attempts counter
        private DateTime lastFailedAttempt;
        public login()
        {
            InitializeComponent();
            db = new DatabaseConnection();
        }
   
        private void btnLogin_Click(object sender, EventArgs e)
        {

            string username = txtUsername.Text;
            string password = txtPassword.Text;

            bool isAuthenticated = db.AuthenticateUser(username, password);
            if(string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Username or password is empty.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (isAuthenticated)
            {
                this.Hide();
                failedAttempts = 0;
            }
            else
            {
                failedAttempts++;
                int leftAtt = 5 - failedAttempts; 
                lastFailedAttempt = DateTime.Now;

                if (failedAttempts >= 5)
                {
                    // Disable the login button and start the timer
                    btnLogin.Enabled = false;
                    tmrLogin.Enabled = true;
                    MessageBox.Show("You have exceeded the maximum number of login attempts. Please try again in 1 minute.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                if (leftAtt > 0)
                {
                    MessageBox.Show("Invalid username or password. You have left " + leftAtt.ToString() + " chances to try again.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void login_Load(object sender, EventArgs e)
        {

        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            Form register = new register();
            register.Show();
            this.Hide();
        }

        private void tmrLogin_Tick_1(object sender, EventArgs e)
        {
            // Check if one minute has passed since the last failed attempt
            TimeSpan elapsedTime = DateTime.Now - lastFailedAttempt;
            if (elapsedTime.TotalSeconds >= 60)
            {
                // Reset the failed attempts counter and re-enable the login button
                failedAttempts = 0;
                btnLogin.Enabled = true;
                tmrLogin.Enabled = false;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
