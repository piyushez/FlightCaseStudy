using BookingManagement.Models;
using BookingManagement.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingManagement.Controllers
{
   
    public class BookingController : Controller
    {
        private readonly IFlightBookRepository _bookingRepository;
        public BookingController(IFlightBookRepository obj)
        {
            _bookingRepository = obj;
        }
        [HttpPost]
        [Route("Booking/bookTicket")]
        public IActionResult BookTicket([FromBody] FlightBookingTbl tblFlightBook)
        {
           
            try
            {

                var booking = _bookingRepository.BookTicket(tblFlightBook);
                if (booking != null)
                {
                    return Json(new { data = $"Your ticket has been successfully booked and Your PNR Number is: {booking.PnrNumber}", isSuccess = true });
                    
                }
            }
            catch (Exception)
            {

                throw;
            }
            return Json(new { data = "Service not found", isSuccess = false });

        }

        [Route("cancelTicket")]
        [HttpGet]
        public IActionResult CancelTicket(string pNRNumber)
        {
            
            try
            {
                var booking = _bookingRepository.CancelTicket(pNRNumber);
                if (booking != null)
                {
                    return Json(new { data = "Ticket Cancel Successfully. PNR Number is: " + pNRNumber, isSuccess = true });

                   
                }
            }
            catch (Exception ex)
            {
                return Json(new { data = ex.Message, isSuccess = false });

            }
            return Json(new { data = "Service Not Found", isSuccess = false });
        }
        [Route("getHistoryTicketsByUser")]
        [HttpPost]
        public IActionResult HistoryTickets(string userEmail)
        {
            string response = string.Empty;
            try
            {
                var booking = _bookingRepository.HistoryTickets(userEmail);
                if (booking != null)
                {
                    return new OkObjectResult(booking);
                }
            }
            catch (Exception ex)
            {
                response = ex.Message;
            }
            return new NotFoundObjectResult(response);
        }

        

    }
}
