using ReservationCaseStudy.Library.Models;
using System;
using System.Collections.Generic;

namespace ReservationCaseStudy.Library.Views
{
    public interface IManageFlightView : IManageView
    {
        Action<string> SetAirlineCode { get; set; }
        Action<string> SetFlightNumber { get; set; }
        Action<string> SetArrivalStationCode { get; set; }
        Action<string> SetDepartureStationCode { get; set; }
        Action<string> SetScheduledTimeArrival { get; set; }
        Action<string> SetScheduledTimeDeparture { get; set; }
        
        List<Flight> Flights { get; set; }
    }
}
