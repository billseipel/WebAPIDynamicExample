using WebAPIDynamicExample.Managers;
using WebAPIDynamicExample.Managers.Interfaces;
using WebAPIDynamicExample.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIDynamicExample.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NYCSpendingDataController : ControllerBase
    {
        private INYCSpendingDataManager NYCSpendingDataManager { get; set; }

        public NYCSpendingDataController(INYCSpendingDataManager nycspendingdatamanager)
        {
            NYCSpendingDataManager = nycspendingdatamanager;
        }

        [HttpGet]
        public async Task<string> GetSpendingData()
        {
            return await NYCSpendingDataManager.GetSpendingData();
        }
    }
}
