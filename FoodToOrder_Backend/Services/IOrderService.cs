using FoodToOrder_Backend.Models;

namespace FoodToOrder_Backend.Services
{
    public interface IOrderService
    {
        IEnumerable<Order> GetOrders();
        Order GetOrderById(int OrderId);
        void InsertOrder(Order Order);
        void DeleteOrder(int OrderId);
        void UpdateOrder(Order Order);
        void Save();
    }
}
