using WebAPIDynamicExample.Models;
using System.Collections.Generic;

namespace WebAPIDynamicExample.Managers.Interfaces
{
    public interface IWeatherForecastManager
    {
        IEnumerable<WeatherForecast> GetWeatherForecast();
    }
}
