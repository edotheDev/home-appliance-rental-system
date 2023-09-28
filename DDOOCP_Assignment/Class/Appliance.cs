using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace DDOOCP_Assignment.Class
{
    public class Appliance
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Model { get; set; }
        public double EnergyConsumption { get; set; }
        public double MonthlyCost { get; set; }
        public string Dimension { get; set; }
        public string Color { get; set; }
        public Appliance()
        {
            // Default constructor with no arguments
        }
        public Appliance(int id, string model, string type, double ec, double mc, string dim, string color)
        {
            Id = id;
            Type = type;
            Model = model;
            EnergyConsumption = ec;
            MonthlyCost = mc;
            Dimension = dim;
            Color = color;
        }
        public Appliance(int id, string model, string type, double mc)
        {
            Id = id;
            Type = type;
            Model = model;
            MonthlyCost = mc;
        }
        public Appliance(string model, string type, double ec, double mc, string dim, string color)
        {
            Type = type;
            Model = model;
            EnergyConsumption = ec;
            MonthlyCost = mc;
            Dimension = dim;
            Color = color;
        }
    }




}
