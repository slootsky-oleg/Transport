using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Flight.Application.CheckIn
{
    public class CheckInRequest
    {
        [Required]
        public PassengerDto Passenger { get; set; }
    }

    public class PassengerDto
    {
        public long Id { get; }
        public IList<BaggageDto> Baggage { get; set; }
    }

    public class BaggageDto
    {
        public int Weight { get; }
    }
}