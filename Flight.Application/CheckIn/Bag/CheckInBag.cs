using Flight.Application.Exceptions;
using Flight.Core.Repositories;

namespace Flight.Application.CheckIn.Bag
{
    public class CheckInBag
    {
        private readonly IFlightRepository flightRepository;
        private readonly IPassengerRepository passengerRepository;

        public CheckInBag(IFlightRepository flightRepository, 
            IPassengerRepository passengerRepository)
        {
            this.flightRepository = flightRepository;
            this.passengerRepository = passengerRepository;
        }

        public void Execute(long flightId, long passengerId, CheckInBagRequest bagRequest)
        {
            var flight = flightRepository.GetById(flightId)
                         ?? throw new FlightNotFoundException(flightId);

            var passenger = passengerRepository.GetById(passengerId)
                            ?? throw new PassengerNotFoundException(passengerId);

            //var baggage = passengerDto
            //    .Baggage
            //    .Select(CreateBaggage);

            flight.CheckIn(passenger);

            flightRepository.Save(flight);
        }

        //private static Bag CreateBaggage(BaggageDto dto)
        //{
        //    var guid = Guid.NewGuid();
        //    return new Bag(guid, dto.Weight);
        //}
    }
}
