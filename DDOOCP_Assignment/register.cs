using DDOOCP_Assignment.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DDOOCP_Assignment
{
    public partial class register : Form
    {
        private readonly DatabaseConnection db;
        public register()
        {
            InitializeComponent();
            db = new DatabaseConnection();
        }

        private void register_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            string conPass = txtConPass.Text;

            if (!IsValidUsername(username))
            {
                MessageBox.Show("Username can only contain letters and numbers.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!IsValidPassword(password))
            {
                MessageBox.Show("Password must be between 8 and 16 characters, and contain at least one lowercase and one uppercase letter.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!PasswordsMatch(password, conPass))
            {
                MessageBox.Show("Password and Confirm Password fields must match.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Customer customer = new Customer(username, password);
            bool isRegistered = db.AddUser(customer);


            if (isRegistered)
            {
                MessageBox.Show("Registration successful!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtUsername.Text = "";
                txtPassword.Text = "";
                txtConPass.Text = "";
            }
            else
            {
                MessageBox.Show("Username already exists. Please choose a different username.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool IsValidUsername(string username)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(username, @"^[a-zA-Z0-9]+$");
        }

        private bool IsValidPassword(string password)
        {
            return (password.Length >= 8 && password.Length <= 16 &&
                    System.Text.RegularExpressions.Regex.IsMatch(password, @"^(?=.*[a-z])(?=.*[A-Z]).+$"));
        }
        private bool PasswordsMatch(string password, string confirmPassword)
        {
            return password.Equals(confirmPassword);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Form login = new login();
            login.Show();
            this.Hide();
        }
    }
}

