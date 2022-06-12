using BookingService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingService.Repository
{
    public interface IFlightBookRepository
    {
        FlightBookingTbl BookTicket(FlightBookingTbl tblFlightBook);
        public int CancelTicket(string pNRNumber);

        IEnumerable<FlightBookingTbl> HistoryTickets(string UserEmail);
       
        int AddCouponDetails(CouponTbl couponTbl);
       
        int ApplyCoupon(string couponCode);
        
        List<CouponTbl> GetCouponList();
    }
}
