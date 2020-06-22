using System;

namespace Flight.Core.Values
{
    public class FlightNumber
    {
        private readonly string value;

        public FlightNumber(string flightNumber)
        {
            if (string.IsNullOrWhiteSpace(flightNumber))
            {
                throw new ArgumentNullException(nameof(flightNumber));
            }

            this.value = flightNumber;
        }

        public override string ToString()
        {
            return value;
        }
    }
}