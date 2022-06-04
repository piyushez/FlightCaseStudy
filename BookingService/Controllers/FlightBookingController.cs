using BookingService.Models;
using BookingService.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingService.Controllers
{
    public class FlightBookingController : Controller
    {
        private IFlightBookingRepository _flightBooking;
        public FlightBookingController(IFlightBookingRepository flightBooking)
        {
            _flightBooking = flightBooking;
        }


        [HttpGet]
        [Route("/flight/getFlightList")]
        public IActionResult GetFlightList()
        {
            try
            {
                List<FlightBooking>  lstFlights = _flightBooking.GetFlightBooking();
                if (lstFlights != null && lstFlights.Count() > 0)
                {
                    return Json(new { data = lstFlights, isSuccess = true });
                }
                else
                {
                    return Json(new { data = "No Details Found", isSuccess = true });
                }
            }
            catch (Exception ex)
            {
                return Json(new { data = ex.Message, isSuccess = false });
            }
        }

        [HttpGet]
        [Route("/flight/getflightbyno/{flightNumber}")]
        public IActionResult GetFlightByNo(string flightNumber)
        {
            FlightBooking flightDetails = new FlightBooking();
            try
            {

                flightDetails = _flightBooking.GetFlightBookingByNo(flightNumber);
                if (flightDetails != null)
                {
                    return Json(new { data = flightDetails, isSuccess = true });
                }
                else
                {
                    return Json(new { data = "No Record Found", isSuccess = true });
                }
            }
            catch (Exception ex)
            {
                return Json(new { data = ex.Message, isSuccess = false });
            }
        }

        [HttpPost]
        [Route("/flight/addflightDetails")]
        public IActionResult AddFlightDetails([FromBody] FlightBooking flight)
        {

            try
            {
                var result = _flightBooking.SaveFlightBooking(flight);
                if (result > -1)
                {
                    return Json(new { data = "Data Saved Succesfully", isSuccess = true });
                }
                else
                {
                    return Json(new { data = "Some error occured while add details", isSuccess = true });
                }
            }
            catch (Exception ex)
            {
                return Json(new { data = ex.Message, isSuccess = false });
            }
        }

        public IActionResult UpdateFlightDetails(FlightBooking flight)
        {

            try
            {

                var result = _flightBooking.UpdateFlightbooking(flight);
                if (result > -1)
                {
                    return Json(new { data = "Data Update successfully", isSuccess = true });
                }
                else
                {
                    return Json(new { data = "Some error occured while update details", isSuccess = true });
                }
            }
            catch (Exception ex)
            {
                return Json(new { data = ex.Message, isSuccess = false });
            }
        }

        [HttpDelete]
        [Route("/flight/deleteflightbyno/{flightNumber}")]
        public IActionResult DeleteFlightByNo(string flightNumber)
        {
            try
            {
                int res = _flightBooking.DeleteFlightBooking(flightNumber);

                if (res > -1)
                {
                    return Json(new { data = "Successfully Deleted", isSuccess = true });
                }
                else
                {
                    return Json(new { data = "Some error occured while delete FlightBooking", isSuccess = true });
                }
            }
            catch (Exception ex)
            {
                return Json(new { data = ex.Message, isSuccess = false });
            }
        }
    }
}
