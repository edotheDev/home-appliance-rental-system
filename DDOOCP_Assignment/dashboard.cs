using DDOOCP_Assignment.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.Odbc;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DDOOCP_Assignment
{
    public partial class dashboard : Form
    {
        private DatabaseConnection db;
        private Administrator admin;
        private List<Appliance> appliances;
        

        public dashboard()
        {
            InitializeComponent();
            db = new DatabaseConnection();
            admin = new Administrator();
            appliances = new List<Appliance>();
            RefreshAppliances();
        }
        private void RefreshAppliances()
        {
            dgvApplianceAdmin.Rows.Clear();
            dgvApplianceAdmin.Columns.Clear();

            // Get all appliances from the database
            appliances = db.GetAllAppliances();

            // Add columns to the data grid view
            dgvApplianceAdmin.Columns.Add("Column1", "Appliance ID");
            dgvApplianceAdmin.Columns.Add("Column2", "Model");
            dgvApplianceAdmin.Columns.Add("Column3", "Type");
            dgvApplianceAdmin.Columns.Add("Column4", "Energy Consumption");
            dgvApplianceAdmin.Columns.Add("Column5", "Monthly Cost");
            dgvApplianceAdmin.Columns.Add("Column6", "Dimension");
            dgvApplianceAdmin.Columns.Add("Column7", "Color");
            foreach (Appliance appliance in appliances)
            {
                dgvApplianceAdmin.Rows.Add(appliance.Id, appliance.Model, appliance.Type, appliance.EnergyConsumption, appliance.MonthlyCost, appliance.Dimension, appliance.Color);
            }
        }
        private void dashboard_Load(object sender, EventArgs e)
        {
            dgvApplianceAdmin.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to save changes?", "Save Changes", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                foreach (DataGridViewRow row in dgvApplianceAdmin.Rows)
                {
                    int id = Convert.ToInt32(row.Cells["Column1"].Value);
                    Appliance appliance = appliances.Find(a => a.Id == id);

                    if (appliance != null)
                    {
                        // update the Appliance object with the new values from the DataGridView
                        appliance.Model = row.Cells["Column2"].Value?.ToString() ?? "";
                        appliance.Type = row.Cells["Column3"].Value?.ToString() ?? "";

                        double energyConsumption;
                        if (double.TryParse(row.Cells["Column4"].Value?.ToString(), out energyConsumption))
                        {
                            appliance.EnergyConsumption = energyConsumption;
                        }

                        double MonthlyCost;
                        if (double.TryParse(row.Cells["Column5"].Value?.ToString(), out MonthlyCost))
                        {
                            appliance.MonthlyCost = MonthlyCost;
                        }

                        appliance.Dimension = row.Cells["Column6"].Value?.ToString() ?? "";
                        appliance.Color = row.Cells["Column7"].Value?.ToString() ?? "";
                        // update the database with the changes
                        admin.EditAppliance(appliance);
                    }
                }
                RefreshAppliances();
                MessageBox.Show("Changes saved successfully.", "Save Changes", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Check if a row is selected in the data grid view
            if (dgvApplianceAdmin.SelectedRows.Count > 0)
            {
                // Get the ID of the selected appliance
                int selectedId = Convert.ToInt32(dgvApplianceAdmin.SelectedRows[0].Cells["Column1"].Value);

                // Display a message box to confirm the deletion
                DialogResult result = MessageBox.Show("Are you sure you want to delete this appliance?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // Delete the appliance from the database
                    admin.DeleteAppliance(selectedId);

                    // Refresh the data grid view
                    RefreshAppliances();
                }
            }
            else
            {
                MessageBox.Show("Please select an appliance to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            var model = txtModel.Text;
            var type = txtType.Text;
            var dim = txtDim.Text;
            var color = txtColor.Text;  
            double ec, mc;

            if (string.IsNullOrWhiteSpace(txtModel.Text) || string.IsNullOrWhiteSpace(txtType.Text) || string.IsNullOrWhiteSpace(txtEC.Text) || string.IsNullOrWhiteSpace(txtWC.Text) || string.IsNullOrWhiteSpace(txtDim.Text) || string.IsNullOrWhiteSpace(txtColor.Text))
            {
                MessageBox.Show("All fields are required.");
                return;
            }

            if (!double.TryParse(txtEC.Text, out ec))
            {
                MessageBox.Show("Please enter a valid energy consumption value.");
                return;
            }

            if (!double.TryParse(txtWC.Text, out mc))
            {
                MessageBox.Show("Please enter a valid weekly cost value.");
                return;
            }

            var newAppliance = new Appliance(model, type, ec, mc, dim, color);
            admin.AddAppliance(newAppliance);
            RefreshAppliances();
            MessageBox.Show("Appliance added successfully.");

            txtModel.Text = "";
            txtType.Text = "";
            txtEC.Text = "";
            txtWC.Text = "";
            txtDim.Text = "";
            txtColor.Text = "";

        }
        
        private void button3_Click(object sender, EventArgs e)
        {
            Form login = new login();
            login.Show();
            this.Hide();
        }
    }
}
