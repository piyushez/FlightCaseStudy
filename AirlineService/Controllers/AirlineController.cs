using AirlineService.Models;
using AirlineService.Repository;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirlineService.Controllers
{
    
   
    public class AirlineController : Controller
    {
        private IAirlineRepository _airlineRepository;
        private readonly IBus _bus;
        public AirlineController(IAirlineRepository airlineRepository,IBus bus)
        {
            _airlineRepository = airlineRepository;
            _bus = bus;
        }
        [HttpPost]
        [Route("/airline/inventory")]
        public async Task<IActionResult> CreateTicket([FromBody] Airline airline)
        {
            if (airline !=null)
            {
                Uri uri = new Uri("rabbitmq://localhost/todoQueue1");
                var endPoint = await _bus.GetSendEndpoint(uri);
                await endPoint.Send(airline);
                return Ok();
            }
            return BadRequest();
        }
        [HttpGet]
        [Route("/airline/getairlines")]
        public  IActionResult GetAirlines()
        {
            //List<Airline> lstAirline = new List<Airline>();
            try
            {

               var lstAirline = _airlineRepository.GetAirlineList();
                if(lstAirline!=null )
                {
                    return Json(new { data = lstAirline, isSuccess = true });
                }
                else
                {
                    return Json(new { data = "No Details Found", isSuccess = true });
                }
            }
            catch(Exception ex)
            {
                return Json(new { data =ex.Message , isSuccess = false });
            }
        }

        //[HttpGet]
        //[Route("/airline/GetInventories")]
        //public IActionResult GetInventories()
        //{
        //    //List<Airline> lstAirline = new List<Airline>();
        //    try
        //    {

        //        /*var lstAirline = */_airlineRepository.GetInventories();
        //        //if (lstAirline != null)
        //        //{
        //        //    return Json(new { data = lstAirline, isSuccess = true });
        //        //}
        //        //else
        //        //{
        //            return Json(new { data = "No Details Found", isSuccess = true });
        //        //}
        //    }
        //    catch (Exception ex)
        //    {
        //        return Json(new { data = ex.Message, isSuccess = false });
        //    }
        //}
        [HttpGet]
        [Route("/airline/GetAirlineByNo/{airlineNo}")]
        public IActionResult GetAirlineByNo(string airlineNo)
        {
            Airline airline = new Airline();
            try
            {

                airline = _airlineRepository.GetAirlineByNo(airlineNo);
                if (airline !=null)
                {
                    return Json(new { data = airline, isSuccess = true });
                }
                else
                {
                    return Json(new { data = "No Record Found", isSuccess = true });
                }
            }
            catch (Exception ex)
            {
                return Json(new { data = ex.Message, isSuccess = false });
            }
        }

        [HttpPost]
        [Route("/airline/register")]
        public IActionResult Register([FromBody]Airline airline)
        {
           
            try
            {

                var result = _airlineRepository.SaveAirline(airline);
                if (result>-1)
                {
                    return Json(new { data = result, isSuccess = true });
                }
                else
                {
                    return Json(new { data = "Some error occured while add details", isSuccess = true });
                }
            }
            catch (Exception ex)
            {
                return Json(new { data = ex.Message, isSuccess = false });
            }
        }

        public IActionResult UpdateAirline(Airline airline)
        {

            try
            {

                var result = _airlineRepository.UpdateAirline(airline);
                if (result > -1)
                {
                    return Json(new { data = result, isSuccess = true });
                }
                else
                {
                    return Json(new { data = "Some error occured while update details", isSuccess = true });
                }
            }
            catch (Exception ex)
            {
                return Json(new { data = ex.Message, isSuccess = false });
            }
        }

        [HttpDelete]
        [Route("/airline/DeleteAirlineByNo/{airlineNo}")]
        public IActionResult DeleteAirlineByNo(string airlineNo)
        {
            try
            {
                int res = _airlineRepository.DeleteAirlineByNo(airlineNo);

                if (res > -1)
                {
                    return Json(new { data = "Successfully Deleted", isSuccess = true });
                }
                else
                {
                    return Json(new { data = "Some error occured while delete Airline", isSuccess = true });
                }
            }
            catch (Exception ex)
            {
                return Json(new { data = ex.Message, isSuccess = false });
            }
        }
    }
}
