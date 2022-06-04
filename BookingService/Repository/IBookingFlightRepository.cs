using BookingService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingService.Repository
{
    public interface IBookingFlightRepository
    {
        List<FlightBooking> GetFlightBooking();

        FlightBooking GetFlightBookingByNo(int flightbookingNo);

        int SaveFlightBooking(FlightBooking flightBooking);

        int DeleteFlightBooking(int flightbookingNo);

        int UpdateFlightbooking(FlightBooking flightBooking);
        

    }
}
