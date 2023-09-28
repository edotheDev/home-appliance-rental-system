using DDOOCP_Assignment.Class;
using MySqlX.XDevAPI;
using MySqlX.XDevAPI.Relational;
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
    public partial class home : Form
    {
        private DatabaseConnection db;
        private List<Appliance> appliances;

        public home()
        {
            InitializeComponent();
            db = new DatabaseConnection();
            appliances = new List<Appliance>();
        }
       
        private void cbxFilter_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void RefreshAppliances()
        {
            dgvApplianceUser.Rows.Clear();
            dgvApplianceUser.Columns.Clear();

            // Get all appliances from the database
            appliances = db.GetAllAppliances();

            // Add columns to the data grid view
            dgvApplianceUser.Columns.Add("Column1", "Appliance ID");
            dgvApplianceUser.Columns.Add("Column2", "Model");
            dgvApplianceUser.Columns.Add("Column3", "Type");
            dgvApplianceUser.Columns.Add("Column4", "Energy Consumption");
            dgvApplianceUser.Columns.Add("Column5", "Monthly Cost");
            dgvApplianceUser.Columns.Add("Column6", "Dimension");
            dgvApplianceUser.Columns.Add("Column7", "Color");
            foreach (Appliance appliance in appliances)
            {
                dgvApplianceUser.Rows.Add(appliance.Id, appliance.Model, appliance.Type, appliance.EnergyConsumption, appliance.MonthlyCost, appliance.Dimension, appliance.Color);
            }
        }

        private void SearchnSort()
        {
            string searchTerm = cbxType.Text;
            string sortOrder = cbxSort.Text.ToLower();
            dgvApplianceUser.Rows.Clear();
            dgvApplianceUser.Columns.Clear();
            appliances = db.GetAppliancesByType(searchTerm, sortOrder);
            dgvApplianceUser.Columns.Add("Column1", "Appliance ID");
            dgvApplianceUser.Columns.Add("Column2", "Model");
            dgvApplianceUser.Columns.Add("Column3", "Type");
            dgvApplianceUser.Columns.Add("Column4", "Energy Consumption");
            dgvApplianceUser.Columns.Add("Column5", "Monthly Cost");
            dgvApplianceUser.Columns.Add("Column6", "Dimension");
            dgvApplianceUser.Columns.Add("Column7", "Color");
            foreach (Appliance appliance in appliances)
            {
                dgvApplianceUser.Rows.Add(appliance.Id, appliance.Model, appliance.Type, appliance.EnergyConsumption, appliance.MonthlyCost, appliance.Dimension, appliance.Color);
            }
        }
        private void home_Load(object sender, EventArgs e)
        {
            dgvApplianceUser.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            cbxType.SelectedIndex = 0;
            cbxSort.SelectedIndex = 0;
            RefreshAppliances();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SearchnSort();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dgvApplianceUser.SelectedRows.Count > 0)
            {
                // Get the selected appliance data from the DataGridView
                var row = dgvApplianceUser.SelectedRows[0];
                var id = int.Parse(row.Cells["Column1"].Value.ToString());
                var model = row.Cells["Column2"].Value.ToString();
                var type = row.Cells["Column3"].Value.ToString();
                var mc = double.Parse(row.Cells["Column5"].Value.ToString());

                // Get the selected quantity and duration
                int selectedQuantity = 0;
                int selectedDuration = 0;

                if (cbxQuan.SelectedIndex >= 0)
                {
                    selectedQuantity = int.Parse(cbxQuan.SelectedItem.ToString());
                }
                else
                {
                    MessageBox.Show("Please select a quantity.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (cbxDuration.SelectedIndex >= 0)
                {
                    selectedDuration = int.Parse(cbxDuration.SelectedItem.ToString());
                }
                else
                {
                    MessageBox.Show("Minimum duration must be 1 month", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Display a message box to confirm adding the appliance to the cart
                DialogResult result = MessageBox.Show("Are you sure you want to add this appliance?", "Cart", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // Get the current customer's ID from the session
                    int customerId = CustomSession.Instance.CustomerId;
                    // Create a new Appliance object and Customer object
                    var appliance = new Appliance(id, model, type, mc);
                    var customer = new Customer(customerId);

                    // Add the appliance to the cart for the current customer
                    customer.AddCart(appliance, customer, selectedQuantity, selectedDuration);
                    cbxDuration.SelectedIndex = 0;
                    cbxQuan.SelectedIndex = 0;

                }
            }
            else
            {
                MessageBox.Show("Please select an appliance to add to the cart.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form cart = new cart();
            cart.Show();
            this.Hide();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Form login = new login();
            login.Show();
            this.Hide();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnSort_Click(object sender, EventArgs e)
        {
            SearchnSort();
        }
    }
}
