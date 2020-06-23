using System;
using Flight.Application.Exceptions;
using Flight.Core.Entities.Flying;
using Flight.Core.Repositories;

namespace Flight.Application.CheckIn.Passenger
{
    public class CheckInPassenger
    {
        private readonly IFlightRepository flightRepository;
        private readonly IPassengerRepository passengerRepository;
        private readonly IBaggageLimitsRepository baggageLimitsRepository;
        private readonly ICheckedInBaggageRepository baggageRepository;

        public CheckInPassenger(
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

        public Guid Execute(long flightId, CheckInPassengerRequest passengerRequest)
        {
            var flight = flightRepository.GetById(flightId)
                         ?? throw new FlightNotFoundException(flightId);

            var passengerId = passengerRequest.Passenger.Id;
            var passenger = passengerRepository.GetById(passengerId)
                            ?? throw new PassengerNotFoundException(passengerId);

            var baggageLimits = baggageLimitsRepository.GetByServiceClass(flight.FlightNumber, passenger.ServiceClass);

            var boardingPassGuid = flight.CheckIn(passenger);

            //TODO: consider creating in Flight / factory
            var emptyBaggage = new CheckedInBaggage(flight, passenger, baggageLimits);

            //Transactional
            flightRepository.Save(flight);
            baggageRepository.Save(emptyBaggage);

            return boardingPassGuid;
        }
    }
}
