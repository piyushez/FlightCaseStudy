using BookingService.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingService.DbContexts
{
    public class FlightBookingDbContext:DbContext
    {
        public FlightBookingDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<FlightBooking> FlightBooking { get; set; }

        
    }
}
