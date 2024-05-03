using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodToOrder_Backend.Models
{
    public class Dish
    {

        public int id { get; set; }
        public string dishName { get; set; }

        public float price { get; set; }

        public string img_path { get; set; }


        public bool isAvailable { get; set; }

        public int restaurant_id { get; set; }
        public Restaurant? Restaurant { get; set; }
        public ICollection<DishOrder>? dishOrders { get; set; }

        public ICollection<CartDish>? cartDishes { get; set; }
    }
}
