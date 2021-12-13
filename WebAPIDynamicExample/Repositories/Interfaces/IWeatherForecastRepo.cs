using WebAPIDynamicExample.Models;
using System.Collections.Generic;

namespace WebAPIDynamicExample.Repositories.Interfaces
{
    public interface IWeatherForecastRepo
    {
        IEnumerable<WeatherForecast> GetWeatherForecast();
    }
}
