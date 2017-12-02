using ReservationCaseStudy.Library.Models;
using ReservationCaseStudy.Library.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationCaseStudy.Library.Presenters
{
    public class FlightPresenter : IPresenter<IManageFlightView>
    {
        private FlightManager _flightManager;
        private StationManager _stationManager;
        private Flight _flight;

        public IManageFlightView View { get; set; }

        public FlightPresenter(IManageFlightView view)
        {
            View = view;
            View.Save += OnSave;
            View.Load += OnLoad;
            View.SetAirlineCode += OnSetAirlineCode;
            View.SetFlightNumber += OnSetFlightNumer;
            View.SetArrivalStationCode += OnSetArrivalStationCode;
            View.SetDepartureStationCode += OnSetDepartureStationCode;
            View.SetScheduledTimeArrival += OnSetScheduledTimeArrival;
            View.SetScheduledTimeDeparture += OnSetScheduledTimeDeparture;

            _flightManager = new FlightManager();
            _stationManager = new StationManager();
            _flight = new Flight();
        }

        public void OnSetAirlineCode(string airlineCode)
        {
            bool isValid = true;
            StringBuilder message = new StringBuilder();

            if (airlineCode.Count() != Flight.AIRLINE_CODE_LENGTH)
            {
                isValid = false;
                message.Append("An airline code must be exactly ");
                message.Append(Flight.AIRLINE_CODE_LENGTH);
                message.AppendLine(" characters");

            }

            if (!InputValidator.IsAlphaNumeric(airlineCode))
            {
                isValid = false;
                message.AppendLine("An airline code must only consists of alphanumeric characters");
            }
            
            if(airlineCode.Count() == Flight.AIRLINE_CODE_LENGTH &&
               InputValidator.IsDigit(airlineCode.ElementAt(0)) &&
               InputValidator.IsDigit(airlineCode.ElementAt(1)))
            {
                isValid = false;
                message.AppendLine("An airline code cannot be both numbers.");
            }

            View.IsSaveEnabled = isValid;

            if (isValid)
            {
                _flight.AirlineCode = airlineCode.ToUpper();
            }
            else
            {
                View.ShowMessage(message.ToString());
            }
;
        }

        public void OnSetFlightNumer(string input)
        {
            bool isValid = true;
            int parsedResult = 0;
            StringBuilder message = new StringBuilder();

            if (!InputValidator.IsNumeric(input))
            {
                isValid = false;
                message.AppendLine("A flight number should be a number");
            }
            else
            {
                int.TryParse(input, out parsedResult);               

                if (parsedResult < 1 || parsedResult > Flight.MAX_FLIGHT_NUMBER)
                {
                    isValid = false;
                    message.Append("A flight number can only be between 1 to ");
                    message.Append(Flight.MAX_FLIGHT_NUMBER);
                    message.AppendLine();
                }
                else
                {
                    View.ShowMessage("\nChecking for if flight already exists...\n");

                    if(_flightManager.SearchObjectBy(_flight.AirlineCode, parsedResult) != null)
                    {
                        isValid = false;
                        message.Append("The flight with airline code: ");
                        message.Append(_flight.AirlineCode);
                        message.Append(" and flight number: ");
                        message.Append(parsedResult);
                        message.AppendLine(" already exists");
                    }                    
                }

            }

            View.IsSaveEnabled = isValid;

            if (isValid)
            {
                _flight.Number = parsedResult;
            }
            else
            {
                View.ShowMessage(message.ToString());
            }

        }

        public void OnSetArrivalStationCode(string stationCode)
        {
            bool isValid = false;

            if (IsStationCodeValid(stationCode))
            {
                isValid = true;
                _flight.ArrivalStationCode = stationCode; 
            }

            View.IsSaveEnabled = isValid;
        }

        public void OnSetDepartureStationCode(string stationCode)
        {
            bool isValid = false;

            isValid = IsStationCodeValid(stationCode);

            if (stationCode == _flight.ArrivalStationCode)
            {
                isValid = false;
                View.ShowMessage("The arrival station and departure station cannot be the same.");
            }

            if (isValid)
            {
                _flight.DepartureStationCode = stationCode;
            }

            View.IsSaveEnabled = isValid;
        }

        public void OnSetScheduledTimeArrival(string time)
        {
            bool isValid = false;

            if (IsScheduledTimeValid(time))
            {
                isValid = true;
                TimeSpan.TryParse(time, out TimeSpan parsedTime);
                _flight.ScheduledTimeArrival = parsedTime;
            }

            View.IsSaveEnabled = isValid;
        }

        public void OnSetScheduledTimeDeparture(string time)
        {
            bool isValid = false;

            if (IsScheduledTimeValid(time))
            {
                isValid = true;
                TimeSpan.TryParse(time, out TimeSpan parsedTime);
                _flight.ScheduledTimeDeparture = parsedTime;
            }

            View.IsSaveEnabled = isValid;
        }

        public void OnSave()
        {
            _flightManager.Add(_flight);
        }

        //To be continued
        public void OnLoad()
        {
            View.Flights = new List<Flight>(_flightManager.GetAll());
        }


        public bool IsStationCodeValid(string stationCode)
        {
            bool isValid = true;
            StringBuilder message = new StringBuilder();

            if(stationCode.Count() != Station.CODE_LENGTH)
            {
                isValid = false;
                message.Append("A station code should consists exactly of ");
                message.Append(Station.CODE_LENGTH);
                message.AppendLine(" characters");
            }

            if (!InputValidator.IsAlphaNumeric(stationCode))
            {
                isValid = false;
                message.AppendLine("A station code should only consists of alphanumeric characters");
            }

            if(_stationManager.SearchObjectBy(s => s.Code == stationCode) == null)
            {
                isValid = false;
                message.AppendLine("The station code does not exist");
            }

            if (isValid)
            {
                View.IsSaveEnabled = true;
            }
            else
            {
                View.ShowMessage(message.ToString());
            }


            return isValid;
        }

        public bool IsScheduledTimeValid(string time)
        {
            bool isValid = true;
            StringBuilder message = new StringBuilder();


            if (!InputValidator.IsValidTimeFormat(time))
            {
                isValid = false;
                message.AppendLine("A scheduled time should follow the 24 hour format (eg 04:30, 15:00 )");
            }

            if (isValid)
            {
                View.IsSaveEnabled = true;
            }
            else
            {
                View.ShowMessage(message.ToString());
            }


            return isValid;
        }
    }
}
