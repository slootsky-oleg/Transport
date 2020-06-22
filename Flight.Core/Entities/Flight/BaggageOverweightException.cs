using System;

namespace Flight.Core.Entities.Flight
{
    internal class BaggageOverweightException : InvalidOperationException
    {
        public Flight Flight { get; }
        public Passenger Passenger { get; }

        public BaggageOverweightException(Flight flight, Passenger passenger)
            : base($"Passenger [{passenger}] can't check in baggage to the flight [{flight}].")
        {
            Flight = flight;
            Passenger = passenger;
        }
    }
}