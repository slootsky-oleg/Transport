using System;
using Flight.Core.Values;

namespace Flight.Core.Entities.Flying
{
    public class CheckedInPassenger
    {
        public PassengerId PassengerId { get; }
        public Guid BoardingPassGuid { get; }

        public CheckedInPassenger(Passenger passenger)
            : this(PassengerId.Of(passenger.Id), Guid.NewGuid())
        {
        }

        public CheckedInPassenger(PassengerId passengerId, Guid boardingPassGuid)
        {
            PassengerId = passengerId ?? throw new ArgumentNullException(nameof(passengerId));
            BoardingPassGuid = boardingPassGuid;
        }
    }
}