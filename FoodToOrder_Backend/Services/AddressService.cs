using FoodToOrder_Backend.Models;
using FoodToOrder_Backend.Repositories;

namespace FoodToOrder_Backend.Services
{
    public class AddressService : IAddressService
    {
        private IAddressRepository repo;

        public AddressService(IAddressRepository repo)
        {
            this.repo = repo;
        }

        IEnumerable<Address> IAddressService.GetAddresses()
        {
            return repo.GetAddresses().ToList();
        }

        Address IAddressService.GetAddressById(int id)
        {
            return repo.GetAddressById(id);
        }

        void IAddressService.InsertAddress(Address Address)
        {
            repo.InsertAddress(Address);
        }

        public void DeleteAddress(int id)
        {
            repo.DeleteAddress(id);

        }

        void IAddressService.UpdateAddress(Address address)
        {
            repo.UpdateAddress(address);
        }

        void IAddressService.Save()
        {
            Console.WriteLine("Saved");
        }
    }
}
