using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WeatherAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] NigeriaSummaries = new[]
        {
            "Harmattan", "Rainy Season", "Dry Season", "Humid", "Sunny", "Thunderstorm"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = GetRandomTemperature(rng),
                Summary = NigeriaSummaries[rng.Next(NigeriaSummaries.Length)]
            })
            .ToArray();
        }

        private int GetRandomTemperature(Random rng)
        {
            // Assuming typical Nigeria temperature range
            return rng.Next(20, 40); // Temperatures in Celsius
        }
    }
}
