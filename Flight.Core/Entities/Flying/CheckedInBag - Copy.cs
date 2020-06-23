using System;
using Flight.Core.Values;

namespace Flight.Core.Entities.Flying
{
    public class CargoItem
    {
        public Guid Guid { get; }
        public int Weight { get; }

        public CargoItem(CheckedInBag bag)
        {
            Guid = bag.Guid;
            Weight = bag.Weight;
        }
    }
}