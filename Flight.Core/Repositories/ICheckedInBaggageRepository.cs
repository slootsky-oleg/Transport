using Flight.Core.Entities.Flying;
using Flight.Core.Entities.Flying.Cargo;

namespace Flight.Core.Repositories
{
    public interface ICheckedInBaggageRepository
    {
        PassengerBaggage Get(long flightId, long passengerId);
        long Save(PassengerBaggage emptyBaggage);
    }
}