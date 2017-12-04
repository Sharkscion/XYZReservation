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
    public enum ReservationSearchBy
    {
        All,
        [Description("PNR Number")]
        PNRNumber,
    }


    public class ReservationPresenter
    {
        private readonly PassengerManager _passengerManager;
        private readonly ReservationManager _reservationManager;
        private readonly IManageReservationView _reservationView;
        private static Random _random = new Random();

        private Reservation _currentReservation;

        public ReservationPresenter(IManageReservationView reservationView)
        {
            _reservationView = reservationView;
            _reservationView.Save += OnSave;
            _reservationView.Load += OnLoad;

            _passengerManager = new PassengerManager();
            _reservationManager = new ReservationManager();
        }


        public static string GeneratePNRNumber()
        {
            StringBuilder builder = new StringBuilder();

            char firstChar = Convert.ToChar(_random.Next(65, 91));
            builder.Append(firstChar);

            var chars = "ABCDEFGHJKLMNPQRSTUVWXYZ23456789";
            var result = new string(
                Enumerable.Repeat(chars, Reservation.PNR_NUMBER_LENGTH - 1)
                          .Select(s => s[_random.Next(s.Length)])
                          .ToArray());

            builder.Append(result);
            return builder.ToString().ToUpper();
        }


        public void OnSave(object source, EventArgs args)
        {
            _currentReservation = new Reservation
            {
                FlightAirlineCode = _reservationView.AirlineCode.ToUpper(),
                FlightNumber = _reservationView.FlightNumber,
                FlightDate = _reservationView.FlightDate,
                NumPassengers = _reservationView.NumPassengers,
                Passengers = _reservationView.Passengers
            };

            string generatedPNRNumber = GeneratePNRNumber();

            while(_reservationManager.SearchObjectBy(r => r.PNRNumber == generatedPNRNumber) != null)
            {
                generatedPNRNumber = GeneratePNRNumber();
            }

            if(generatedPNRNumber != null)
            {
                _currentReservation.PNRNumber = generatedPNRNumber;
                _reservationView.PNRNumber = generatedPNRNumber;

                _reservationManager.Add(_currentReservation);
                _reservationView.ShowSuccessMessage();
            }
            else
            {
                _reservationView.ShowErrorMessage();
            }
            
        }


        public void OnLoad(object source, SearchArgs args)
        {
            ReservationSearchBy searchBy = (ReservationSearchBy)args.ParameterType;
            object input = args.Input;

            switch (searchBy)
            {
                case ReservationSearchBy.PNRNumber:
                    _reservationView.Reservations = _reservationManager.SearchByIncluding(r => r.PNRNumber == (string)input, r => r.Passengers)
                                                                        ?.OrderByDescending(r => r.FlightDate)
                                                                        ?.ToList();
                    break;

                default:
                    _reservationView.Reservations = _reservationManager.GetAllIncluding(r => r.Passengers)
                                                                       ?.OrderByDescending(r => r.FlightDate)
                                                                       ?.ThenBy(r => r.PNRNumber)
                                                                       ?.ToList();
                    break;
            }

        }
    }
}
