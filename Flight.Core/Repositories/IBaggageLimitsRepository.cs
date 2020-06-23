using Flight.Core.Entities;
using Flight.Core.Entities.Flying;
using Flight.Core.Entities.Flying.Cargo;
using Flight.Core.Values;

namespace Flight.Core.Repositories
{
    public interface IBaggageLimitsRepository
    {
        BaggageLimits GetByServiceClass(FlightNumber flightNumber, ServiceClass serviceClass);
    }
}