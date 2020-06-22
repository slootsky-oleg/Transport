using Flight = Flight.Core.Entities.Flight.Flight;

namespace Flight.Core.Repositories
{
    public interface IFlightRepository
    {
        Entities.Flight.Flight GetById(in long flightId);
        void Save(Entities.Flight.Flight flight);
    }
}