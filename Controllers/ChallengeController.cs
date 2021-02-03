using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace my_new_app.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ChallengeController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<ChallengeController> _logger;

        public ChallengeController(ILogger<ChallengeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Challenge> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new Challenge
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
