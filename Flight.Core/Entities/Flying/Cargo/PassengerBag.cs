using System;
using Flight.Core.Values;

namespace Flight.Core.Entities.Flying.Cargo
{
    public class PassengerBag
    {
        public PassengerId PassengerId { get; }
        public Guid Guid { get; }
        public int Weight { get; }

        public PassengerBag(PassengerId passengerId, Guid guid, int weight)
        {
            PassengerId = passengerId;
            Guid = guid;
            Weight = weight;
        }
    }
}