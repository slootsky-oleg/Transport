using System;

namespace Flight.Core.Entities.Flying.Cargo
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