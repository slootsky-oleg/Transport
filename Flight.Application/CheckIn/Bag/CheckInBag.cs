using System;
using Flight.Application.Exceptions;
using Flight.Core.Repositories;

namespace Flight.Application.CheckIn.Bag
{
    public class CheckInBag
    {
        private readonly ICheckedInBaggageRepository checkedInBaggageRepository;

        public CheckInBag(ICheckedInBaggageRepository checkedInBaggageRepository)
        {
            this.checkedInBaggageRepository = checkedInBaggageRepository;
        }

        public Guid Execute(long flightId, long passengerId, CheckInBagRequest bagRequest)
        {
            var baggage = checkedInBaggageRepository.Get(flightId, passengerId)
                    ?? throw new CheckedInBaggageNotFoundException(flightId, passengerId);

            var bagDto = bagRequest.Bag;

            var bagGuid = baggage.CheckIn(bagDto.Weight);

            checkedInBaggageRepository.Save(baggage);

            return bagGuid;
        }
    }
}
