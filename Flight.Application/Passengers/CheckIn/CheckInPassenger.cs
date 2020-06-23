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

        public void Execute(long flightId, long passengerId)
        {
            var flight = flightRepository.GetById(flightId)
                         ?? throw new FlightNotFoundException(flightId);

            var baggage = baggageRepository.Get(flightId, passengerId)
                          ?? throw new BaggageNotFoundException(flightId, passengerId);

            flight.CheckIn(baggage);

            flightRepository.Save(flight);
        }
    }
}
