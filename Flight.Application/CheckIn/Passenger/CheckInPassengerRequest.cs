using System.ComponentModel.DataAnnotations;

namespace Flight.Application.CheckIn.Passenger
{
    public class CheckInPassengerRequest
    {
        [Required]
        public CheckInPassengerDto Passenger { get; set; }
    }
}