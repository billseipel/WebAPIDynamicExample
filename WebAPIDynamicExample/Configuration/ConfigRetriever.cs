using Microsoft.Extensions.Configuration;
using WebAPIDynamicExample.Configuration.Interfaces;

namespace WebAPIDynamicExample.Configuration
{
    public class ConfigRetriever : IConfigRetriever
    {
        public IConfiguration Configuration { get; set; }

        public ConfigRetriever(IConfiguration config)
        {
            Configuration = config;
        }

        public WebAPIDynamicExampleConfiguration Get()
        {
            var config = new WebAPIDynamicExampleConfiguration()
            {
                AuthKey         = Configuration["AuthKey"],
                AuthValue       = Configuration["AuthValue"],
                ThirdPartyAPI   = Configuration["ThirdPartyAPIURL"]               
            };
            return config;
        }
    }
}
