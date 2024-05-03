using FoodToOrder_Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace FoodToOrder_Backend.Repositories
{
    public class RestaurantRepository : IRestaurantRepository
    {
       private FoodToOrderAppContext context;

        public RestaurantRepository(FoodToOrderAppContext context)
        {
            this.context = context;
        }

        public void Dispose()
        {
            Console.WriteLine("Restaurant Repo Disposed");
        }

      

        public IEnumerable<Restaurant> GetRestaurants()
        {
            return context.Restaurants.Include(r => r.dishes).Include(r=>r.arrAddresses).ToList();
        }

        public Restaurant GetRestaurantById(int restId)
        {
            return context.Restaurants.Include(r => r.dishes).Include(r => r.arrAddresses).Where(r => r.id == restId).FirstOrDefault();
        }

        public Restaurant InsertRestaurant(Restaurant restaurant)
        {
            context.Restaurants.Add(restaurant);
            context.SaveChanges();
            return restaurant;
        }

        public Restaurant UpdateRestaurant(Restaurant newRestaurant)
        {
            context.Restaurants.Update(newRestaurant);
            context.SaveChanges();
            return newRestaurant;
        }
        public Restaurant DeleteRestaurant(int id)
        {
            Restaurant restToBeDel = context.Restaurants.Where(r=> r.id == id).FirstOrDefault();
            context.Remove(restToBeDel);
            context.SaveChanges();
            return restToBeDel;
        }
    }
}
