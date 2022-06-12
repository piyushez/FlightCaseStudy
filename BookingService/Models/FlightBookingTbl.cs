using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingService.Models
{
    public class FlightBookingTbl
    {
        public int Id { get; set; }
        public string FlightNumber { get; set; }
       
        public string EMail { get; set; }
        public string SeatNumber { get; set; }
        public string PassengerName { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public string Meal { get; set; }
        public string PnrNumber { get; set; }
       
        public DateTime FlightDate { get; set; }
        public string LoggedInUserEmail { get; set; }
       
        public bool isCouponApplied { get; set; }

        public string CouponCode { get; set; }
    }
    public class ApplicationUser : IdentityUser
    {

    }
}
