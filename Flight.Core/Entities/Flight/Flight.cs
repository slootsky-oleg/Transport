using System;
using System.Collections.Generic;
using System.Linq;
using Flight.Core.Services.Flight;
using Flight.Core.Values;

namespace Flight.Core.Entities.Flight
{
    public class Flight
    {
        private IList<Passenger> passengers;
        private IList<Baggage> cargo;

        public long Id { get; }
        public Aircraft Aircraft { get; }
        public FlightNumber FlightNumber { get; }
        public Departure Departure { get; }
        public Destination Destination { get; }
        public int PassengerCapacity => Aircraft.PassengerCapacity;

        public IReadOnlyList<Passenger> Passengers => passengers.ToList();
        public IReadOnlyList<Baggage> Cargo => cargo.ToList();

        public Flight(long id, FlightNumber flightNumber, Departure departure, Destination destination, Aircraft aircraft)
        {
            Id = id;

            FlightNumber = flightNumber ?? throw new ArgumentNullException(nameof(flightNumber));;
            Departure = departure ?? throw new ArgumentNullException(nameof(departure));
            Destination = destination ?? throw new ArgumentNullException(nameof(destination));
            Aircraft = aircraft ?? throw new ArgumentNullException(nameof(aircraft));
        }

        public void CheckIn(Passenger passenger)
        {
            if (passengers.Count == Aircraft.PassengerCapacity)
            {
                throw new FlightIsOverbookedException(this, passenger);
            }

            passengers.Add(passenger);
        }

        public void LoadBaggage(Passenger passenger, IEnumerable<Baggage> baggage, 
            IServiceClassBaggageValidationFactory baggageValidationFactory)
        {
            var baggageList = baggage.ToList();

            var baggageValidator = baggageValidationFactory.Create(passenger.ServiceClass);
            baggageValidator.Validate(baggageList);

            ValidateCanLoadBaggage(passenger, baggageList);
        }

        private void ValidateCanLoadBaggage(Passenger passenger, IEnumerable<Baggage> baggage)
        {
            var baggageWeight = baggage.Sum(b => b.Weight);
            var cargoWeight = cargo.Sum(c => c.Weight);
            if (cargoWeight + baggageWeight > Aircraft.MaxCargoWeight)
            {
                throw new BaggageOverweightException(this, passenger);
            }
        }
    }
}