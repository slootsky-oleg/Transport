using System;

namespace Flight.Core.Entities.Flight
{
    internal class FlightIsOverbookedException : InvalidOperationException
    {
        public Flight Flight { get; }
        public Passenger OddPassenger { get; }

        public FlightIsOverbookedException(Flight flight, Passenger oddPassenger)
            : base($"Flight [{flight}] is overbooked. Passenger [{oddPassenger}] can't be checked in.")
        {
            Flight = flight;
            OddPassenger = oddPassenger;
        }
    }
}