using BookingManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingManagement.Repository
{
    public interface IFlightBookRepository
    {
        FlightBookingTbl BookTicket(FlightBookingTbl tblFlightBook);
        FlightBookingTbl CancelTicket(string pNRNumber);

        IEnumerable<FlightBookingTbl> HistoryTickets(string UserEmail);
    }
}
