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
    public class MenuController : Controller
    {
        [HttpGet]
        [EnableCors("Cors")]
        public IActionResult Get()
        {
            List<Menu> menus = MenuRepository.Instance.GetAll().ToList();

            return Ok(menus);
        }

        [HttpGet("{id}")]
        [EnableCors("Cors")]
        public IActionResult Get(long id)
        {
            Menu menu = MenuRepository.Instance.GetById(id);
            return Ok(menu);
        }

        [HttpPost]
        [EnableCors("Cors")]
        public IActionResult Post([FromBody]Menu menu)
        {
            menu = MenuRepository.Instance.CreateMenu(menu);

            return Created($"api/menu/{menu}", menu);
        }

        [HttpPut("{id}")]
        [EnableCors("Cors")]
        public IActionResult Put(long id, [FromBody]Menu menu)
        {
            menu = MenuRepository.Instance.UpdateMenu(menu);

            return Accepted(menu);
        }

        [HttpDelete("{id}")]
        [EnableCors("Cors")]
        public IActionResult Delete(long id)
        {
            Menu menu = MenuRepository.Instance.GetById(id);

            MenuRepository.Instance.DeleteMenu(menu);

            return NoContent();
        }
    }
}
