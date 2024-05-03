using FoodToOrder_Backend.Models;
using FoodToOrder_Backend.Repositories;

namespace FoodToOrder_Backend.Services
{
    public class RestaurantService : IRestaurantService
    {

        private readonly IRestaurantRepository restaurantRepo;
       public RestaurantService(IRestaurantRepository restaurantRepository)
        {
            this.restaurantRepo = restaurantRepository;
        }
        

        public IEnumerable<Restaurant> GetRestaurants()
        {
            return restaurantRepo.GetRestaurants();
        }
        public Restaurant GetRestaurantById(int id)
        {
            return restaurantRepo.GetRestaurantById(id);
        }

        public Restaurant InsertRestaurant(Restaurant restaurant)
        {
            return restaurantRepo.InsertRestaurant(restaurant);
        }

        public Restaurant UpdateRestaurant(Restaurant newRestaurant)
        {
            return restaurantRepo.UpdateRestaurant(newRestaurant);
        }
        public Restaurant DeleteRestaurant(int id)
        {
            return restaurantRepo.DeleteRestaurant(id);
        }
    }
}
