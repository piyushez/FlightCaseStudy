using BookingService.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BookingService.Models
{
    public class Passanger
    {
        [Key]
        public int PassangerId { get; set; }
        public string PassangerName { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }

        [ForeignKey("Id")]
        public int BookingId { get; set; }

        public virtual FlightBooking FlightBooking { get; set; }
    }
}
