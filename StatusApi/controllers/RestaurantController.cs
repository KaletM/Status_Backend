using Microsoft.AspNetCore.Mvc;
using StatusApi.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StatusApi.Services.Repositories;
using StatusApi.Services.RepositoriesImpl;

namespace StatusApi.Controllers
{
    
    [ApiController]
    [Route("api/[controller]")]
    public class RestaurantController : ControllerBase
    {
        private readonly IRestaurantRepository _restaurantService;

        public RestaurantController(IRestaurantRepository restaurantService)
        {
            _restaurantService = restaurantService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Restaurant>>> GetRestaurants()
        {
            var restaurants = await _restaurantService.GetAllRestaurantsAsync();
            return Ok(restaurants);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Restaurant>> GetRestaurant(int id)
        {
            var restaurant = await _restaurantService.GetRestaurantByIdAsync(id);
            if (restaurant == null)
            {
                return NotFound();
            }
            return Ok(restaurant);
        }

        [HttpPost]
        public async Task<ActionResult<Restaurant>> CreateRestaurant(Restaurant restaurant)
        {
            await _restaurantService.AddRestaurantAsync(restaurant);
            return CreatedAtAction(nameof(GetRestaurant), new { id = restaurant.Id }, restaurant);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRestaurant(int id, [FromBody] Restaurant updatedRestaurant)
        {
           if (updatedRestaurant == null || id != updatedRestaurant.Id)
            {
                return BadRequest("Invalid data.");
            }

            var restaurant = await _restaurantService.GetRestaurantByIdAsync(id);
            if (restaurant == null)
            {
                return NotFound("Restaurant not found.");
            }

            await _restaurantService.UpdateRestaurantAsync(updatedRestaurant);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteRestaurant(int id)
        {
            var restaurant = await _restaurantService.GetRestaurantByIdAsync(id);
            if (restaurant == null)
            {
                return NotFound();
            }

            await _restaurantService.DeleteRestaurantAsync(id);
            return NoContent();
        }
    }
}
    
    