namespace Flight.Application.Exceptions
{
    public class PassengerNotFoundException : EntityNotFoundException
    {
        public long PassengerId { get; }

        public PassengerNotFoundException(long passengerId)
            : base($"Passenger [{passengerId}] not found.")
        {
            PassengerId = passengerId;
        }
    }
}