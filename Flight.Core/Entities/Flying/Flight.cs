using System;
using System.Collections.Generic;
using System.Linq;
using Flight.Core.Values;

namespace Flight.Core.Entities.Flying
{
    public class Flight
    {
        private readonly IList<CheckedInPassenger> passengers;
        private readonly IList<CargoItem> cargo;

        public long Id { get; }
        public Aircraft Aircraft { get; }
        public FlightNumber FlightNumber { get; }
        public Departure Departure { get; }
        public Destination Destination { get; }

        public IReadOnlyList<CheckedInPassenger> Passengers => passengers.ToList();
        public IReadOnlyList<CargoItem> Cargo => cargo.ToList();

        public Flight(long id, FlightNumber flightNumber, Departure departure, Destination destination, Aircraft aircraft)
        {
            passengers = new List<CheckedInPassenger>();
            cargo = new List<CargoItem>();

            Id = id;

            FlightNumber = flightNumber ?? throw new ArgumentNullException(nameof(flightNumber));
            Departure = departure ?? throw new ArgumentNullException(nameof(departure));
            Destination = destination ?? throw new ArgumentNullException(nameof(destination));
            Aircraft = aircraft ?? throw new ArgumentNullException(nameof(aircraft));
        }

        public Guid CheckIn(Passenger passenger)
        {
            if (passengers.Count == Aircraft.PassengerCapacity)
            {
                throw new FlightIsOverbookedException(this, passenger);
            }

            var checkedInPassenger = new CheckedInPassenger(passenger);
            passengers.Add(checkedInPassenger);

            return checkedInPassenger.BoardingPassGuid;
        }

        public void CheckIn(CheckedInBaggage baggage)
        {
            ValidateCanLoadBaggage(baggage);

            foreach (var bag in baggage.Bags)
            {
                var cargoItem = new CargoItem(bag);
                cargo.Add(cargoItem);
            }
        }

        private void ValidateCanLoadBaggage(CheckedInBaggage baggage)
        {
            var baggageWeight = baggage.Bags.Sum(b => b.Weight);
            var cargoWeight = cargo.Sum(c => c.Weight);
            if (cargoWeight + baggageWeight > Aircraft.MaxCargoWeight)
            {
                throw new AircraftBaggageOverweightException(this, baggage.PassengerId);
            }
        }
    }
}