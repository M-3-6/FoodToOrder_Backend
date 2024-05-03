using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FoodToOrder_Backend.Models
{
    public class Restaurant
    {

        // [JsonPropertyName("id")]
        public int id { get; set; }
        public string rName { get; set; }

        public int user_id { get; set; }
        public bool isOpen { get; set; }
        public ICollection<Dish>? dishes { get; set; }

        public ICollection<Address>? arrAddresses { get; set; }
    }
}