using System.IO;
using System.Threading.Tasks;
using System.Xml;
using WebAPIDynamicExample.Configuration;
using WebAPIDynamicExample.Configuration.Interfaces;
using WebAPIDynamicExample.Managers.Interfaces;
using WebAPIDynamicExample.Properties;
using WebAPIDynamicExample.Repositories;
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

        public async Task<string> GetSpendingData()
        {
            // load the xml request
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.LoadXml(Resources.NYC_Spending_2018);
            StringWriter sw = new StringWriter();
            XmlTextWriter xw = new XmlTextWriter(sw);
            xmldoc.WriteTo(xw);
            var body = sw.ToString();

            //TODO: create a method to dynamically load the xml, convert to json
            //var result = await NYCSpendingDataRepo.GetSpendingData(body);
             return await NYCSpendingDataRepo.GetSpendingData(body);
        }
    }
}
