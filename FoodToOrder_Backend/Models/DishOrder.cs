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
        [JsonPropertyName("dishId")]
        public int DishId { get; set; }
        [JsonPropertyName("dish")]
        public Dish? Dish { get; set; }
        [JsonPropertyName("orderId")]
        public int OrderId { get; set; }
        [JsonPropertyName("order")]
        public Order? Order { get; set; }
        public int quantity { get; set; }
    }
}
