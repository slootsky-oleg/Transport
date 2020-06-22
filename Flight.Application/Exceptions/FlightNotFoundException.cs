namespace Flight.Application.Exceptions
{
    public class FlightNotFoundException : EntityNotFoundException
    {
        public long Id { get; }

        public FlightNotFoundException(long id)
            : base($"Flight [{id}] not found.")
        {
            Id = id;
        }
    }
}