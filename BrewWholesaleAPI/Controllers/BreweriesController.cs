﻿using BrewWholesaleAPI.Core.API;
using BrewWholesaleAPI.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace BrewWholesaleAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[Action]")]
    public class BreweriesController : Controller
    {
        #region Get Methods

        [HttpGet]
        public IActionResult GetBreweries()
        {
            try
            {
                return Ok(ManageBreweries.GetList());
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
        public IActionResult AddBrewery(BreweryModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return Ok(ManageBreweries.Save(model));
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
