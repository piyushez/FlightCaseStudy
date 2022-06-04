using BookingService.DbContexts;
using BookingService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingService.Repository
{
    public class BookingFlightRepository : IBookingFlightRepository
    {
        public BookingFlightDbContext _bookingFlightContext;
        public List<FlightBooking> GetFlightBooking()
        {
            List<FlightBooking> lstFlightBookings = new List<FlightBooking>();
            try
            {
                lstFlightBookings = _bookingFlightContext.flightBookings.ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
            return lstFlightBookings;
        }

        public FlightBooking GetFlightBookingByNo(int flightbookingNo)
        {

            try
            {
                var flightBookData = _bookingFlightContext.flightBookings.Find(flightbookingNo);
                if (flightBookData == null)
                {
                    throw new Exception("No Flight Details available");
                }
                return flightBookData;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public int SaveFlightBooking(FlightBooking flightBooking)
        {
            try
            {
                var flightBookData = _bookingFlightContext.flightBookings.Find(flightBooking.FlightNumber);
                if (flightBookData != null)
                {
                    throw new Exception("Flight Details already available");
                }
                else
                {
                    _bookingFlightContext.flightBookings.Add(flightBookData);
                    int result = _bookingFlightContext.SaveChanges();
                    return result;
                }

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public int UpdateFlightbooking(FlightBooking flightBooking)
        {
            try
            {
                var flightBookData = _bookingFlightContext.flightBookings.Find(flightBooking.FlightNumber);
                if (flightBookData != null)
                {
                    _bookingFlightContext.flightBookings.Update(flightBookData);
                    int result = _bookingFlightContext.SaveChanges();
                    return result;
                }
                else
                {

                    throw new Exception("Flight Details Not Available");
                }

            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public int DeleteFlightBooking(int flightbookingNo)
        {
            try
            {
                var flightBookData = _bookingFlightContext.flightBookings.Find(flightbookingNo);
                if (flightBookData != null)
                {
                    _bookingFlightContext.flightBookings.Remove(flightBookData);
                    int result = _bookingFlightContext.SaveChanges();
                    return result;
                }
                else
                {

                    throw new Exception("Flight Details Not Available");
                }

            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
