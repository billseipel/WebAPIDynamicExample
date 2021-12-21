using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace WebAPIDynamicExample
{
    public class Program
    {
        // Thank you for taking a look at my work. Ideally I'd want to complete this 
        // with Unit Testing with as close to 100% code coverage as possible. 
        public static void Main(string[] args)
        {
            CreateWebHostBuilder().Build().Run();
        }
        public static IWebHostBuilder CreateWebHostBuilder() =>
            WebHost.CreateDefaultBuilder()
                .UseStartup<Startup>();
    }
}
