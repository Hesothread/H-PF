using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using H_PF.ToolLibs.HesoLogger.Domaine;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace H_PF.Prototype.WebAppCRUD.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly IHesoLogger _logger;

        public WeatherForecastController(IHesoLogger logger)
        {
            _logger = logger;
            _logger.ModuleName = "WeatherForecast";
            _logger.InformationDisplayed("InformationDisplayed");
            _logger.InformationAdvanced("InformationAdvanced");
            _logger.InformationHidden("InformationHidden");
            _logger.WarningDisplayed("WarningDisplayed", "Boom", new Exception("Exception Warning"));
            _logger.WarningAdvanced("WarningAdvanced", "Boom", new Exception("Exception Warning"));
            _logger.WarningHidden("WarningHidden", "Boom", new Exception("Exception Warning"));
            _logger.ErrorDisplayed("ErrorDisplayed", "KAKABoom", new Exception("Exception Error"));
            _logger.ErrorAdvanced("ErrorAdvanced", "KAKABoom", new Exception("Exception Error"));
            _logger.ErrorHidden("ErrorHidden", "KAKABoom", new Exception("Exception Error"));
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            _logger.InformationDisplayed("InformationDisplayed");
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
