using System.ComponentModel.DataAnnotations;

namespace Flight.Application.Passengers.StartRegistration
{
    public class StartPassengerRegistrationRequest
    {
        [Required]
        public RegisteringPassengerDto Passenger { get; set; }
    }
}