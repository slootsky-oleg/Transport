using System;
using System.Collections.Generic;
using System.Linq;
using Flight.Core.Values;

namespace Flight.Core.Entities.Flying.Cargo
{
    public class CheckedInBaggage
    {
        public FlightId FlightId { get; }
        public PassengerId PassengerId { get; }

        private readonly IList<CheckedInBag> baggage;
        public IReadOnlyList<CheckedInBag> Bags => baggage.ToList();

        public BaggageLimits Limits { get; }

        public CheckedInBaggage(Flight flight, Passenger passenger, BaggageLimits baggageLimits)
        {
            if (flight == null) throw new ArgumentNullException(nameof(flight));
            if (passenger == null) throw new ArgumentNullException(nameof(passenger));

            baggage = new List<CheckedInBag>();

            PassengerId = PassengerId.Of(passenger.Id);
            FlightId = FlightId.Of(flight.Id);

            Limits = baggageLimits ?? throw new ArgumentNullException(nameof(baggageLimits));
        }

        public Guid CheckIn(int weight)
        {
            //Consider refactoring towards IServiceClassValidator[]
            ValidateCount();
            ValidateWeight(weight);

            var bagFlightGuid = Guid.NewGuid();
            var bag = new CheckedInBag(PassengerId, bagFlightGuid, weight);
            baggage.Add(bag);

            return bag.Guid;
        }

        private void ValidateWeight(int weight)
        {
            var loadedWeight = baggage.Sum(b => b.Weight);
            if (loadedWeight + weight > Limits.Weight)
            {
                throw new PassengerBaggageNotAllowedException($"Passenger [{PassengerId}] exceeded allowed baggage weight [{Limits.Weight}].");
            }
        }

        private void ValidateCount()
        {
            if (baggage.Count > Limits.Count)
            {
                throw new PassengerBaggageNotAllowedException($"Passenger [{PassengerId}] exceeded allowed bag number [{Limits.Count}].");
            }
        }
    }
}