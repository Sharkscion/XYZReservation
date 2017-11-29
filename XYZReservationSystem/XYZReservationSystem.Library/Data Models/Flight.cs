using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XYZReservationSystem.Library
{
    public class Flight
    {
        public const int MinFlightNumber = 1;
        public const int MaxFlightNumber = 9999;
        public const int AirlineCodeLength = 2;
        public const int StationLength = 3;

        #region Public Properties

        public char[] AirlineCode { get; set; }

        public int FlightNumber { get; set; }

        public char[] ArrivalStation { get; set; }

        public char[] DepartureStation { get; set; }

        public TimeSpan STA { get; set; }

        public TimeSpan STD { get; set; }

        #endregion
    }
}
