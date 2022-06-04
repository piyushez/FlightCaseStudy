using BookingService.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BookingService.Models
{
    public class FlightBooking
    {
        [Key, Required, DatabaseGenerated(DatabaseGeneratedOption.None)]

        public int Id { get; set; }
        public string FlightNumber { get; set; }
        public string Name { get; set; }
        public string EmailId { get; set; }
        public string Meal { get; set; }
        public string Pnr { get; set; }

        public virtual Passanger Passanger{get;set;}

    }
}
