
using AirlineService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirlineService.Repository
{
    public interface IAirlineRepository
    {
        List<Airline> GetAirlineList();
       
        Airline GetAirlineByNo(string airlineNo);

        int SaveAirline(Airline airline);

        int DeleteAirlineByNo(string airlineNo);

        int UpdateAirline(Airline airline);

    }
}
