using FoodToOrder_Backend.Models;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;

namespace FoodToOrder_Backend.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly FoodToOrderAppContext appDbContext;

        public OrderRepository(FoodToOrderAppContext injectedContext)
        {
            this.appDbContext = injectedContext;
        }
        public void DeleteOrder(int OrderId)
        {
            Order order = appDbContext.Orders.Include(o => o.dishOrders).Where(o => o.id == OrderId).FirstOrDefault();
            appDbContext.Orders.Remove(order);
            appDbContext.SaveChanges();
        }

        public Order GetOrderById(int OrderId)
        {
            return appDbContext.Orders.Include(o => o.User).Include(o => o.dishOrders).Where(o=> o.id == OrderId).FirstOrDefault();
        }

        public IEnumerable<Order> GetOrders()
        {
            return appDbContext.Orders.Include(o => o.User).Include(o => o.dishOrders).ToList();
        }

        public void InsertOrder(Order Order)
        {
            appDbContext.Database.OpenConnection();
            appDbContext.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Orders ON");
            appDbContext.Orders.Add(Order);
            appDbContext.SaveChanges();
            appDbContext.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Orders OFF");
            appDbContext.Database.CloseConnection();
        }

        public void Save()
        {
            Console.WriteLine("saved user");
        }
        public void Dispose()
        {
            Console.WriteLine("Disposed");
        }

        public void UpdateOrder(Order Order)
        {
            appDbContext.Orders.Update(Order);
            appDbContext.SaveChanges();
        }
    }
}
