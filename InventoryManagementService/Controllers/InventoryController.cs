
using InventoryService.Models;
using InventoryService.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using System;
using System.Text;
using System.Transactions;

namespace InventoryService.Controllers
{    
    public class InventoryController : Controller
    {
        private readonly IInventoryRepository _inventoryRepository;
        public InventoryController(IInventoryRepository repository)
        {
            _inventoryRepository = repository;
        }
       
        [HttpGet]    
        [Route("inventory/get")]
        public IActionResult Get()
        {
           
            try
            {
                var inventories = _inventoryRepository.GetInventory();
                if (inventories == null)
                {
                    return Json(new { data = "Inventory details not exists", isSuccess = false });
                }   
                else
                {
                    return Json(new { data = inventories, isSuccess = true });
                }
                   
            }
            catch (Exception ex)
            {
                return Json(new { data = ex.Message, isSuccess = true });
            }
           
        }


        [HttpPost]
        [Route("inventory/add")]
        public IActionResult Add([FromBody] InventoryTbl tbl)
        {
          
            try
            {  
                int result=_inventoryRepository.AddInventory(tbl);
                if (result > -1)
                {
                    return Json(new { data = "Inventories added successfully", isSuccess = true });
                }
                else
                {
                    return Json(new { data = "Some error occured while add inventories", isSuccess = false });
                }
              
            }
            catch (Exception ex)
            {
                return Json(new { data = ex.Message, isSuccess = true });
            }
          
        }

        [HttpGet("/inventory/search/{fromplace}/{toplace}/{startDate}/{endDate}")]
        
        public IActionResult Search(string fromplace, string toplace,DateTime startDate,DateTime endDate)
        {

            try
            {
                var flights = _inventoryRepository.GetAllFlightBasedUponPlaces(fromplace, toplace,startDate,endDate);
              
                    return Json(new { data = flights, isSuccess = true });
               

            }
            catch (Exception ex)
            {
                return Json(new { data = ex.Message, isSuccess = false });
            }

        }

        [HttpDelete]
        [Route("inventory/deleteAirlineByNo/{airlineNo}")]
        public IActionResult DeleteAirlineByNo(string airlineNo)
        {

            try
            {
                var inventories = _inventoryRepository.DeleteInventory(airlineNo);
                if (inventories<0)
                {
                    return Json(new { data = "Some err occured while delete inventories", isSuccess = false });
                }
                else
                {
                    return Json(new { data = "inventory successfully", isSuccess = true });
                }

            }
            catch (Exception ex)
            {
                return Json(new { data = ex.Message, isSuccess = true });
            }

        }
    }
}
