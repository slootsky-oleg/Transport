using System;

namespace Flight.Core.Entities.Flight
{
    public class Baggage
    {
        public Guid Guid { get; }
        public int Weight { get; }

        public Baggage(Guid guid, int weight)
        {
            if (guid == Guid.Empty)
            {
                throw new ArgumentException("Is required.", nameof(guid));
            }
            Guid = guid;

            if (weight <= 0)
            {
                throw new ArgumentException("Is required.", nameof(guid));
            }
            Weight = weight;
        }
    }
}