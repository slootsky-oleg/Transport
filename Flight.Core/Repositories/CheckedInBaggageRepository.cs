using Flight.Core.Entities.Flying;

namespace Flight.Core.Repositories
{
    public interface ICheckedInBaggageRepository
    {
        CheckedInBaggage Get(long flightId, long passengerId);
        long Save(CheckedInBaggage emptyBaggage);
    }
}