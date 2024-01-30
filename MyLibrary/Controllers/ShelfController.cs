using Microsoft.AspNetCore.Mvc;
using MyLibrary.Application.Interfaces;
using MyLibrary.Domain.Models;

namespace MyLibrary.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShelfController : ControllerBase
    {
        IShelfServices _shelfServices;

        public ShelfController(IShelfServices shelfServices)
        {
            _shelfServices = shelfServices;
        }

        [HttpGet("GetAllShelfs")]
        public IActionResult GetBook()
        {
            return Ok(_shelfServices.GetShelfs());
        }

       
    }
}