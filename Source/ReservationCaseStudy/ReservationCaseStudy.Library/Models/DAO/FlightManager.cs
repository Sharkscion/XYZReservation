
using ReservationCaseStudy.Library.Models;
using System.Linq;

namespace ReservationCaseStudy.Library
{
    public class FlightManager : BaseDataManager<Flight>
    {
        public Flight SearchObjectBy(string airlineCode, int number)
        {
            using(var context = new ReservationDBContext())
            {
                return context.Flights.Where(f=> f.AirlineCode == airlineCode && f.Number == number).SingleOrDefault();
            }
        }

    }
}
