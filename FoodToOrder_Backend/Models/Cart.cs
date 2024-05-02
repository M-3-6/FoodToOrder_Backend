using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace FoodToOrder_Backend.Models
{
    public class Cart
    {
        public int id {  get; set; }
        public int Amount { get; set; }
        public ICollection<CartDish> cartDishes { get; set; }
    }
}
