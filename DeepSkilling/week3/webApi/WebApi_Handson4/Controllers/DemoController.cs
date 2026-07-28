using System.ComponentModel.DataAnnotations;
using FilterDemoApi.Filters;
using Microsoft.AspNetCore.Mvc;

namespace FilterDemoApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [ServiceFilter(typeof(CustomActionFilter))]
    public class DemoController : ControllerBase
    {
        
        [HttpGet("ping")]
        public IActionResult Ping() => Ok("pong");

        
        [HttpGet("boom")]
        public IActionResult Boom()
        {
            throw new InvalidOperationException("Something went wrong on purpose.");
        }

        
        [HttpGet("greet")]
        public IActionResult Greet([FromQuery][Required] string name)
        {
            return Ok($"Hello, {name}!");
        }
    }
}
