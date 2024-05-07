using FoodToOrder_Backend.Models;
using FoodToOrder_Backend.Repositories;

namespace FoodToOrder_Backend.Services
{
    public class DishService : IDishService
    {
        private readonly IDishRepository repo;
        public DishService(IDishRepository repo)
        {
            this.repo = repo;
        }

        public List<Dish> GetDishes()
        {
            return repo.GetDishes();
        }

        public List<Dish> GetDishesByRestaurantId(int id)
        {
            return repo.GetDishesByRestaurantId(id);
        }

        public void UpdateDish(Dish Dish)
        {
            repo.UpdateDish(Dish);
        }

        Dish IDishService.GetDishById(int id)
        {
            return repo.GetDishById(id);
        }
    }
}
