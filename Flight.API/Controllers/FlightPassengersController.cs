using System;
using Flight.Application.CheckIn.Bag;
using Flight.Application.CheckIn.Passenger;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Flight.API.Controllers
{
    [ApiController]
    [Route("flights/{flightId:long}/passengers")]
    public class FlightPassengersController : ControllerBase
    {
        private readonly ILogger<FlightPassengersController> _logger;

        public FlightPassengersController(ILogger<FlightPassengersController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        [Route("")]
        public Guid StartRegistration(
            [FromServices] StartPassengerRegistration interactor,
            long flightId, 
            StartPassengerRegistrationRequest passengerRequest)
        {
            var boardingPassGuid = interactor.Execute(flightId, passengerRequest);
            
            return boardingPassGuid;
        }

        [HttpPost]
        [Route("{passengerId:long}/bags")]
        public IActionResult LoadBag([FromServices] RegisterPassengerBag interactor,
            long flightId,
            long passengerId,
            RegisterPassengerBagRequest passengerRequest)
        {
            interactor.Execute(flightId, passengerId, passengerRequest);
            return Ok();
        }

        [HttpPut]
        [Route("{passengerId:long}/check-in")]
        public IActionResult FinishRegistration(
            [FromServices] CheckInPassenger interactor,
            long flightId,
            long passengerId)
        {
            interactor.Execute(flightId, passengerId);
            
            return Ok();
        }
    }
}
