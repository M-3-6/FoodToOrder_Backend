using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FoodToOrder_Backend;
using FoodToOrder_Backend.Models;
using FoodToOrder_Backend.Repositories;
using FoodToOrder_Backend.Services;

namespace FoodToOrder_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DishesController : ControllerBase
    {
        private readonly IDishService service;

        public DishesController(IDishService service)
        {
            this.service = service;
        }

        // GET: api/Dishes
        [HttpGet]
        public IEnumerable<Dish> GetDishes()
        {
            return service.GetDishes();
        }

        //// GET: api/Dishes/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Dish>> GetDish(int id)
        //{
        //    var dish = await _context.Dishes.FindAsync(id);

        //    if (dish == null)
        //    {
        //        return NotFound();
        //    }

        //    return dish;
        //}

        // PUT: api/Dishes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public void PutDish(int id, Dish dish)
        {
            service.UpdateDish(dish);
        }

        // POST: api/Dishes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<Dish>> PostDish(Dish dish)
        //{
        //    _context.Dishes.Add(dish);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetDish", new { id = dish.id }, dish);
        //}

        //// DELETE: api/Dishes/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteDish(int id)
        //{
        //    var dish = await _context.Dishes.FindAsync(id);
        //    if (dish == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Dishes.Remove(dish);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        //private bool DishExists(int id)
        //{
        //    return _context.Dishes.Any(e => e.id == id);
        //}
    }
}
