using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodToOrder_Backend.Models
{
    public class Address
    {
        public int id { get; set; }
        public string houseno { get; set; }
        public string street { get; set; }
        public string area { get; set; }
        public string city { get; set; }
        public string country { get; set; }
        public string pincode { get; set; }
        public User? User { get; set; }
        public Restaurant? Restaurant { get; set; }
        public int? user_id { get; set; }
        public int? restaurant_id { get; set; }
    }
}
