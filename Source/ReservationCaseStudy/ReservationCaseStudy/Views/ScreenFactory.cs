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
                case ApplicationScreen.Home: return new HomeScreen();
                case ApplicationScreen.FlightMaintenance: return new FlightMaintenanceScreen();
                case ApplicationScreen.Reservation: return new ReservationScreen();
                case ApplicationScreen.AddFlight: return new AddFlightScreen();
                default: return null;
            }
        }
    }
}
