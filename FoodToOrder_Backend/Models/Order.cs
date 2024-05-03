using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace FoodToOrder_Backend.Models
{
    public class Order
    {
        public int id { get; set; }
        public string orderDate { get; set; }
        public float orderAmount { get; set; }
        //public ICollection<Dish> arrDishes { get; set; }
        public User? User { get; set; }
        public int user_id { get; set; }
        public ICollection<DishOrder>? dishOrders { get; set; }
        

    }
}
