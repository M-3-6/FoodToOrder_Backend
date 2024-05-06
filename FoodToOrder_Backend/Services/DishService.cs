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

        public void UpdateDish(Dish Dish)
        {
            repo.UpdateDish(Dish);
        }
    }
}
