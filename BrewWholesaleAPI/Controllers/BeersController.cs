using BrewWholesaleAPI.Core.API;
using BrewWholesaleAPI.Core.Data.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BrewWholesaleAPI.Controllers
{

    [ApiController]
    [Route("api/[controller]/[action]")]
    public class BeersController : Controller
    {
        #region Get Methods

        [HttpGet]
        public IActionResult GetAllBeers()
        {
            try
            {
                return Ok(ManageBeers.GetList());
            }
            catch (Exception ex)
            {
                ManageLogs.InsertLog(ex);
                return BadRequest(ex.Message);
            }
        }

        #endregion

        #region Post Methods

        [HttpPost]
        public IActionResult AddBeer(BeerModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return Ok(ManageBeers.Save(model));
                }
                return BadRequest(ModelState);
            }
            catch (Exception ex)
            {
                ManageLogs.InsertLog(ex);
                return BadRequest(ex.Message);
            }

        }

        [HttpPost]
        public IActionResult DeleteBeer(int beerId)
        {
            try
            {
                if (beerId != 0)
                {
                    ManageBeers.MarkAsDeleted(beerId);
                    return Ok();
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                ManageLogs.InsertLog(ex);
                return BadRequest(ex.Message);
            }

        }

        [HttpPost]
        public IActionResult GetBeersByBrewery(int breweryId)
        {
            try
            {
                return Ok(ManageBeers.GetListByBrewery(breweryId));
            }
            catch (Exception ex)
            {
                ManageLogs.InsertLog(ex);
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult UpdateBeerQuantity(WholeSalerBeerModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return Ok(ManageBeers.UpdateBeerQuantity(model));
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
