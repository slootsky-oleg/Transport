using System;
using Flight.Core.Entities;

namespace Flight.Core.Values
{
    public class Departure
    {
        public Airport Airport { get; }
        public DateTime ScheduledTime { get; }
        public DateTimeOffset ArrivePrior { get; }

        public Departure(Airport airport, DateTime scheduledTime, DateTimeOffset arrivePrior)
        {
            Airport = airport ?? throw new ArgumentNullException(nameof(airport));
            ScheduledTime = scheduledTime;
            ArrivePrior = arrivePrior;
        }
    }
}