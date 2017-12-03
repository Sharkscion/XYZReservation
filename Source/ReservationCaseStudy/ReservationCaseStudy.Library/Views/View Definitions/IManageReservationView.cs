using ReservationCaseStudy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationCaseStudy.Views
{
    public interface IManageReservationView : IManageView
    {
        string PNRNumber { get; set; }
        string AirlineCode { get; set; }
        int FlightNumber { get; set; }
        DateTime FlightDate { get; set; }
        int NumPassengers { get; set; }
        List<Reservation> Reservations { get; set; }
        List<Passenger> Passengers { get; set; }

        void ShowPassengerView();
    }
}
