using FoodToOrder_Backend.Models;
using FoodToOrder_Backend.Repositories;
using System;

namespace FoodToOrder_Backend.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository orderRepository;
        public OrderService(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }
        public IEnumerable<Order> GetOrders()
        {
            return orderRepository.GetOrders().ToList();
        }

        public Order GetOrderById(int OrderId)
        {
            return orderRepository.GetOrderById(OrderId);
        }
        public void InsertOrder(Order Order)
        {
            orderRepository.InsertOrder(Order);
        }

        public void DeleteOrder(int OrderId)
        {
            orderRepository.DeleteOrder(OrderId);
        }

        public void UpdateOrder(Order Order)
        {
            orderRepository.UpdateOrder(Order);
        }

        public void Save()
        {
            Console.WriteLine("saved user");
        }
        public void Dispose()
        {
            Console.WriteLine("Disposed");
        }



    }
}
