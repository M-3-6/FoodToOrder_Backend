using FoodToOrder_Backend.Models;

namespace FoodToOrder_Backend.Services
{
    public interface IDishService
    {
        List<Dish> GetDishes();
        void UpdateDish(Dish Dish);
    }
}
