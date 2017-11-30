using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationCaseStudy
{
    public class FlightMaintenanceScreen : BaseScreen
    {
        public FlightMaintenanceScreen()
        {
            ScreenTitle = "Flight Maintenance Screen";
            Options = new List<IMenuCommand>
            {
                new GoToScreenCommand{Label = "Add a flight", Screen = ApplicationScreen.AddFlight},
                new GoToScreenCommand{Label = "Search a flight", Screen = ApplicationScreen.SearchFlight},
                new GoToScreenCommand{Label = "Go Home", Screen =  ApplicationScreen.Home},
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
