using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
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
            ,HttpClient httpclient)
        {
            Config = configuration.Get();
            HttpClient = httpclient;
        }

        public async Task<string> GetSpendingDataAsync(string body)
        {
            //setup header auth
            HttpClient.DefaultRequestHeaders.Add(Config.AuthKey, Config.AuthValue);
            var uri = HttpClient.BaseAddress + "comptroller/api";
            
            byte[] byteData = Encoding.UTF8.GetBytes(body);
            HttpResponseMessage response;
            using (var content = new ByteArrayContent(byteData))
            {
                content.Headers.ContentType = new MediaTypeHeaderValue("application/xml");
                response = await HttpClient.PostAsync(uri, content);
            }
            string result = String.Empty;
            if (response.IsSuccessStatusCode)
            {
                result = response.Content.ReadAsStringAsync().Result;
            }
            return result;
        }
    }
}
