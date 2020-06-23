using System;
using Flight.Core.Values;

namespace Flight.Core.Entities.Flying
{
    public class CheckedInBag
    {
        public PassengerId PassengerId { get; set; }
        public Guid Guid { get; }
        public int Weight { get; }

        public CheckedInBag(PassengerId passengerId, Bag bag)
        {
            PassengerId = passengerId;
            Guid = bag.Guid;
            Weight = bag.Weight;
        }
    }
}