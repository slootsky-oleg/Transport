using System;
using Flight.Application.Exceptions;
using Flight.Core.Entities.Flying;
using Flight.Core.Entities.Flying.Cargo;
using Flight.Core.Repositories;

namespace Flight.Application.Passengers.StartRegistration
{
    public class StartPassengerRegistration
    {
        private readonly IFlightRepository flightRepository;
        private readonly IPassengerRepository passengerRepository;
        private readonly IBaggageLimitsRepository baggageLimitsRepository;
        private readonly ICheckedInBaggageRepository baggageRepository;

        public StartPassengerRegistration(
            IFlightRepository flightRepository, 
            IPassengerRepository passengerRepository,
            IBaggageLimitsRepository baggageLimitsRepository,
            ICheckedInBaggageRepository baggageRepository)
        {
            this.flightRepository = flightRepository;
            this.passengerRepository = passengerRepository;
            this.baggageLimitsRepository = baggageLimitsRepository;
            this.baggageRepository = baggageRepository;
        }

        public Guid Execute(long flightId, StartPassengerRegistrationRequest passengerRequest)
        {
            var flight = flightRepository.GetById(flightId)
                         ?? throw new FlightNotFoundException(flightId);

            var passengerId = passengerRequest.Passenger.Id;
            var passenger = passengerRepository.GetById(passengerId)
                            ?? throw new PassengerNotFoundException(passengerId);

            var baggageLimits = baggageLimitsRepository.GetByServiceClass(flight.FlightNumber, passenger.ServiceClass);
            //TODO: consider creating in Flight / factory
            //TODO: can be used to implement baggage reservation
            var emptyBaggage = new PassengerBaggage(flight, passenger, baggageLimits);

            var boardingPassGuid = flight.CheckIn(passenger);

            //Transactional
            flightRepository.Save(flight);
            baggageRepository.Save(emptyBaggage);

            return boardingPassGuid;
        }
    }
}
