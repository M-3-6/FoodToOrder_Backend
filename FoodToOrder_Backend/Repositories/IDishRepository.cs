using FoodToOrder_Backend.Models;

namespace FoodToOrder_Backend.Repositories
{
    public interface IDishRepository
    {
        List<Dish> GetDishes();
        List<Dish> GetDishesByRestaurantId(int id);
        Dish GetDishById(int id);
        void UpdateDish(Dish Dish);
    }
}
