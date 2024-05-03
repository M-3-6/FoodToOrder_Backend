using FoodToOrder_Backend.Models;

namespace FoodToOrder_Backend.Repositories
{
    public interface IAddressRepository
    {
        IEnumerable<Address> GetAddresses();
        Address GetAddressById(int AddressId);
        void InsertAddress(Address Address);
        void DeleteAddress(int AddressId);
        void UpdateAddress(Address Address);
        void Save();
    }
}
