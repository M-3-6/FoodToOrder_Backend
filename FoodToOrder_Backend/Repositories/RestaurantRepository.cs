using FoodToOrder_Backend.Models;

namespace FoodToOrder_Backend.Repositories
{
    public class RestaurantRepository : IRestaurantRepository
    {
        

        public void Dispose()
        {
            Console.WriteLine("Restaurant Repo Disposed");
        }

        public Restaurant GetRestaurantById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Restaurant> GetRestaurants()
        {
            throw new NotImplementedException();
        }

        public Restaurant InsertRestaurant(Restaurant restaurant)
        {
            throw new NotImplementedException();
        }

        public Restaurant UpdateRestaurant(Restaurant newRestaurant)
        {
            throw new NotImplementedException();
        }
        public Restaurant DeleteRestaurant(int id)
        {
            throw new NotImplementedException();
        }
    }
}
