using BrewWholesaleAPI.Core.Data;
using Microsoft.AspNetCore.Mvc;

namespace BrewWholesaleAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BreweriesController : Controller
    {
        #region Get Methods

        [HttpGet]
        public IActionResult GetBreweries()
        {
            return Ok(new Brewery().List());
        } 

        #endregion
    }
}
