using XYZReservation.Presenters;
using XYZReservation.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XYZReservation.Views
{
    public static class ScreenFactory
    {
        public static IView GenerateScreen(ApplicationScreen screen)
        {
            switch (screen)
            {
                case ApplicationScreen.Home: return new HomeScreen();

                case ApplicationScreen.FlightMaintenance:

                    IManageFlightView flightMaintenanceScreen = new FlightMaintenanceScreen();
                    FlightPresenter flightPresenter = new FlightPresenter(flightMaintenanceScreen);
                    return flightMaintenanceScreen;

                case ApplicationScreen.Reservation:

                    IManageReservationView reservationScreen = new ReservationScreen();
                    ReservationPresenter reservationPresenter = new ReservationPresenter(reservationScreen);
                    return reservationScreen;

                default: return new HomeScreen(); 
            }
        }
    }
}
