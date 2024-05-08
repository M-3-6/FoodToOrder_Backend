using FoodToOrder_Backend.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace FoodToOrder_Backend.Repositories
{
    public class RestaurantRepository : IRestaurantRepository
    {
       private FoodToOrderAppContext _context;

        public RestaurantRepository(FoodToOrderAppContext context)
        {
            _context = context;
        }

       

      

        public IEnumerable<Restaurant> GetRestaurants()
        {
            try
            {
                return _context.Restaurants.Include(r => r.dishes).Include(r => r.arrAddresses).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unable to get restaurant: ", ex.ToString());
            }
            return null;
        }

        public Restaurant GetRestaurantById(int restId)
        {
            try
            {
                return _context.Restaurants.Include(r => r.dishes).Include(r => r.arrAddresses).Where(r => r.id == restId).First();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unable to get all restaurants: ", ex.ToString());
            }
            return null;

            //return _context.Restaurants.Where(r => r.id == restId).First();
        }

        public Restaurant InsertRestaurant(Restaurant restaurant)
        {
            try
            {
                _context.Restaurants.Add(restaurant);
                _context.SaveChanges();
            }
            catch(Exception ex)
            {
                Console.WriteLine("Unable to insert restaurant: ",ex.ToString());
            }
            
            return restaurant;
        }

        public Restaurant UpdateRestaurant(Restaurant newRestaurant)
        {

            _context.Restaurants.Update(newRestaurant);
            _context.SaveChanges();

            _context.Entry(newRestaurant).State = EntityState.Detached;

            var tempRest = _context.Restaurants.Include(r=>r.arrAddresses).Include(r=>r.dishes).Where(r => r.id == newRestaurant.id).FirstOrDefault();
            foreach (var add in tempRest.arrAddresses)
            {
                bool check = newRestaurant.arrAddresses.Where(ad => (ad.id == add.id)).IsNullOrEmpty();
                if (check)
                {
                    _context.Addresses.Remove(add);
                }
            }
            foreach (var dish in tempRest.dishes)
            {
                bool check = newRestaurant.dishes.Where(tempDish => (tempDish.id == dish.id)).IsNullOrEmpty();
                if (check)
                {
                    _context.Dishes.Remove(dish);
                }
            }
            _context.SaveChanges();
    
            _context.Entry(tempRest).State = EntityState.Detached;

            
            return newRestaurant;
        }
        public Restaurant DeleteRestaurant(int id)
        {
            try
            {
                var restToBeDel = _context.Restaurants.Include(r => r.arrAddresses).Where(r => r.id == id).FirstOrDefault();
                _context.Remove(restToBeDel);
                _context.SaveChanges();
                return restToBeDel;
            }
            catch(Exception ex)
            {
                Console.WriteLine("Unable to delete restaurant: ", ex.ToString());
            }
           
            return null;
        }

        public void Dispose()
        {
            Console.WriteLine("Restaurant Repo Disposed");
        }
    }
}
