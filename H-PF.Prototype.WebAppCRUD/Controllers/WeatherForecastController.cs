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
            _logger.WarningDisplayed("WarningDisplayed", new Exception("Exception Warning"), "Boom");
            _logger.WarningAdvanced("WarningAdvanced", new Exception("Exception Warning"), "Boom");
            _logger.WarningHidden("WarningHidden", new Exception("Exception Warning"), "Boom");
            _logger.ErrorDisplayed("ErrorDisplayed", new Exception("Exception Error"), "KAKABoom");
            _logger.ErrorAdvanced("ErrorAdvanced", new Exception("Exception Error"), "KAKABoom");
            _logger.ErrorHidden("ErrorHidden", new Exception("Exception Error"), "KAKABoom");
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
