namespace Flight.Core.Values
{
    public class FlightId
    {
        private readonly long value;

        private FlightId(long id)
        {
            this.value = id;
        }

        public static FlightId Of(long id)
        {
            return new FlightId(id);
        }

        public override string ToString()
        {
            return value.ToString();
        }

        protected bool Equals(FlightId other)
        {
            return value == other.value;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((FlightId) obj);
        }

        public override int GetHashCode()
        {
            return value.GetHashCode();
        }

        public static bool operator ==(FlightId left, FlightId right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(FlightId left, FlightId right)
        {
            return !Equals(left, right);
        }
    }
}