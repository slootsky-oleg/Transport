using System;

namespace Flight.Core.Entities.Flying
{
    public class PassengerBaggageNotAllowed : InvalidOperationException
    {
        public PassengerBaggageNotAllowed(string s)
        {
        }
    }
}