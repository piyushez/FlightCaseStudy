
using AirlineService.DBContext;
using AirlineService.Models;
using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineService.Repository
{
    public class AirlineRepository : IAirlineRepository
    {
        private AppDBContext _appDBContext;
       

        public AirlineRepository(AppDBContext appDbContext)
        {
            _appDBContext = appDbContext;
          
        }
        public List<Airline> GetAirlineList()
        {
            List<Airline> lstAirlline = new List<Airline>();
            try
            {

               
                lstAirlline = _appDBContext.Airlines?.ToList();

            }
            catch(Exception ex)
            {
                throw;
            }

            return lstAirlline;
        }

     
        public int SaveAirline([FromBody] Airline airline)
        {
            try
            {
                int res = -1;
                var data = _appDBContext.Airlines.Find(airline.AirlineNo);
                if (data == null)
                {
                    _appDBContext.Airlines.Add(airline);
                    res = _appDBContext.SaveChanges();

                }
                else
                {
                    throw new Exception("Airline details already exists");
                }
                return res; 
            }
            catch
            {
                throw;
            }
        }
        public int DeleteAirlineByNo(string airlineNo)
        {

            try
            {
                int res = -1;
                var data = _appDBContext.Airlines.Find(airlineNo);
                if (data != null)
                {
                    data.isBlock = true;
                   
                    res = _appDBContext.SaveChanges();
                }
                else
                {
                    throw new Exception("Airline details not available");
                }
                return res;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Airline GetAirlineByNo(string airlineNo)
        {
            try
            {
                var data = _appDBContext.Airlines.Find(airlineNo);

                if (data == null)
                {
                    throw new Exception("Data Not Found");
                }

                return data;
            }catch(Exception ex)
            {
                throw;
            }
        }
       
        public int UpdateAirline(Airline airline)
        {
            try
            {
                int res = -1;
                var data = _appDBContext.Airlines.Find(airline.AirlineNo);

                if (data != null)
                {
                    _appDBContext.Airlines.Update(airline);
                    res = _appDBContext.SaveChanges();
                }
                else
                {
                    throw new Exception("Data not found");
                }

                return res;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

       
      
        
    }
}
