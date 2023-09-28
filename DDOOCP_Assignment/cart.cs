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
    public partial class cart : Form
    {
        private DatabaseConnection db;
        List<DDOOCP_Assignment.Class.Cart> items = new List<DDOOCP_Assignment.Class.Cart>();

        public cart()
        {
            InitializeComponent();
            db = new DatabaseConnection();
        }
        private void RefreshCart()
        {
            dvgCart.Rows.Clear();
            dvgCart.Columns.Clear();
            int customerId = CustomSession.Instance.CustomerId;
            items = db.GetCartDataByUserID(customerId);

            // Add columns to the data grid view
            dvgCart.Columns.Add("Column1", "Cart ID");
            dvgCart.Columns.Add("Column2", "Model");
            dvgCart.Columns.Add("Column3", "Type");
            dvgCart.Columns.Add("Column4", "Quantity");
            dvgCart.Columns.Add("Column5", "Duration");
            dvgCart.Columns.Add("Column6", "Monthly Cost");
            dvgCart.Columns.Add("Column7", "Total Cost");

            // Add each appliance to the data grid view as a new row
            double gt = 0;
            foreach (DDOOCP_Assignment.Class.Cart item in items)
            {
                dvgCart.Rows.Add(item.Id, item.Model, item.Type, item.Quantity, item.Duration, item.MonthlyCost, item.Total);
                
                gt += item.Total;
                lblGTotal.Text = gt.ToString();
            }
        }

        private void dgvApplianceAdmin_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Form home = new home();
            home.Show();
            this.Hide();
        }

        private void Cart_Load(object sender, EventArgs e)
        {
            dvgCart.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            
            
            RefreshCart();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Check if a row is selected in the data grid view
            if (dvgCart.SelectedRows.Count > 0)
            {
                // Get the ID of the selected appliance
                int selectedId = Convert.ToInt32(dvgCart.SelectedRows[0].Cells["Column1"].Value);

                // Display a message box to confirm the deletion
                DialogResult result = MessageBox.Show("Are you sure you want to remove this item from cart?", "Confirm Remove", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // Delete the appliance from the database
                    db.DeleteCart(selectedId);

                    // Refresh the data grid view
                   RefreshCart();
                }
            }
            else
            {
                MessageBox.Show("Please select an item to remove from the cart.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            Form login = new login();
            login.Show();
            this.Hide();
        }
    }
}
