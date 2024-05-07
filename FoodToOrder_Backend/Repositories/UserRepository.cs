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
            try
            {
                User user = appDbContext.Users.Include(u => u.address).Include(u => u.cart).Include(u => u.orders).Where(u => u.id == UserId).FirstOrDefault();
                appDbContext.Remove(user);
                appDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unable to delete user", ex);
            }
        }

        public User GetUserById(int UserId)
        {
            return appDbContext.Users.Include(u => u.address).Include(u => u.cart).Include(u => u.orders).Where(u => u.id == UserId).FirstOrDefault();
        }

        public IEnumerable<User> GetUsers()
        {
            return appDbContext.Users.Include(u => u.address).Include(u => u.cart).Include(u => u.orders).ToList();
        }

        public void InsertUser(User User)
        {
            try
            {
                appDbContext.Database.OpenConnection();
                appDbContext.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Users ON");
                User.orders = [];
                appDbContext.Users.Add(User);
                appDbContext.SaveChanges();
                appDbContext.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Users OFF");
                appDbContext.Database.CloseConnection();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unable to insert user", ex);
            }
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
            try
            {
                if (User.orders is null) User.orders = [];
                appDbContext.Users.Update(User);
                appDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unable to update user", ex);
            }
        }
    }
}
