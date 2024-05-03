using FoodToOrder_Backend.Models;
using FoodToOrder_Backend.Repositories;

namespace FoodToOrder_Backend.Services
{
    public class RestaurantService : IRestaurantService
    {

        private readonly IRestaurantRepository _restaurantRepo;
       public RestaurantService(IRestaurantRepository restaurantRepo)
        {
            _restaurantRepo = restaurantRepo;
        }
        

        public IEnumerable<Restaurant> GetRestaurants()
        {
            return _restaurantRepo.GetRestaurants();
        }
        public Restaurant GetRestaurantById(int id)
        {
            return _restaurantRepo.GetRestaurantById(id);
        }

        public Restaurant InsertRestaurant(Restaurant restaurant)
        {
            return _restaurantRepo.InsertRestaurant(restaurant);
        }

        public Restaurant UpdateRestaurant(Restaurant newRestaurant)
        {
            return _restaurantRepo.UpdateRestaurant(newRestaurant);
        }
        public Restaurant DeleteRestaurant(int id)
        {
            return _restaurantRepo.DeleteRestaurant(id);
        }
    }
}
