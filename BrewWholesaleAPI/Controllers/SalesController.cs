using BrewWholesaleAPI.Core.API;
using BrewWholesaleAPI.Core.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace BrewWholesaleAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[Action]")]
    public class SalesController : Controller
    {

        #region Post Methods

        [HttpPost]
        public IActionResult CreateSale(SaleModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var isSaleValid = ManageSales.Validate(model);

                    if (isSaleValid != null && !isSaleValid.IsValid)
                    {
                        return BadRequest(isSaleValid.ErrorMessage);
                    }

                    return Ok(ManageSales.CreateQuoteSale(model));
                }
                return BadRequest(ModelState);
            }
            catch (Exception ex)
            {
                ManageLogs.InsertLog(ex);
                return BadRequest(ex.Message);
            }

        }

        #endregion
    }
}
