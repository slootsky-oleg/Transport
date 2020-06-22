using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Flight.Application.Exceptions;
using Flight.Core.Entities;
using Flight.Core.Entities.Flight;
using Flight.Core.Repositories;
using Flight.Core.Services.Flight;

namespace Flight.Application.CheckIn
{
    public class CheckIn
    {
        private readonly IFlightRepository flightRepository;
        private readonly IPassengerRepository passengerRepository;
        private readonly IServiceClassBaggageValidationFactory baggageValidationFactory;

        public CheckIn(IFlightRepository flightRepository, 
            IPassengerRepository passengerRepository,
            IServiceClassBaggageValidationFactory baggageValidationFactory)
        {
            this.flightRepository = flightRepository;
            this.passengerRepository = passengerRepository;
            this.baggageValidationFactory = baggageValidationFactory;
        }

        public void Execute(long flightId, CheckInRequest request)
        {
            var flight = flightRepository.GetById(flightId)
                         ?? throw new FlightNotFoundException(flightId);

            var passengerDto = request.Passenger;
            var passenger = passengerRepository.GetById(passengerDto.Id)
                            ?? throw new PassengerNotFoundException(passengerDto.Id);

            var baggage = passengerDto
                .Baggage
                .Select(CreateBaggage);

            flight.CheckIn(passenger);
            flight.LoadBaggage(passenger, baggage, baggageValidationFactory);

            flightRepository.Save(flight);
        }

        private static Baggage CreateBaggage(BaggageDto dto)
        {
            var guid = Guid.NewGuid();
            return new Baggage(guid, dto.Weight);
        }
    }
}
