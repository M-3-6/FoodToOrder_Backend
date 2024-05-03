using FoodToOrder_Backend.Models;

namespace FoodToOrder_Backend.Services
{
    public interface IRestaurantService
    {
        IEnumerable<Restaurant> GetRestaurants();

        Restaurant GetRestaurantById(int id);   

        Restaurant InsertRestaurant(Restaurant restaurant);

        Restaurant UpdateRestaurant(Restaurant newRestaurant);

        Restaurant DeleteRestaurant(int id);
    }
}
