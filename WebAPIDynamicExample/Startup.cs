using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Net;
using System.Net.Http;
using WebAPIDynamicExample.Configuration;
using WebAPIDynamicExample.Configuration.Interfaces;
using WebAPIDynamicExample.Managers;
using WebAPIDynamicExample.Managers.Interfaces;
using WebAPIDynamicExample.Repositories;
using WebAPIDynamicExample.Repositories.Interfaces;

namespace WebAPIDynamicExample
{
    public class Startup
    {
        private IWebHostEnvironment Environment { get; }
        private IConfiguration Configuration { get; }

        public Startup(IWebHostEnvironment env, IConfiguration config)
        {
            Environment = env;
            Configuration = config;
        }

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            ContainerBuilder builder = new ContainerBuilder();
            services.AddControllers();

            // HttpClient singleton inst for reuse
            Uri endPointA = new Uri(Configuration["ThirdPartyAPIURL"]); // this is the endpoint HttpClient will hit
            HttpClient httpClient = new HttpClient()
            {
                BaseAddress = endPointA
            };
            ServicePointManager.FindServicePoint(endPointA).ConnectionLeaseTimeout = 60000; // sixty seconds
            services.AddSingleton<HttpClient>(httpClient);

            builder.Populate(services);

            builder.RegisterType<ConfigRetriever>()
                .As<IConfigRetriever>()
                .WithParameter(new TypedParameter(typeof(IConfiguration), Configuration));

            builder.RegisterType<NYCSpendingDataManager>()
               .As<INYCSpendingDataManager>();

            builder.RegisterType<NYCComptrollerCheckbookRepo>()
                .As<INYCComptrollerCheckbookRepo>();

            return new AutofacServiceProvider(builder.Build());
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
