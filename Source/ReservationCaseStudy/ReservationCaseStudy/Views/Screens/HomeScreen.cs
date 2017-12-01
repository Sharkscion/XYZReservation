using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationCaseStudy
{
    public class HomeScreen : BaseScreen
    {
        public HomeScreen(string screenTitle)
        {
            ScreenTitle = screenTitle;
            Options = new List<IOption>()
            {
                new GoToScreenOption{Label = "Flight Maintenance", Screen = ApplicationScreen.FlightMaintenance},
                new GoToScreenOption{Label = "Reservation", Screen = ApplicationScreen.Reservation},
                new ExitOption()
            };
        }

        public override void Open()
        {
            Console.WriteLine(ScreenTitle);
            DisplayOptions();
        }
    }
}
