using System.ComponentModel.DataAnnotations;

namespace Flight.Application.CheckIn.Passenger
{
    public class StartPassengerRegistrationRequest
    {
        [Required]
        public RegisteringPassengerDto Passenger { get; set; }
    }
}