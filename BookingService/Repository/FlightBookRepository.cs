using BookingService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingService.Repository
{
    public class FlightBookRepository : IFlightBookRepository
    {
        private readonly BookingDbContext context;
        public FlightBookRepository(BookingDbContext context)
        {
            this.context = context;
        }
        public FlightBookingTbl BookTicket(FlightBookingTbl tblFlightBook)
        {
            
            Random rnd = new Random();
            int pnrNumber = rnd.Next(100000, 999999);
            tblFlightBook.PnrNumber =tblFlightBook.PassengerName.Substring(0,2) + pnrNumber+tblFlightBook.FlightNumber;
           
            context.FlightBookingTbl.Add(tblFlightBook);
            context.SaveChanges();
            if (tblFlightBook.isCouponApplied)
            {
                CouponTransTbl couponTrans = new CouponTransTbl();
                couponTrans.CouponCode = tblFlightBook.CouponCode;
                couponTrans.UserEmail = tblFlightBook.LoggedInUserEmail;
                couponTrans.UsedDate = DateTime.Now;
                context.CouponTransTbl.Add(couponTrans);
                context.SaveChanges();
            }
         
            FlightBookingTbl objRow = context.FlightBookingTbl.Where(a => a.Id.Equals(tblFlightBook.Id)).FirstOrDefault();
            return objRow;
        }
        public int CancelTicket(string pNRNumber)
        {
            try
            {
                var tblFlightBook = context.FlightBookingTbl.Find(pNRNumber);
                if (tblFlightBook != null){
                    var hours = (tblFlightBook.FlightDate - DateTime.Now).Hours;
                    if (hours >= 24)
                    {
                        context.FlightBookingTbl.Remove(tblFlightBook);
                        return context.SaveChanges();
                    }
                    else
                    {
                        throw new Exception("You can't cancel the ticket");
                    }
                }
                else
                {
                    throw new Exception("Booking details not available");
                }
               
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
           
            
           
        }
        public IEnumerable<FlightBookingTbl> HistoryTickets(string UserEmail)
        {
            try
            {
                List<FlightBookingTbl> tblFlightBook = new List<FlightBookingTbl>();
                tblFlightBook = context.FlightBookingTbl
                    ?.Where(x=>x.LoggedInUserEmail.Equals(UserEmail))?.ToList();
                return tblFlightBook;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public int AddCouponDetails(CouponTbl couponTbl)
        {
            try
            {
                var data = context.CouponTbl?.
                    Where(a => a.CouponCode == couponTbl.CouponCode).FirstOrDefault();
                if (data != null)
                {
                    throw new Exception("Coupon already exists");
                }
                else
                {
                    context.CouponTbl.Add(couponTbl);
                    return context.SaveChanges();
                }

            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public int ApplyCoupon(string couponCode)
        {
            try
            {
                var data = context.CouponTbl.Find(couponCode);
                if (data != null)
                {
                    if(data.ExpirationDate< DateTime.Now)
                    {
                        throw new Exception("Coupon is not valid");
                    }
                    return data.Amount;
                }
                else
                {
                    throw new Exception("Coupon Code not available");
                }
              
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        } 
        public List<CouponTbl> GetCouponList()
        {
            try
            {
                var data = context.CouponTbl.ToList()?.Where(a => a.ExpirationDate >= DateTime.Now)?.ToList();
                return data;
            }catch(Exception ex)
            {
                throw;
            }

        }
    }
}
