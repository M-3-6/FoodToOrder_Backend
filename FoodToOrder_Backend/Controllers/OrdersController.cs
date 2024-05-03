using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FoodToOrder_Backend;
using FoodToOrder_Backend.Models;
using FoodToOrder_Backend.Services;

namespace FoodToOrder_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService orderService;

        public OrdersController(IOrderService orderService)
        {
            this.orderService = orderService;
        }

        // GET: api/Orders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrders()
        {
            return orderService.GetOrders().ToList();
        }

        // GET: api/Orders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetOrder(int id)
        {
            return orderService.GetOrderById(id);
        }

        // PUT: api/Orders/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public void PutOrder(int id, Order order)
        {
            orderService.UpdateOrder(order);
        }

        // POST: api/Orders
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public void PostOrder(Order order)
        {
            orderService.InsertOrder(order);
        }

        // DELETE: api/Orders/5
        [HttpDelete("{id}")]
        public void DeleteOrder(int id)
        {
            orderService.DeleteOrder(id);
        }
    }
}
