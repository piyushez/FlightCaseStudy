using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AirlineService.Models
{
    public class Airline
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string AirlineNo { get; set; }
        public string UploadLogo { get; set; }
        public int ContactNumber { get; set; }
        public string ContactAddress { get; set; }

        public bool isBlock { get; set; } = false;

        //public virtual ICollection<InventoryTbl> Inventories { get; set; }
    }
}
