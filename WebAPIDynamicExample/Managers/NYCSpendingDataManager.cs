using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using WebAPIDynamicExample.Configuration;
using WebAPIDynamicExample.Configuration.Interfaces;
using WebAPIDynamicExample.Managers.Interfaces;
using WebAPIDynamicExample.Models;
using WebAPIDynamicExample.Properties;
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
        private string LoadXmlRequest()
        {
            // load the xml request
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.LoadXml(Resources.NYC_Spending_2018);
            StringWriter sw = new StringWriter();
            XmlTextWriter xw = new XmlTextWriter(sw);
            xmldoc.WriteTo(xw);
            return sw.ToString();

        }

        private string GetSubsetofResultXml(string xmlresult)
        {
            XmlReader reader = XmlReader.Create(new StringReader(xmlresult));
            var doc = XDocument.Load(reader);
            // these xml elements could be specific to type requested
            var subset = doc.Root.Elements("result_records")
                                    .Elements("spending_transactions");
                                    //.Elements("transaction");
           return string.Concat(subset.Select(element => element.ToString()));
        }

        public async Task<string> GetSpendingData()
        {
            //load the request
            var body = LoadXmlRequest();

            //Post request
            var xmlresult =  await NYCSpendingDataRepo.GetSpendingData(body);

            //filter response
            var subset = GetSubsetofResultXml(xmlresult);

            //Convert Response
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(subset);
            string json = JsonConvert.SerializeXmlNode(doc);

            //deserialize dynamic input
            List<Transaction> tlist = new List<Transaction>();
            double number;
            dynamic data = JsonConvert.DeserializeObject<ExpandoObject>(json, new ExpandoObjectConverter());
            foreach (var transaction in (data.spending_transactions.transaction))
            {
                Transaction t = new Transaction();
                t.Name = transaction.agency;
                if (double.TryParse(transaction.check_amount, out number)) 
                {
                    t.CheckAmount = number;
                }
                else
                {
                    t.CheckAmount = 0;
                }
                tlist.Add(t);
            }
            var final = JsonConvert.SerializeObject(tlist);
            return final;
        }
    }
}
