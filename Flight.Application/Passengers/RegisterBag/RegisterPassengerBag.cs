using System;
using Flight.Application.Exceptions;
using Flight.Core.Repositories;

namespace Flight.Application.CheckIn.Bag
{
    public class RegisterPassengerBag
    {
        private readonly ICheckedInBaggageRepository checkedInBaggageRepository;

        public RegisterPassengerBag(ICheckedInBaggageRepository checkedInBaggageRepository)
        {
            this.checkedInBaggageRepository = checkedInBaggageRepository;
        }

        public Guid Execute(long flightId, long passengerId, RegisterPassengerBagRequest passengerBagRequest)
        {
            var baggage = checkedInBaggageRepository.Get(flightId, passengerId)
                    ?? throw new BaggageNotFoundException(flightId, passengerId);

            var bagDto = passengerBagRequest.Bag;

            var bagGuid = baggage.CheckIn(bagDto.Weight);

            checkedInBaggageRepository.Save(baggage);

            return bagGuid;
        }
    }
}
