namespace Flight.Core.Entities.Flying
{
    public class BaggageLimits
    {
        public int Weight { get; }
        public int Count { get; }

        public BaggageLimits(int weight, int count)
        {
            //TODO: > 0
            Weight = weight;
            Count = count;
        }
    }
}