using XYZReservation.Helpers;
using XYZReservation.Models;
using System;
using System.Collections.Generic;

namespace XYZReservation.Views
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

        event EventHandler Save;

    }
}
