using Microsoft.AspNetCore.Mvc;
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
using WebAPIDynamicExample.Util;

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
        private string LoadXmlRequest(string year)
        {
            return XmlBuilder.LoadSpendingXML(year);
        }

        private string GetSubsetofResultXml(string xmlresult)
        {
            XmlReader reader = XmlReader.Create(new StringReader(xmlresult));
            var doc = XDocument.Load(reader);
            var subset = doc.Root.Elements("result_records")
                                    .Elements("spending_transactions");
           return string.Concat(subset.Select(element => element.ToString()));
        }

        public async Task<List<Expense>> GetSpendingData(string year)
        {
            //load the request
            var body = LoadXmlRequest(year);

            //Post request
            var xmlresult =  await NYCSpendingDataRepo.GetSpendingDataAsync(body);

            //filter response
            var subset = GetSubsetofResultXml(xmlresult);

            if (!string.IsNullOrWhiteSpace(subset))
            {
                //Convert Response & serialize
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(subset);
                string json = JsonConvert.SerializeXmlNode(doc);

                //deserialize using dynamics
                List<Expense> tlist = ConvertDataDynamically(json);
                return tlist;
            }
            else
            {
                //no results returned.
                return new List<Expense>();
            }
        }

        private List<Expense> ConvertDataDynamically(string json)
        {
            List<Expense> tlist = new List<Expense>();
            double number;
            dynamic data = JsonConvert.DeserializeObject<ExpandoObject>(json, new ExpandoObjectConverter());
            foreach (var transaction in (data.spending_transactions.transaction))
            {
                Expense t = new Expense();
                t.Name = transaction.agency;
                if (double.TryParse(transaction.check_amount, out number))
                {
                    t.CheckAmount = number;
                }
                else
                {
                    t.CheckAmount = 0;
                }
                t.PayeeName = transaction.payee_name;
                
                tlist.Add(t);
            }
            return tlist.OrderByDescending(x => x.CheckAmount).ToList<Expense>();
        }
    }
}
