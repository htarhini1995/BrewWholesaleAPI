using BrewWholesaleAPI.Data;
using Microsoft.AspNetCore.Mvc;

namespace BrewWholesaleAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BreweriesController : Controller
    {
        private readonly BrewWholesaleAPIDbContext dbContext;

        public BreweriesController(BrewWholesaleAPIDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetBreweries()
        {
            return Ok(dbContext.Breweries.ToList());
        }
    }
}
