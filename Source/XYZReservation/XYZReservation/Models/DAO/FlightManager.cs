
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace XYZReservation.Models
{
    public class FlightManager : BaseDataManager<Flight>
    {

        public Flight SearchFlightById(string airlineCode, int number)
        {
            using(var context = new ReservationDBContext())
            {
                return context.Flights.Where(f=> f.AirlineCode == airlineCode && f.Number == number).SingleOrDefault();
            }
        }

        public override void Add(Flight entity)
        {
            using (var context = new ReservationDBContext())
            {
                context.Set<Flight>().Add(entity);
                context.SaveChanges();
            }
        }
    }
}
