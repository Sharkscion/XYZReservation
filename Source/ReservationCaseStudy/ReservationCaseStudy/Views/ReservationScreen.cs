using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationCaseStudy
{
    public class ReservationScreen : BaseScreen
    {
        public ReservationScreen()
        {
            ScreenTitle = "Reservation Screen";
            Options = new List<IMenuCommand>
            {
                new GoToScreenCommand{Label = "Add a reservation", Screen = ApplicationScreen.AddReservation},
                new GoToScreenCommand{Label = "View all reservations", Screen = ApplicationScreen.ViewReservation},
                new GoToScreenCommand{Label = "Search reservations", Screen =  ApplicationScreen.SearchReservation},
                new GoToScreenCommand{Label = "Go Home", Screen = ApplicationScreen.Home},
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
