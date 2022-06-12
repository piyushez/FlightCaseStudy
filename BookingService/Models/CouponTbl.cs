using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingService.Models
{
    public class CouponTbl
    {
        public int Id { get; set; }
        public string CouponCode { get; set; }
        public DateTime ExpirationDate { get; set; }

        public int Amount { get; set; }

        public string CouponDesc { get; set; }
    }
}
