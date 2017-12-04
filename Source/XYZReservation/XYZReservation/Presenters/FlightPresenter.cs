using XYZReservation.Helpers;
using XYZReservation.Models;
using XYZReservation.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XYZReservation.Presenters
{

    public enum FlightSearchBy
    {
        All,

        [Description("Flight Number")]
        FlightNumber,

        [Description("Airline Code")]
        AirlineCode,

        [Description("Origin/Destination")]
        OriginDestination
    }


    public class FlightPresenter
    {
        private readonly FlightManager _flightManager;
        private readonly StationManager _stationManager;
        private readonly IManageFlightView _flightView;

        private Flight _currentFlight;

        public FlightPresenter(IManageFlightView flightView)
        {
            _flightView = flightView;
            _flightView.Save += OnSave;
            _flightView.Load += OnLoad;

            _flightManager = new FlightManager();
            _stationManager = new StationManager();
        }

        public void OnSave(object source, EventArgs args)
        {
            _currentFlight = new Flight
            {
                AirlineCode = _flightView.AirlineCode.ToUpper(),
                Number = _flightView.FlightNumber,
                ArrivalStationCode = _flightView.ArrivalStationCode,
                DepartureStationCode = _flightView.DepartureStationCode,
                ScheduledTimeArrival = _flightView.ScheduledTimeArrival,
                ScheduledTimeDeparture = _flightView.ScheduledTimeDeparture
            };

            _flightManager.Add(_currentFlight);
            _flightView.ShowSuccessMessage();

        }
        public void OnLoad(object source, SearchArgs args)
        {
            FlightSearchBy searchBy = (FlightSearchBy) args.ParameterType;
            object input = args.Input;

            switch (searchBy)
            {
                case FlightSearchBy.AirlineCode:
                    _flightView.Flights = _flightManager.SearchBy(f => f.AirlineCode == (string) input)
                                                 ?.OrderBy(f => f.Number)
                                                 ?.ThenBy(f => f.ScheduledTimeArrival)
                                                 ?.ToList();
                    break;

                case FlightSearchBy.FlightNumber:
                    _flightView.Flights = _flightManager.SearchBy(f => f.Number == (int) input)
                                                     ?.OrderBy(f => f.AirlineCode)
                                                     ?.ThenBy(f => f.ScheduledTimeArrival)
                                                     ?.ToList();
                    
                    break;

                case FlightSearchBy.OriginDestination:
                    _flightView.Flights = _flightManager.SearchBy(f => f.ArrivalStationCode == (string) input || f.DepartureStationCode == (string) input)
                                                 ?.OrderBy(f => f.ArrivalStationCode)
                                                 ?.ThenBy(f => f.DepartureStationCode)
                                                 ?.ThenBy(f => f.AirlineCode)
                                                 ?.ThenBy(f => f.Number)
                                                 ?.ToList();
                    break;

                default:
                    _flightView.Flights = _flightManager.GetAll()
                                                 ?.OrderBy(f => f.AirlineCode)
                                                 ?.ThenBy(f => f.Number)
                                                 ?.ToList();
                    break;
            }

        }
    }
}
