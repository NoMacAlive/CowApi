using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HalterExercise.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace HalterExercise.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CowController : ControllerBase
    {
        private readonly ILogger<CowController> _logger;
        private List<Cow> cows = new List<Cow>();

        public CowController(ILogger<CowController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {

        }
    }
}
