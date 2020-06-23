using System.ComponentModel.DataAnnotations;

namespace Flight.Application.Passengers.RegisterBag
{
    public class RegisterPassengerBagRequest
    {
        [Required]
        public RegisteringBagDto Bag { get; set; }
    }
}