using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingManagement.Models
{
    public class FlightBookingTbl
    {
        public int Id { get; set; }
        public int FlightNumber { get; set; }
        public string Name { get; set; }
        public string EMail { get; set; }
        public string SeatNumber { get; set; }
        public string PassengerName { get; set; }
        public string Gender { get; set; }
        public string Age { get; set; }
        public string Meal { get; set; }
        public string PnrNumber { get; set; }
        public bool ActiveIND { get; set; }
        public DateTime FlightDate { get; set; }
        public string LoggedInUserEmail { get; set; }
       
    }
    public class ApplicationUser : IdentityUser
    {

    }
}
