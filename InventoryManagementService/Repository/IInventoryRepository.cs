
using InventoryService.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InventoryService.Repository
{
    public interface IInventoryRepository
    {
         int AddInventory(InventoryTbl inventory);
         List<InventoryTbl> GetInventory();
         List<InventoryTbl> GetAllFlightBasedUponPlaces(string fromplace, string toplace);
    }
}
