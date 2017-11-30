using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationCaseStudy
{
    public class HomeScreen : BaseScreen
    {
        public HomeScreen()
        {
            ScreenTitle = "Welcome to the Home Screen!";
            Options = new List<IMenuCommand>()
            {
                new GoToScreenCommand{Label = "Flight Maintenance", Screen = ApplicationScreen.FlightMaintenance},
                new GoToScreenCommand{Label = "Reservation", Screen = ApplicationScreen.Reservation},
                new ExitCommand()
            };
        }

        public override void Open()
        {
            Console.WriteLine(ScreenTitle);
            DisplayOptions();
        }
    }
}
