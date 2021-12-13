using WebAPIDynamicExample.Configuration;
using WebAPIDynamicExample.Configuration.Interfaces;
using WebAPIDynamicExample.Models;
using WebAPIDynamicExample.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WebAPIDynamicExample.Repositories
{
    public class WeatherForecastRepo : IWeatherForecastRepo
    {
        private WebAPIDynamicExampleConfiguration Config { get; set;  }
        private static string[] Summaries { get; set; }

        public WeatherForecastRepo(IConfigRetriever config)
        {
            Config = config.Get();
            Summaries = Config.Summaries.Split(',');
        }
        public IEnumerable<WeatherForecast> GetWeatherForecast()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
