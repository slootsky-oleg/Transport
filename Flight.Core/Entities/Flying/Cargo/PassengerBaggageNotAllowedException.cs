using System;

namespace Flight.Core.Entities.Flying.Cargo
{
    public class PassengerBaggageNotAllowedException : InvalidOperationException
    {
        public PassengerBaggageNotAllowedException(string s)
        {
        }
    }
}