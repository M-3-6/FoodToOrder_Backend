using FoodToOrder_Backend.Models;

namespace FoodToOrder_Backend.Repositories
{
    public class DishRepository : IDishRepository
    {
        private readonly FoodToOrderAppContext appDbContext;
        public DishRepository(FoodToOrderAppContext injectedContext)
        {
            this.appDbContext = injectedContext;
        }
        public void UpdateDish(Dish Dish)
        {
            appDbContext.Dishes.Update(Dish);
            appDbContext.SaveChanges();
        }

        Dish IDishRepository.GetDishById(int id)
        {
            return appDbContext.Dishes.Where(d => d.id == id).FirstOrDefault();
        }

        List<Dish> IDishRepository.GetDishes()
        {
            return appDbContext.Dishes.ToList();
        }

        List<Dish> IDishRepository.GetDishesByRestaurantId(int id)
        {
            return appDbContext.Dishes.Where(d => d.restaurant_id == id).ToList();
        }
    }
}
