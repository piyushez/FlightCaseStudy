using BookingService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingService.Repository
{
    public interface IFlightBookingRepository
    {
        List<FlightBooking> GetFlightBooking();

        FlightBooking GetFlightBookingByNo(string flightbookingNo);

        int SaveFlightBooking(FlightBooking flightBooking);

        int DeleteFlightBooking(string flightbookingNo);

        int UpdateFlightbooking(FlightBooking flightBooking);
        

    }
}
