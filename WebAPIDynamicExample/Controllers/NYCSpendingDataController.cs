using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPIDynamicExample.Managers.Interfaces;
using WebAPIDynamicExample.Models;

namespace WebAPIDynamicExample.Controllers
{
    [ApiController]
    [Route("NYC")]
    public class NYCSpendingDataController : ControllerBase
    {
        private INYCSpendingDataManager NYCSpendingDataManager { get; set; }
        public NYCSpendingDataController(INYCSpendingDataManager nycspendingdatamanager)
        {
            NYCSpendingDataManager = nycspendingdatamanager;
        }
        [HttpGet]
        [Route("GetExceedFunding")]
        public async Task<List<AccountingData>> GetExceedFunding()
        {
            return await NYCSpendingDataManager.GetExceedFunding();
        }
    }
}
