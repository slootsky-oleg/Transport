using System.Collections.Generic;
using Flight.Core.Entities;
using Flight.Core.Entities.Flight;

namespace Flight.Core.Services.Flight
{
    public interface IServiceClassBaggageValidationFactory
    {
        IServiceClassBaggageValidation Create(ServiceClass passengerServiceClass);
    }

    public interface IServiceClassBaggageValidation
    {
        void Validate(IEnumerable<Baggage> baggage);
    }
}