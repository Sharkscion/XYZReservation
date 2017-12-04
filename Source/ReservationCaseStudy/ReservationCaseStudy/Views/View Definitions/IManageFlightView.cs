using ReservationCaseStudy.Helpers;
using ReservationCaseStudy.Models;
using System;
using System.Collections.Generic;

namespace ReservationCaseStudy.Views
{
    public interface IManageFlightView : IManageView
    {
        string AirlineCode { get; set; }
        int FlightNumber { get; set; }
        string ArrivalStationCode { get; set; }
        string DepartureStationCode { get; set; }
        TimeSpan ScheduledTimeArrival { get; set; }
        TimeSpan ScheduledTimeDeparture { get; set; }

        List<Flight> Flights { set; }
        
    }
}
