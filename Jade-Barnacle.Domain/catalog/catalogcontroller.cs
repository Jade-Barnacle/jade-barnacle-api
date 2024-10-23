using Microsoft.AspNetCore.Mvc;
using Jade.Barnacle.Domain.Catalog;

namespace Jade.Barnacle.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CatalogController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetItems()
        {
            return Ok("hello world.");
        }


    }
}








