namespace Flight.Application.Exceptions
{
    public class CheckedInBaggageNotFoundException : EntityNotFoundException
    {
        public CheckedInBaggageNotFoundException(in long flightId, in long passengerId)
            : base($"Passenger [{passengerId}] is not checked into flight [{flightId}].")
        {
        }
    }
}