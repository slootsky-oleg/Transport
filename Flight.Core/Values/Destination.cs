using System;
using Flight.Core.Entities;

namespace Flight.Core.Values
{
    public class Destination
    {
        public Airport Airport { get; }
        public DateTime ScheduledTime { get; }

        public Destination(Airport airport, DateTime scheduledTime)
        {
            Airport = airport ?? throw new ArgumentNullException(nameof(airport));
            ScheduledTime = scheduledTime;
        }
    }
}