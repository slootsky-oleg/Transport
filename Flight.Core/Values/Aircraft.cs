namespace Flight.Core.Values
{
    public class Aircraft
    {
        public string Type { get; }
        public int PassengerCapacity { get; }
        public int MaxCargoWeight { get; }

        public Aircraft(string type, int passengerCapacity, int maxCargoWeight)
        {
            Type = type;
            PassengerCapacity = passengerCapacity;
            MaxCargoWeight = maxCargoWeight;
        }
    }
}