using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<WeatherForecast>> Get(CancellationToken cancellationToken = default)
        {
            Console.WriteLine("Start Get request");
            try
            {
                await Task.Delay(3000, cancellationToken);
                return GetData();
            }
            catch (OperationCanceledException exception)
            {
                Console.WriteLine(exception);
                return new List<WeatherForecast>();
            }
        }
        [HttpPost]
        public async Task<IEnumerable<WeatherForecast>> Post(CancellationToken cancellationToken = default)
        {
            Console.WriteLine("Start POST request");

            try
            {
                await Task.Delay(3000, cancellationToken);
                return GetData();
            }
            catch (OperationCanceledException exception)
            {
                Console.WriteLine(exception);
                return new List<WeatherForecast>();
            }
        }

        private IEnumerable<WeatherForecast> GetData()
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