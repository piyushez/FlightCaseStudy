
using InventoryService.DBContext;
using InventoryService.Models;
using MassTransit;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace InventoryService.Repository
{
    public class InventoryRepository : IInventoryRepository, IConsumer<Airline>
    {
        private  InventoryDbContext _inventoryContext;

       
        public InventoryRepository(InventoryDbContext context)
        {
            _inventoryContext = context;
           
            
        }
     
        public async Task Consume(ConsumeContext<Airline> context)
        {
            await Console.Out.WriteLineAsync($"Notification sent: todo id {context.Message.AirlineNo}");
            //Validate the Ticket Data
            //Store to Database
            //Notify the user via Email / SMS
        }
        public List<InventoryTbl> GetInventory()
        {
            try
            {
               
                var res = _inventoryContext.InventoryTbl.ToList();
              
                if (res==null && res.Count == 0)
                    throw new Exception("No Inventory exists");
                return res;
            }
            catch (Exception ex)
            {
                throw ;
            }
        }

        
        public int AddInventory(InventoryTbl tbl)
        {
            try
            {
                int result = -1;
                tbl.FlightNumber=string.IsNullOrEmpty(tbl.FlightNumber) ? "" : tbl.FlightNumber;
                var res = _inventoryContext.InventoryTbl.Where(x => x.FlightNumber.ToLower() ==tbl.FlightNumber.ToLower()  ).ToList();
                if (res.Count != 0)
                {
                    throw new Exception("Inventory for airline " + tbl.AirlineNo + " is alreday exists");
                }
                else
                {
                    _inventoryContext.InventoryTbl.Add(tbl);
                   result= _inventoryContext.SaveChanges();
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ;
            }
        }
      
        public int UpdateInventory(InventoryTbl inventory)
        {
            try
            {
                _inventoryContext.InventoryTbl.Update(inventory);
                _inventoryContext.Entry(inventory).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                return _inventoryContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ;
            }
        }
       

        public List<InventoryTbl> GetAllFlightBasedUponPlaces(string fromplace, string toplace)
        {
            try
            {
                var res = _inventoryContext.InventoryTbl.Where(x => x.ToPlace.ToLower() == toplace.ToLower() && x.FromPlace.ToLower() == fromplace.ToLower()).ToList();
                if (res.Count == 0)
                    throw new Exception("No Flight exists");
                return res;
            }
            catch (Exception ex)
            {
                throw ;
            }
        }

       
    }
}
