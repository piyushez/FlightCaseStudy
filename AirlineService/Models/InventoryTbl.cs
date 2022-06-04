using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AirlineService.Models
{
    public class InventoryTbl
    {
        [Key]
        public string FlightNumber { get; set; }

        [ForeignKey("AirlineNo")]

        public string AirlineNo { get; set; }
        public string FromPlace { get; set; }
        public string ToPlace { get; set; }
        public DateTime? StartDateTime { get; set; }

        public DateTime? EndDateTime { get; set; }

        public string ScheduleDays { get; set; }
        public string InstrumentUsed { get; set; }
        public int? BusinessClassSeat { get; set; }
        public int? NonBusinessClassSeat { get; set; }

        public decimal? TicketCost { get; set; }
        public int? NoOfRows { get; set; }
        public string Meal { get; set; }

    }
}
