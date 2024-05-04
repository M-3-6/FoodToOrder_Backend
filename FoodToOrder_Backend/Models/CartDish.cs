using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodToOrder_Backend.Models
{
    public class CartDish
    {
        public int? CartId { get; set; }
        public Cart? Cart { get; set; }
        public int DishId { get; set; }
        public Dish? Dish { get; set; }

        public int quantity { get; set; }
    }
}
