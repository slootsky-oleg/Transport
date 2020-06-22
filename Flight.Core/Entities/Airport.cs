using System;

namespace Flight.Core.Entities
{
    public class Airport
    {
        public string Code { get; }

        public Airport(string code)
        {
            if (string.IsNullOrWhiteSpace(code))
            {
                throw new ArgumentNullException(nameof(code));
            }

            Code = code;
        }
    }
}