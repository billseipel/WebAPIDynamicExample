using System;
using System.Net.Http;
using System.Threading.Tasks;
using WebAPIDynamicExample.Configuration;
using WebAPIDynamicExample.Configuration.Interfaces;
using WebAPIDynamicExample.Repositories.Interfaces;

namespace WebAPIDynamicExample.Repositories
{
    public class NYCComptrollerCheckbookRepo : INYCComptrollerCheckbookRepo
    {
        private WebAPIDynamicExampleConfiguration Config { get; set; }
        private HttpClient HttpClient { get; }
        public NYCComptrollerCheckbookRepo(IConfigRetriever configuration
            , HttpClient httpclient)
        {
            Config = configuration.Get();
            HttpClient = httpclient;
        }
        
        public async Task<string> GetExceedFunding()
        {
            var uri = HttpClient.BaseAddress;
            HttpResponseMessage response;

            response = await HttpClient.GetAsync(uri);

            string result = String.Empty;
            if (response.IsSuccessStatusCode)
            {
                result = response.Content.ReadAsStringAsync().Result;
            }
            return result;
        }
    }
}
