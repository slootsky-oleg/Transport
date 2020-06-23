using System;
using Flight.Core.Values;

namespace Flight.Core.Entities.Flying
{
    public class CheckedInBag
    {
        public PassengerId PassengerId { get; set; }
        public Guid Guid { get; }
        public int Weight { get; }

        public CheckedInBag(PassengerId passengerId, Guid guid, int weight)
        {
            PassengerId = passengerId;
            Guid = guid;
            Weight = weight;
        }
    }
}