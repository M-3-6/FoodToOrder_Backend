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

        List<Dish> IDishRepository.GetDishes()
        {
            return appDbContext.Dishes.ToList();
        }
    }
}
