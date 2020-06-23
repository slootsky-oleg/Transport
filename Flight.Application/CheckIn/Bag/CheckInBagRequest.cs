using System.ComponentModel.DataAnnotations;
using Flight.Application.CheckIn.Passenger;

namespace Flight.Application.CheckIn.Bag
{
    public class CheckInBagRequest
    {
        [Required]
        public CheckInBagDto Bag { get; set; }
    }
}