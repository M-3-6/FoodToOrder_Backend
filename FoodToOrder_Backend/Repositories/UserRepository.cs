using FoodToOrder_Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace FoodToOrder_Backend.Repositories
{
    public class UserRepository : IUserRepository
    {
        private FoodToOrderAppContext appDbContext;

        public UserRepository(FoodToOrderAppContext injectedContext)
        {
            this.appDbContext = injectedContext;
        }
        public void DeleteUser(int UserId)
        {
            User user = appDbContext.Users.Include(u => u.address).Where(u => u.id == UserId).FirstOrDefault();
            appDbContext.Remove(user);
            appDbContext.SaveChanges();
        }

        public User GetUserById(int UserId)
        {
            return appDbContext.Users.Where(u => u.id == UserId).FirstOrDefault();
        }

        public IEnumerable<User> GetUsers()
        {
            return appDbContext.Users.ToList();
        }

        public void InsertUser(User User)
        {
            appDbContext.Users.Add(User);
            appDbContext.SaveChanges();
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
            appDbContext.Users.Update(User);
            appDbContext.SaveChanges();
        }
    }
}
