using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XYZReservationSystem.Library
{
    public class Reservation
    {
        #region Public Properties
        public Flight Flight { get; set; }

        public DateTime FlightDate { get; set; }

        public int NumberOfPassengers { get; set; } = 0;

        public string PNR { get; set; }

        public List<Passenger> Passengers { get; set; }

        public Reservation(int numPassenger)
        {
            NumberOfPassengers = numPassenger;
            Passengers = new List<Passenger>(NumberOfPassengers);
        }
        #endregion
    }
}
