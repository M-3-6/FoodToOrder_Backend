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
    public class CartsController : ControllerBase
    {
        private readonly ICartService _cartService;

        public CartsController(ICartService cartService)
        {
            _cartService = cartService;
        }

        // GET: api/Carts
        [HttpGet]
        public IEnumerable<Cart> GetCarts()
        {
            return _cartService.GetCarts();
        }

        // GET: api/Carts/5
        [HttpGet("{id}")]
        public Cart GetCart(int id)
        {
            return _cartService.GetCartById(id);
        }

        // PUT: api/Carts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public Cart PutCart(int id, Cart cart)
        {
            return _cartService.UpdateCart(cart);
        }

        // POST: api/Carts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public Cart PostCart(Cart cart)
        {
            return _cartService.AddCart(cart);
        }

        // DELETE: api/Carts/5
        [HttpDelete("{id}")]
        public Cart DeleteCart(int id)
        {
           return _cartService.DeleteCart(id);
        }

    }
}
