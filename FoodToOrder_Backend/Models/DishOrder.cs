using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FoodToOrder_Backend.Models
{
    public class DishOrder
    {
        public int DishId { get; set; }
        public Dish? Dish { get; set; }
        public int OrderId { get; set; }
        public Order? Order { get; set; }
        public int quantity { get; set; }
    }
}
