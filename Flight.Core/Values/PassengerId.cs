using System;

namespace Flight.Core.Values
{
    public class PassengerId
    {
        private readonly long value;

        private PassengerId(long id)
        {
            this.value = id;
        }

        public static PassengerId Of(long id)
        {
            return new PassengerId(id);
        }

        public override string ToString()
        {
            return value.ToString();
        }

        protected bool Equals(PassengerId other)
        {
            return value == other.value;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((PassengerId) obj);
        }

        public override int GetHashCode()
        {
            return value.GetHashCode();
        }

        public static bool operator ==(PassengerId left, PassengerId right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(PassengerId left, PassengerId right)
        {
            return !Equals(left, right);
        }
    }
}