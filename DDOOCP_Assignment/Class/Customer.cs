using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DDOOCP_Assignment.Class
{
    public class Customer : User
    {
        public List<Appliance> ShoppingCart { get; set; }

        public Customer(string username, string password)
        {
            Username = username;
            Password = password;
        }
        public Customer(int id)
        {
            Id = id;
        }

        public void AddCart(Appliance appliance, Customer customer, int quan, int duration)
        {
            using (var connection = new DatabaseConnection())
            {
                connection.Open();

                var command = new OleDbCommand("INSERT INTO tblCart (User_ID, App_ID, Model, Type, Quantity, Cost_Per_Month, Duration) VALUES (?, ?, ?, ?, ?, ?, ?)", connection.Connection);

                command.Parameters.AddWithValue("@User_ID", customer.Id);
                command.Parameters.AddWithValue("@App_ID", appliance.Id);
                command.Parameters.AddWithValue("@Model", appliance.Model);
                command.Parameters.AddWithValue("@Type", appliance.Type);
                command.Parameters.AddWithValue("@Quantity", quan);
                command.Parameters.AddWithValue("@Cost_Per_Month", appliance.MonthlyCost);
                command.Parameters.AddWithValue("@Duration", duration);
                command.ExecuteNonQuery();
            }
        }

    }
}
