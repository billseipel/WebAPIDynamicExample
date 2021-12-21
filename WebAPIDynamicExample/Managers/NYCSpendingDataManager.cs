using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIDynamicExample.Configuration;
using WebAPIDynamicExample.Configuration.Interfaces;
using WebAPIDynamicExample.Managers.Interfaces;
using WebAPIDynamicExample.Models;
using WebAPIDynamicExample.Repositories.Interfaces;

namespace WebAPIDynamicExample.Managers
{
    public class NYCSpendingDataManager : INYCSpendingDataManager
    {
        private WebAPIDynamicExampleConfiguration Config { get; set; }
        private INYCComptrollerCheckbookRepo NYCSpendingDataRepo { get; set; }

        public NYCSpendingDataManager(IConfigRetriever config,
            INYCComptrollerCheckbookRepo nyccomptrollerRepo)
        {
            Config = config.Get();
            NYCSpendingDataRepo = nyccomptrollerRepo;
        }

        public async Task<List<AccountingData>> GetExceedFunding()
        {
            List<AccountingData> listad = new List<AccountingData>();
            var json = await NYCSpendingDataRepo.GetExceedFunding();
            dynamic config = JsonConvert.DeserializeObject<ExpandoObject>(json, new ExpandoObjectConverter());
            var result = (IEnumerable<dynamic>)config.data;
            foreach(var a in result)
            {
                var arrayResult = JArray.Parse(JsonConvert.SerializeObject(a));
                AccountingData ad = new AccountingData();
                ad.FiscalYear = arrayResult[9].ToString();
                ad.DeptId = arrayResult[10].ToString();
                ad.DeptName = arrayResult[11].ToString();
                ad.FundsAvail = arrayResult[12];
                ad.FundsUsed = arrayResult[13];
                listad.Add(ad);
            }
            var listresult = listad.Where(x => x.FundsUsed >= x.FundsAvail);
            return listresult.ToList();
        }
    }   
}
