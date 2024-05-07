using FoodToOrder_Backend.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

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
            return appDbContext.Orders.Include(o => o.User).Include(o => o.dishOrders).ThenInclude(od=>od.Dish).Where(o=> o.id == OrderId).FirstOrDefault();
        }

        public IEnumerable<Order> GetOrders()
        {
            IEnumerable<Order> ord = appDbContext.Orders.Include(o => o.dishOrders).ThenInclude(od => od.Dish).ToList();
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
            var tempOrder = appDbContext.Orders.Include(od => od.dishOrders).Where(o => o.id == Order.id).FirstOrDefault();

            foreach (var odish in Order.dishOrders)
            {
                bool check = tempOrder.dishOrders.Where(od => (od.DishId == odish.DishId)).IsNullOrEmpty();
                if (check)
                {
                    appDbContext.DishOrders.Add(odish);
                }
            }
            appDbContext.SaveChanges();

            appDbContext.Entry(Order).State = EntityState.Detached;
            appDbContext.Entry(tempOrder).State = EntityState.Detached;
            
            foreach (var odish in tempOrder.dishOrders)
            {
                bool check = Order.dishOrders.Where(od => (od.DishId == odish.DishId)).IsNullOrEmpty();
                bool empty = Order.dishOrders.Where(od => (od.DishId == odish.DishId)).FirstOrDefault().Dish == null;
                if (check || empty)
                {
                    appDbContext.DishOrders.Remove(odish);
   
                }
            }
            appDbContext.SaveChanges();

            appDbContext.Entry(Order).State = EntityState.Detached;
            appDbContext.Entry(tempOrder).State = EntityState.Detached;
            
            appDbContext.Orders.Update(Order);
            appDbContext.SaveChanges();
        }
    }
}
