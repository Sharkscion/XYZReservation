using ReservationCaseStudy.Library.Presenters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationCaseStudy.Library.Views
{
    public static class ScreenFactory
    {
        public static IView GenerateScreen(ApplicationScreen screen)
        {
            switch (screen)
            {
                case ApplicationScreen.Home: return new HomeScreen();
                case ApplicationScreen.FlightMaintenance:

                    IManageFlightView flightMaintenanceScreen = new FlightMaintenanceScreen() { ScreenTitle = "Flight Maintenance" };
                    FlightPresenter flightPresenter = new FlightPresenter(flightMaintenanceScreen);
                    return flightMaintenanceScreen;

                case ApplicationScreen.Reservation: return new ReservationScreen();
                default: return new HomeScreen(); 
            }
        }
    }
}
