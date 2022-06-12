using BookingManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingManagement.Repository
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
            tblFlightBook.PnrNumber =tblFlightBook.Name.Substring(0,2) + pnrNumber+tblFlightBook.FlightNumber;
            tblFlightBook.ActiveIND = true;
            tblFlightBook.FlightDate = DateTime.Now;

            context.FlightBookingTbl.Add(tblFlightBook);
            context.SaveChanges();
            FlightBookingTbl objRow = context.FlightBookingTbl.Where(a => a.Id.Equals(tblFlightBook.Id)).FirstOrDefault();
            return objRow;
        }
        public FlightBookingTbl CancelTicket(string pNRNumber)
        {
            //TblFlightBook objInventory = new TblFlightBook();
            var tblFlightBook = context.FlightBookingTbl.Where(a => a.PnrNumber.Equals(Convert.ToInt32(pNRNumber))).FirstOrDefault();
            //var hours = (tblFlightBook.FlightDate - DateTime.Now).Hours;
           // if(hours => 24)
            //{
           // }
            tblFlightBook.ActiveIND = false;
            context.SaveChanges();
            return tblFlightBook;
        }
        public IEnumerable<FlightBookingTbl> HistoryTickets(string UserEmail)
        {
            try
            {
                List<FlightBookingTbl> tblFlightBook = new List<FlightBookingTbl>();
                tblFlightBook = context.FlightBookingTbl
                    .Where(x=>x.LoggedInUserEmail.Equals(UserEmail) 
                    && x.ActiveIND.Equals(true)).ToList();
                return tblFlightBook;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
