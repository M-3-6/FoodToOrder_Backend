using FoodToOrder_Backend.Models;
using FoodToOrder_Backend.Repositories;

namespace FoodToOrder_Backend.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;
        public UserService(IUserRepository userRepository) {
            this.userRepository = userRepository;
        }
        public void DeleteUser(int UserId)
        {
           userRepository.DeleteUser(UserId);
        }

        public User GetUserById(int UserId)
        {
            return userRepository.GetUserById(UserId);
        }

        public IEnumerable<User> GetUsers()
        {
            return userRepository.GetUsers().ToList();
        }

        public void InsertUser(User User)
        {
            userRepository.InsertUser(User);
        }

        public void Save()
        {
            Console.WriteLine("saved user");
        }
        public void Dispose()
        {
            Console.WriteLine("Disposed");
        }

        public void UpdateUser(User User)
        {
            userRepository.UpdateUser(User);
        }
    }
}
