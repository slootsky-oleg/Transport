using System.ComponentModel.DataAnnotations;

namespace Flight.Application.CheckIn.Bag
{
    public class RegisterPassengerBagRequest
    {
        [Required]
        public RegisteringBagDto Bag { get; set; }
    }
}