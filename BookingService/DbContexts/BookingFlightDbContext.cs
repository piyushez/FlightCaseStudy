using BookingService.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingService.DbContexts
{
    public class BookingFlightDbContext:DbContext
    {
        public BookingFlightDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<FlightBooking> flightBookings { get; set; }
    }
}
