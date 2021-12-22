using WebAPIDynamicExample.Managers;
using WebAPIDynamicExample.Managers.Interfaces;
using WebAPIDynamicExample.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPIDynamicExample.Controllers
{
    [ApiController]
    [Route("NYC/api/[controller]")]
    [Produces("application/json")]
    public class SpendingController : ControllerBase
    {
        private INYCSpendingDataManager NYCSpendingDataManager { get; set; }

        public SpendingController(INYCSpendingDataManager nycspendingdatamanager)
        {
            NYCSpendingDataManager = nycspendingdatamanager;
        }

        [HttpGet("Expense/{year}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Expense>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetSpendingData(string year)
        {
            if (!string.IsNullOrWhiteSpace(year))
            {
                var result = await NYCSpendingDataManager.GetSpendingData(year);
                if(result != null)
                {
                    return Ok(result);
                }
                else
                {
                    // Not really a 'not found'. Needs a proper response model
                    return NotFound();
                }
            }
            return BadRequest();
        }
    }
}
