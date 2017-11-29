using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XYZReservationSystem.Library
{
    public class FlightMaintenanceScreen : Screen
    {

        public void Add()
        {
            
        }


        public string GetAirlineCode()
        {
            Console.WriteLine("Airline Code:");
            var input = Console.ReadLine();
            input.Trim();
            

            return "";
        }


















        public override void Close()
        {
            throw new NotImplementedException();
        }

        public override void Print()
        {
            throw new NotImplementedException();
        }
    }
}
