namespace Flight.Core.Repositories
{
    public interface IFlightRepository
    {
        Entities.Flying.Flight GetById(in long flightId);
        void Save(Entities.Flying.Flight flight);
    }
}