using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDOOCP_Assignment.Class
{
    public class CustomSession
    {
        private static CustomSession instance;
        public int CustomerId { get; set; }

        private CustomSession() { }

        public static CustomSession Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CustomSession();
                }
                return instance;
            }
        }
    }
}
