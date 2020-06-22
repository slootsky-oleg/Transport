using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Flight.Application.CheckIn;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Flight.API.Controllers
{
    [ApiController]
    [Route("flights")]
    public class FlightController : ControllerBase
    {
        private readonly ILogger<FlightController> _logger;

        public FlightController(ILogger<FlightController> logger)
        {
            _logger = logger;
        }

        //[HttpGet]
        //public IEnumerable<WeatherForecast> Get()
        //{
        //    var rng = new Random();
        //    return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        //    {
        //        Date = DateTime.Now.AddDays(index),
        //        TemperatureC = rng.Next(-20, 55),
        //        Summary = Summaries[rng.Next(Summaries.Length)]
        //    })
        //    .ToArray();
        //}

        [HttpPost]
        [Route("{flightId:long}/check-in")]
        public IActionResult CheckIn(
            [FromServices] CheckIn interactor,
            long flightId, 
            CheckInRequest request)
        {
            interactor.Execute(flightId, request);
            
            return Ok();
        }

        [HttpPost]
        [Route("{flightId:long}/passengers/{passengerId:long}")]
        public IActionResult AddPassengerBaggage()
        {
            return Ok();
        }

    }
}
