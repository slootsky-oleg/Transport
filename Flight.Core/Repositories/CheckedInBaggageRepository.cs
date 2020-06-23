using Flight.Core.Entities.Flying;

namespace Flight.Core.Repositories
{
    public interface ICheckedInBaggageRepository
    {
        CheckedInBaggage GetByPassengerId(long passengerId);
        long Save(CheckedInBaggage emptyBaggage);
    }
}