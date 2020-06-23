using System;
using System.Collections.Generic;
using System.Linq;
using Flight.Core.Values;

namespace Flight.Core.Entities.Flying
{
    public class Flight
    {
        private readonly IList<CheckedInPassenger> passengers;
        private readonly IList<CheckedInBag> cargo;

        public long Id { get; }
        public Aircraft Aircraft { get; }
        public FlightNumber FlightNumber { get; }
        public Departure Departure { get; }
        public Destination Destination { get; }
        public int PassengerCapacity => Aircraft.PassengerCapacity;

        public IReadOnlyList<CheckedInPassenger> Passengers => passengers.ToList();
        public IReadOnlyList<CheckedInBag> Cargo => cargo.ToList();

        public Flight(long id, FlightNumber flightNumber, Departure departure, Destination destination, Aircraft aircraft)
        {
            passengers = new List<CheckedInPassenger>();
            cargo = new List<CheckedInBag>();

            Id = id;

            FlightNumber = flightNumber ?? throw new ArgumentNullException(nameof(flightNumber));;
            Departure = departure ?? throw new ArgumentNullException(nameof(departure));
            Destination = destination ?? throw new ArgumentNullException(nameof(destination));
            Aircraft = aircraft ?? throw new ArgumentNullException(nameof(aircraft));
        }

        //TODO: can return boarding pass id
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

        //TODO: can return id
        public void CheckIn(CheckedInBaggage baggage)
        {
            ValidateCanLoadBaggage(baggage);

            var passengerId = baggage.PassengerId;
            foreach (var bag in baggage.Bags)
            {
                var checkedInBag = new CheckedInBag(passengerId, bag);
                cargo.Add(checkedInBag);
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