using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DDOOCP_Assignment.Class
{
    public class Administrator : User
    {
        public void AddAppliance(Appliance appliance)
        {
            using (var connection = new DatabaseConnection())
            {
                connection.Open();

                var command = new OleDbCommand("INSERT INTO tblAppliance (Model, Type, Energy_Con, M_Cost, Dimension, Color) VALUES (?, ?, ?, ?, ?, ?)", connection.Connection);

                command.Parameters.AddWithValue("@Model", appliance.Model);
                command.Parameters.AddWithValue("@Type", appliance.Type);
                command.Parameters.AddWithValue("@Energy_Con", appliance.EnergyConsumption);
                command.Parameters.AddWithValue("@M_Cost", appliance.MonthlyCost);
                command.Parameters.AddWithValue("@Dimension", appliance.Dimension);
                command.Parameters.AddWithValue("@Color", appliance.Color);

                command.ExecuteNonQuery();
            }
        }
        public void EditAppliance(Appliance appliance)
        {
            using (var connection = new DatabaseConnection())
            {
                connection.Open();
                var command = new OleDbCommand("UPDATE tblAppliance SET Model = @model, Type = @Type, Energy_Con = @energy, M_Cost = @cost, Dimension = @dim, Color = @color WHERE App_ID = @id", connection.Connection);

                command.Parameters.AddWithValue("@model", appliance.Model);
                command.Parameters.AddWithValue("@type", appliance.Type);
                command.Parameters.AddWithValue("@energy", appliance.EnergyConsumption);
                command.Parameters.AddWithValue("@cost", appliance.MonthlyCost);
                command.Parameters.AddWithValue("@dim", appliance.Dimension);
                command.Parameters.AddWithValue("@color", appliance.Color);
                command.Parameters.AddWithValue("@id", appliance.Id);

                int rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected == 0)
                {
                    throw new Exception("No rows were affected by the update.");
                }
            }
        }

        public void DeleteAppliance(int id)
        {
            using (var connection = new DatabaseConnection())
            {
                connection.Open();
                var command = new OleDbCommand("DELETE FROM tblAppliance WHERE App_ID=@Id", connection.Connection);
                command.Parameters.AddWithValue("@Id", id);
                command.ExecuteNonQuery();
            }
        }

    }
}
