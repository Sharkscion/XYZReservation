using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationCaseStudy
{
    public static class ScreenFactory
    {
        public static BaseScreen GenerateScreen(ApplicationScreen screen)
        {
            switch (screen)
            {
                case ApplicationScreen.Home: return new HomeScreen("Welcome to XYZ Reservation!");
                case ApplicationScreen.FlightMaintenance: return new FlightMaintenanceScreen("Flight Maintenance Screen");
                case ApplicationScreen.Reservation: return new ReservationScreen("Reservation Screen");
                default: return new HomeScreen("Welcome to XYZ Reservation!"); ;
            }
        }
    }
}
