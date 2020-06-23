namespace Flight.Application.Exceptions
{
    public class BaggageNotFoundException : EntityNotFoundException
    {
        public BaggageNotFoundException(long flightId, long passengerId)
            : base($"Passenger [{passengerId}] is not checked into flight [{flightId}].")
        {
        }
    }
}