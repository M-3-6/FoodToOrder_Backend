using FoodToOrder_Backend.Models;

namespace FoodToOrder_Backend.Services
{
    public interface IUserService
    {
        IEnumerable<User> GetUsers();
        User GetUserById(int UserId);
        void InsertUser(User User);
        void DeleteUser(int UserId);
        void UpdateUser(User User);
        void Save();
    }
}
