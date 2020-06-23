using System.ComponentModel.DataAnnotations;

namespace Flight.Application.CheckIn.Bag
{
    public class CheckInBagRequest
    {
        [Required]
        public CheckInBagDto Bag { get; set; }
    }
}