using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace FoodToOrder_Backend.Models
{
    public class Cart
    {
        public int id {  get; set; }

       
        public float Amount { get; set; }
        public ICollection<CartDish>? cartDishes { get; set; }
        public User? User { get; set; }
        public int user_id { get; set; }
    }
}
