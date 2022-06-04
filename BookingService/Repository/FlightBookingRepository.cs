using BookingService.DbContexts;
using BookingService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingService.Repository
{
    public class FlightBookingRepository : IFlightBookingRepository
    {
        public FlightBookingDbContext _flightBookingDbContext;

        public FlightBookingRepository(FlightBookingDbContext flightBookingDbContext)
        {
            _flightBookingDbContext = flightBookingDbContext;
        }
        public List<FlightBooking> GetFlightBooking()
        {
            List<FlightBooking> lstFlightBookings = new List<FlightBooking>();
            try
            {
                lstFlightBookings = _flightBookingDbContext.FlightBooking.ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
            return lstFlightBookings;
        }

        public FlightBooking GetFlightBookingByNo(string flightbookingNo)
        {

            try
            {
                var flightBookData = _flightBookingDbContext.FlightBooking.Find(flightbookingNo);
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
                var flightBookData = _flightBookingDbContext.FlightBooking.Find(flightBooking.FlightNumber);
                if (flightBookData != null)
                {
                    throw new Exception("Flight Details already available");
                }
                else
                {
                    _flightBookingDbContext.FlightBooking.Add(flightBookData);
                    int result = _flightBookingDbContext.SaveChanges();
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
                var flightBookData = _flightBookingDbContext.FlightBooking.Find(flightBooking.FlightNumber);
                if (flightBookData != null)
                {
                    _flightBookingDbContext.FlightBooking.Update(flightBookData);
                    int result = _flightBookingDbContext.SaveChanges();
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
        public int DeleteFlightBooking(string flightbookingNo)
        {
            try
            {
                var flightBookData = _flightBookingDbContext.FlightBooking.Find(flightbookingNo);
                if (flightBookData != null)
                {
                    _flightBookingDbContext.FlightBooking.Remove(flightBookData);
                    int result = _flightBookingDbContext.SaveChanges();
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
