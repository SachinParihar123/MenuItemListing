using MenuItemListing.Models;
using MenuItemListing.Models.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MenuItemListing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   // [Authorize]
    public class MenuController : ControllerBase
    {
        private readonly IDataRepository<MenuItem> _dataRepository;
        private readonly ILogger _logger;
        public MenuController(IDataRepository<MenuItem> dataRepository, ILogger<MenuController> logger)
        {
            _dataRepository = dataRepository;
            _logger = logger;

        }
        // GET: api/<MenuController>
        [HttpGet]
        public IActionResult Get()
        {
            _logger.LogInformation("Start : Getting item details for Get");
            IEnumerable<MenuItem> menu = _dataRepository.GetAll();
            _logger.LogInformation($"Completed : Item details are { string.Join(", ", menu) }");
            return Ok(menu);
        }

        // GET api/<MenuController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            _logger.LogInformation("Start : Getting item details for {ID}", id);
            MenuItem menu = _dataRepository.Get(id);
            if(menu == null)
            {
                return NotFound("Invalid Id");
            }
            else
            {
                _logger.LogInformation($"Completed : Item details are { string.Join(", ", menu) }");
                return Ok(menu.Name);
            }
        }

        
    }
}
