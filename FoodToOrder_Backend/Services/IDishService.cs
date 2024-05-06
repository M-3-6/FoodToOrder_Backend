using FoodToOrder_Backend.Models;

namespace FoodToOrder_Backend.Services
{
    public interface IDishService
    {
        List<Dish> GetDishes();
        List<Dish> GetDishesByRestaurantId(int id);
        Dish GetDishById(int id);
        void UpdateDish(Dish Dish);
    }
}
