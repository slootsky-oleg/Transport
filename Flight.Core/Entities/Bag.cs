using System;

namespace Flight.Core.Entities
{
    public class Bag
    {
        public Passenger Passenger { get; }
        public Guid Guid { get; }
        public int Weight { get; }

        public Bag(Passenger passenger, Guid guid, int weight)
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
            Passenger = passenger;
        }
    }
}