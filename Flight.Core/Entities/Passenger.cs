using System;

namespace Flight.Core.Entities
{
    public class Passenger
    {
        public long Id { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public Passport Passport { get; }
        public ServiceClass ServiceClass { get; set; }

        public Passenger(long id, string firstName, string lastName, Passport passport)
        {
            Id = id;
            FirstName = firstName ?? throw new ArgumentNullException(nameof(firstName));
            LastName = lastName ?? throw new ArgumentNullException(nameof(lastName));
            Passport = passport ?? throw new ArgumentNullException(nameof(passport));
        }
    }

    public class ServiceClass
    {
        public static ServiceClass Economy = new ServiceClass(1, "Economy");

        public int Id { get; }
        public string Name { get; }

        public ServiceClass(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }

    public class Passport
    {
        public string Number { get; }
        public DateTime IssuedOn { get; }
        public DateTime ExpiresOn { get; }
        public Country Country { get; }

        public Passport(string number, DateTime issuedOn, DateTime expiresOn, Country country)
        {
            //TODO: validate fields
            Number = number;
            IssuedOn = issuedOn;
            ExpiresOn = expiresOn;
            Country = country ?? throw new ArgumentNullException(nameof(country));
        }
    }

    public class Country
    {
        public int Code { get; }
        public string Name { get; }

        public Country(int code, string name)
        {
            Code = code;
            Name = name;
        }
    }
}