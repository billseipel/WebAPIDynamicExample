using WebAPIDynamicExample.Managers;
using WebAPIDynamicExample.Managers.Interfaces;
using WebAPIDynamicExample.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WebAPIDynamicExample.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private IWeatherForecastManager WeatherForeCastManager { get; set; }

        public WeatherForecastController(IWeatherForecastManager weatherforecastmanager)
        {
            WeatherForeCastManager = weatherforecastmanager;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            return WeatherForeCastManager.GetWeatherForecast();
        }
    }
}
