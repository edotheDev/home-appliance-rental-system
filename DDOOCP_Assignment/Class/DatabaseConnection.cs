using MySqlX.XDevAPI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace DDOOCP_Assignment.Class
{
    public class DatabaseConnection : IDisposable
    {
        private readonly OleDbConnection connection;

        public DatabaseConnection()
        {
            string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source='|DataDirectory|\ddoocpDB.accdb'";
            connection = new OleDbConnection(connectionString);
        }

        public OleDbConnection Connection
        {
            get { return connection; }
        }
        public void Open()
        {
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }
        }
        public void Dispose()
        {
            if (connection != null && connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }

        public OleDbDataReader ExecuteQuery(string query, Dictionary<string, object> parameters = null)
        {
            OleDbCommand command = new OleDbCommand(query, connection);
            if (parameters != null)
            {
                foreach (KeyValuePair<string, object> parameter in parameters)
                {
                    command.Parameters.AddWithValue(parameter.Key, parameter.Value);
                }
            }

            connection.Open();
            return command.ExecuteReader(CommandBehavior.CloseConnection);
        }

        public int ExecuteNonQuery(string query, Dictionary<string, object> parameters = null)
        {
            OleDbCommand command = new OleDbCommand(query, connection);
            if (parameters != null)
            {
                foreach (KeyValuePair<string, object> parameter in parameters)
                {
                    command.Parameters.AddWithValue(parameter.Key, parameter.Value);
                }
            }

            connection.Open();
            int rowsAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowsAffected;
        }

        public bool AuthenticateUser(string username, string password)
        {
            string query = "SELECT * FROM tblUser WHERE User_Name = ? AND User_password = ?";
            OleDbCommand command = new OleDbCommand(query, connection);
            command.Parameters.AddWithValue("@p1", username);
            command.Parameters.AddWithValue("@p2", password);
            connection.Open();
            OleDbDataReader reader = command.ExecuteReader();
            bool isAuthenticated = false;
            bool isAdmin = false;
            if (reader.Read())
            {
                int customerId = (int)reader["User_ID"];
                CustomSession.Instance.CustomerId = customerId;
                isAuthenticated = true;
                isAdmin = (bool)reader["IsAdmin"];
            }
            connection.Close();

            if (isAuthenticated && isAdmin)
            {
                Form dashboard = new dashboard();
                dashboard.Show();
               
            }
            else if (isAuthenticated)
            {
                Form home = new home();
                home.Show();
            }
            return isAuthenticated;
        }

        public bool AddUser(Customer customer)
        {
            bool isRegistered = false;
            try
            {
                connection.Open();

                // check if username already exists
                string checkQuery = "SELECT COUNT(*) FROM tblUser WHERE User_Name = @Username";
                OleDbCommand checkCommand = new OleDbCommand(checkQuery, connection);
                checkCommand.Parameters.AddWithValue("@Username", customer.Username);

                int count = (int)checkCommand.ExecuteScalar();
                if (count > 0)
                {
                    return isRegistered;
                }

                // insert new user
                else
                {
                    string query = "INSERT INTO tblUser ([User_Name],[User_Password],[IsAdmin])values(@Username,@Password,@Role)";
                    OleDbCommand command = new OleDbCommand(query, connection);
                    command.Parameters.AddWithValue("@Username", customer.Username);
                    command.Parameters.AddWithValue("@Password", customer.Password);
                    command.Parameters.AddWithValue("@Role", false);
                    command.ExecuteNonQuery();
                    isRegistered = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return isRegistered;
        }


        public List<Appliance> GetAllAppliances()
        {
            List<Appliance> appliances = new List<Appliance>();
            string query = "SELECT * FROM tblAppliance";
            using (OleDbCommand command = new OleDbCommand(query, connection))
            {
                connection.Open();
                using (OleDbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int id = Convert.ToInt32(reader["App_ID"]);
                        string model = reader["Model"].ToString();
                        string type = reader["Type"].ToString();
                        double ec = Convert.ToDouble(reader["Energy_Con"]);
                        double mc = Convert.ToDouble(reader["M_Cost"]);
                        string dim = reader["Dimension"].ToString();
                        string color = reader["Color"].ToString();
                        appliances.Add(new Appliance(id, model, type, ec, mc, dim, color));
                    }
                }
                connection.Close();
            }
            return appliances;
        }
        public List<Appliance> GetAppliancesByType(string type, string sortOrder)
        {
            List<Appliance> appliances = new List<Appliance>();
            string query = "SELECT * FROM tblAppliance WHERE Type = @Type ORDER BY ";

            switch (sortOrder)
            {
                case "energy consumption":
                    query += "Energy_Con ASC";
                    break;
                case "monthly cost":
                    query += "M_Cost ASC";
                    break;
                default:
                    query += "Energy_Con ASC";
                    break;
            }

            using (OleDbCommand command = new OleDbCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Type", type);
                connection.Open();
                using (OleDbDataReader reader = command.ExecuteReader())
                {
                    if (!reader.HasRows)
                    {
                        MessageBox.Show("There is no data for the selected type.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        while (reader.Read())
                        {
                            int id = Convert.ToInt32(reader["App_ID"]);
                            string model = reader["Model"].ToString();
                            string typ = reader["Type"].ToString();
                            double ec = Convert.ToDouble(reader["Energy_Con"]);
                            double mc = Convert.ToDouble(reader["M_Cost"]);
                            string dim = reader["Dimension"].ToString();
                            string color = reader["Type"].ToString();
                            appliances.Add(new Appliance(id, model, typ, ec, mc, dim, color));
                        }
                    }
                }
                connection.Close();
            }
            return appliances;
        }

        public List<DDOOCP_Assignment.Class.Cart> GetCartDataByUserID(int id)
        {
            List<Cart> items = new List<Cart>();
            string query = "SELECT * FROM tblCart WHERE User_ID = @Id";

            using (OleDbCommand command = new OleDbCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Id", id);
                connection.Open();
                using (OleDbDataReader reader = command.ExecuteReader())
                {
                    if (!reader.HasRows)
                    {
                        double total = 0;
                        items.Add(new Cart(total));
                        MessageBox.Show("Your cart is empty", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        while (reader.Read())
                        {
                            int cid = Convert.ToInt32(reader["Cart_ID"]);
                            string model = reader["Model"].ToString();
                            string type = reader["Type"].ToString();
                            int quan = Convert.ToInt32(reader["Quantity"]);
                            int dura = Convert.ToInt32(reader["Duration"]);
                            double mc = Convert.ToDouble(reader["Cost_Per_Month"]);
                            double total = quan * dura * mc;
                            items.Add(new Cart(cid, model, type, quan, dura, mc, total));
                        }
                    }
                }
                connection.Close();
            }
            return items;

        }
        public void DeleteCart(int id)
        {
            using (var connection = new DatabaseConnection())
            {
                connection.Open();
                var command = new OleDbCommand("DELETE FROM tblCart WHERE Cart_ID=@Id", connection.Connection);
                command.Parameters.AddWithValue("@Id", id);
                command.ExecuteNonQuery();
            }
        }
    }

}
