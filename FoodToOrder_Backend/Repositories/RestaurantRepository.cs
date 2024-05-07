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
            return _context.Restaurants.Include(r => r.dishes).Include(r=>r.arrAddresses).ToList();
        }

        public Restaurant GetRestaurantById(int restId)
        {
            return _context.Restaurants.Include(r => r.dishes).Include(r => r.arrAddresses).Where(r => r.id == restId).First();
            //return _context.Restaurants.Where(r => r.id == restId).First();
        }

        public Restaurant InsertRestaurant(Restaurant restaurant)
        {
            _context.Restaurants.Add(restaurant);
            _context.SaveChanges();
            return restaurant;
        }

        public Restaurant UpdateRestaurant(Restaurant newRestaurant)
        {

            _context.Restaurants.Update(newRestaurant);
            _context.SaveChanges();

            _context.Entry(newRestaurant).State = EntityState.Detached;

            var tempRest = _context.Restaurants.Include(r=>r.arrAddresses).Where(r => r.id == newRestaurant.id).FirstOrDefault();
            foreach (var add in tempRest.arrAddresses)
            {
                bool check = newRestaurant.arrAddresses.Where(ad => (ad.id == add.id)).IsNullOrEmpty();
                if (check)
                {
                    _context.Addresses.Remove(add);
                }
            }
            _context.SaveChanges();
    
            _context.Entry(tempRest).State = EntityState.Detached;

            
            return newRestaurant;
        }
        public Restaurant DeleteRestaurant(int id)
        {
            var restToBeDel = _context.Restaurants.Include(r=>r.arrAddresses).Where(r=> r.id == id).FirstOrDefault();
            _context.Remove(restToBeDel);
            _context.SaveChanges();
            return restToBeDel;
        }

        public void Dispose()
        {
            Console.WriteLine("Restaurant Repo Disposed");
        }
    }
}
