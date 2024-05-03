using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodToOrder_Backend.Models
{
    public class User
    {
        public int id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string role { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public Address? address { get; set; }
        public Cart? cart { get; set; }
        public DateTime date_of_birth { get; set; }

        public ICollection<Order> orders { get; set; }

    }
}
