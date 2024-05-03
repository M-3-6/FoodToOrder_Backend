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
    public class RestaurantsController : ControllerBase
    {
        private readonly RestaurantService restService;

        public RestaurantsController(RestaurantService restService)
        {
            this.restService = restService;
        }

        // GET: api/Restaurants
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Restaurant>>> GetRestaurants()
        {
            return restService.GetRestaurants().ToList();
        }

        // GET: api/Restaurants/5
        [HttpGet("{id}")]
        public Restaurant GetRestaurant(int id)
        {
           
            return restService.GetRestaurantById(id);
        }

        // PUT: api/Restaurants/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public Restaurant PutRestaurant(int id, Restaurant restaurant)
        {
            if (id != restaurant.id)
            {
                return new Restaurant();
            }

           return restService.UpdateRestaurant(restaurant);

        }

        // POST: api/Restaurants
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public Restaurant PostRestaurant(Restaurant restaurant)
        {
            return restService.InsertRestaurant(restaurant);
        }

        // DELETE: api/Restaurants/5
        [HttpDelete("{id}")]
        public Restaurant DeleteRestaurant(int id)
        {
            return restService.DeleteRestaurant(id);
        }

    }
}
