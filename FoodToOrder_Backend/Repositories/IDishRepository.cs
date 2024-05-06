using FoodToOrder_Backend.Models;

namespace FoodToOrder_Backend.Repositories
{
    public interface IDishRepository
    {
        List<Dish> GetDishes();
        void UpdateDish(Dish Dish);
    }
}
