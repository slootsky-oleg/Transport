using System;
using System.Collections.Generic;
using System.Linq;
using Flight.Core.Values;

namespace Flight.Core.Entities.Flying
{
    public class CheckedInBaggage
    {
        public FlightId FlightId { get; }
        public PassengerId PassengerId { get; }

        private readonly IList<Bag> baggage;
        public IReadOnlyList<Bag> Bags => baggage.ToList();

        public BaggageLimits Limits { get; }

        public CheckedInBaggage(Flight flight, Passenger passenger, BaggageLimits baggageLimits)
        {
            if (flight == null) throw new ArgumentNullException(nameof(flight));
            if (passenger == null) throw new ArgumentNullException(nameof(passenger));

            baggage = new List<Bag>();

            PassengerId = PassengerId.Of(passenger.Id);
            FlightId = FlightId.Of(flight.Id);

            Limits = baggageLimits ?? throw new ArgumentNullException(nameof(baggageLimits));
        }

        public void CheckIn(Bag bag)
        {
            //Consider refactoring towards IServiceClassValidator[]
            ValidateCount();
            ValidateWeight(bag);

            baggage.Add(bag);
        }

        private void ValidateWeight(Bag bag)
        {
            var loadedWeight = baggage.Sum(b => b.Weight);
            if (loadedWeight + bag.Weight > Limits.Weight)
            {
                throw new PassengerBaggageNotAllowed($"Passenger [{PassengerId}] exceeded allowed baggage weight [{Limits.Weight}].");
            }
        }

        private void ValidateCount()
        {
            if (baggage.Count > Limits.Count)
            {
                throw new PassengerBaggageNotAllowed($"Passenger [{PassengerId}] exceeded allowed bag number [{Limits.Count}].");
            }
        }
    }
}