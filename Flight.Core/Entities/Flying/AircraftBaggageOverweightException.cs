using System;
using Flight.Core.Values;

namespace Flight.Core.Entities.Flying
{
    internal class AircraftBaggageOverweightException : InvalidOperationException
    {
        public Flight Flight { get; }
        public PassengerId PassengerId { get; }

        public AircraftBaggageOverweightException(Flight flight, PassengerId passengerId)
            : base($"Passenger [{passengerId}] can't check in baggage to the flight [{flight}] due to overweight.")
        {
            Flight = flight;
            PassengerId = passengerId;
        }
    }
}