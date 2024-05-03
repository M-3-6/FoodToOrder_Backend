using FoodToOrder_Backend.Models;

namespace FoodToOrder_Backend.Services
{
    public interface IAddressService
    {
        IEnumerable<Address> GetAddresses();
        Address GetAddressById(int AddressId);
        void InsertAddress(Address Address);
        void DeleteAddress(int AddressId);
        void UpdateAddress(Address Address);
        void Save();
    }
}
