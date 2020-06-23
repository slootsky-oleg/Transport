using System;
using Flight.Application.CheckIn;
using Flight.Application.CheckIn.Bag;
using Flight.Application.CheckIn.Passenger;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Flight.API.Controllers.CheckIn
{
    [ApiController]
    [Route("flights/{flightId:long}/passengers")]
    public class PassengerCheckInController : ControllerBase
    {
        private readonly ILogger<PassengerCheckInController> _logger;

        public PassengerCheckInController(ILogger<PassengerCheckInController> logger)
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
        [Route("")]
        public Guid CheckInPassenger(
            [FromServices] CheckInPassenger interactor,
            long flightId, 
            CheckInPassengerRequest passengerRequest)
        {
            var boardingPassGuid = interactor.Execute(flightId, passengerRequest);
            
            return boardingPassGuid;
        }

        [HttpPost]
        [Route("{passengerId:long}/bags")]
        public IActionResult CheckInBag([FromServices] CheckInBag interactor,
            long flightId,
            long passengerId,
            CheckInBagRequest passengerRequest)
        {
            interactor.Execute(flightId, passengerId, passengerRequest);
            return Ok();
        }

    }
}
