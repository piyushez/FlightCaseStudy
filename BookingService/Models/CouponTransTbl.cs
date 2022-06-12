using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingService.Models
{
    public class CouponTransTbl
    {
        public int Id { get; set; }

        public string CouponCode { get; set; }

        public string UserEmail { get; set; }

        public DateTime UsedDate { get; set; }
    }
}
