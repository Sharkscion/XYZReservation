using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationCaseStudy
{
    public interface IMenuCommand
    {
<<<<<<< HEAD:Source/ReservationCaseStudy/ReservationCaseStudy/Views/Commands/IMenuCommand.cs
        string Label { get; set; }
        void Execute();
=======

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
>>>>>>> bac9d4cbe9af3fe128a7aab5b5e69f6299d1c271:XYZReservationSystem/XYZReservationSystem.Library/FlightMaintenanceScreen.cs
    }
}
