using Flight.Core.Entities.Flying;
using Flight.Core.Entities.Flying.Cargo;

namespace Flight.Core.Repositories
{
    public interface ICheckedInBaggageRepository
    {
        CheckedInBaggage Get(long flightId, long passengerId);
        long Save(CheckedInBaggage emptyBaggage);
    }
}