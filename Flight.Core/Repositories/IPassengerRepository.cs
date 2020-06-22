using Flight.Core.Entities;

namespace Flight.Core.Repositories
{
    public interface IPassengerRepository
    {
        Passenger GetById(long passengerId);
    }
}