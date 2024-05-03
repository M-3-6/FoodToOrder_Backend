using FoodToOrder_Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace FoodToOrder_Backend.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        private FoodToOrderAppContext appDbContext;

        public AddressRepository(FoodToOrderAppContext injectedContext)
        {
            appDbContext = injectedContext;
        }
       
        public Address GetAddressById(int AddressId)
        {
            return appDbContext.Addresses.Include(a => a.User).Where(a => a.id == AddressId).FirstOrDefault();
        }

        public IEnumerable<Address> GetAddresses()
        {
            return appDbContext.Addresses.ToList();
        }

        public void Dispose()
        {
            Console.WriteLine("Disposed");
        }

    }
}
