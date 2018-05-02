using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CedroAPI.Models;
using CedroAPI.Repository;
using Microsoft.AspNetCore.Cors;

namespace CedroAPI.Controllers
{
    [Route("api/[controller]")]
    public class RestaurantController : Controller
    {
        [HttpGet]
        [EnableCors("Cors")]
        public IActionResult Get()
        {
            List<Restaurant> restaurants = RestaurantRepository.Instance.GetAll().ToList();

            return Ok(restaurants);
        }

        [HttpGet("{id}")]
        [EnableCors("Cors")]
        public IActionResult Get(long id)
        {
            Restaurant restaurant = RestaurantRepository.Instance.GetById(id);
            return Ok(restaurant);
        }

        [HttpPost]
        [EnableCors("Cors")]
        public IActionResult Post([FromBody]Restaurant restaurant)
        {
            restaurant = RestaurantRepository.Instance.CreateRestaurant(restaurant);

            return Created($"api/restaurant/{restaurant}", restaurant);
        }

        [HttpPut("{id}")]
        [EnableCors("Cors")]
        public IActionResult Put(long id, [FromBody]Restaurant restaurant)
        {
            restaurant = RestaurantRepository.Instance.UpdateRestaurant(restaurant);

            return Accepted(restaurant);
        }

        [HttpDelete("{id}")]
        [EnableCors("Cors")]
        public IActionResult Delete(long id)
        {
            Restaurant restaurant = RestaurantRepository.Instance.GetById(id);

            List<Menu> menus = MenuRepository.Instance.GetByRestaurantId(restaurant.Id).ToList();

            foreach (Menu menu in menus) {
                MenuRepository.Instance.DeleteMenu(menu);
            }

            RestaurantRepository.Instance.DeleteRestaurant(restaurant);

            return NoContent();
        }
    }
}
