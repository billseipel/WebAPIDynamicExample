using WebAPIDynamicExample.Managers.Interfaces;
using WebAPIDynamicExample.Models;
using WebAPIDynamicExample.Repositories.Interfaces;
using System.Collections.Generic;

namespace WebAPIDynamicExample.Managers
{
    public class WeatherForecastManager : IWeatherForecastManager
    {
       private IWeatherForecastRepo WeatherForecastRepo { get; set; }

        public WeatherForecastManager(IWeatherForecastRepo weatherforecastrepo)
        {
            WeatherForecastRepo = weatherforecastrepo;
        }

        public IEnumerable<WeatherForecast> GetWeatherForecast()
        {
            return WeatherForecastRepo.GetWeatherForecast();
        }
    }
}
