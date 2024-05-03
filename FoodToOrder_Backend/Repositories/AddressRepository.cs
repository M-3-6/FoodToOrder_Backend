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
        public void DeleteAddress(int AddressId)
        {
            Address address = appDbContext.Addresses.Include(a => a.User).Where(a => a.id == AddressId).FirstOrDefault();
            appDbContext.Remove(address);
            appDbContext.SaveChanges();
        }

        public Address GetAddressById(int AddressId)
        {
            return appDbContext.Addresses.Include(a => a.User).Where(a => a.id == AddressId).FirstOrDefault();
        }

        public IEnumerable<Address> GetAddresses()
        {
            return appDbContext.Addresses.ToList();
        }

        public void InsertAddress(Address Address)
        {
            appDbContext.Add(Address);
            appDbContext.SaveChanges();
        }

        public void Save()
        {
            Console.WriteLine("Saved");
        }

        public void Dispose()
        {
            Console.WriteLine("Disposed");
        }

        public void UpdateAddress(Address Address)
        {
            appDbContext.Update(Address);
            appDbContext.SaveChanges();
        }
    }
}
