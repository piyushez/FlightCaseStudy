
using InventoryService.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InventoryService.Repository
{
    public interface IInventoryRepository
    {
         int AddInventory(InventoryTbl inventory);
         List<InventoryTbl> GetInventory();
        int DeleteInventory(string AirlineNo);
        List<InventoryTbl> GetAllFlightBasedUponPlaces(string fromplace, string toplace, DateTime fromDate, DateTime toDate);
    }
}
