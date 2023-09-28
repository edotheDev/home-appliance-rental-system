using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDOOCP_Assignment.Class
{
    public class Cart
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Model { get; set; }
        public int Quantity { get; set; }
        public int Duration { get; set; }
        public double MonthlyCost { get; set; }
        public double Total { get; set; }


        public Cart (int id, string type, string model, int quantity, int duration, double monthlyCost, double total)
        {
            Id = id;
            Type = type;
            Model = model;
            Quantity = quantity;
            Duration = duration;
            MonthlyCost = monthlyCost;
            Total = total;
        }

        public Cart(double total)
        {
            Total = total;
        }
    }
}
