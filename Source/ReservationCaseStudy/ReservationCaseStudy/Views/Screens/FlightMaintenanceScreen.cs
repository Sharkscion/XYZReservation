using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationCaseStudy
{
    public class FlightMaintenanceScreen : BaseScreen
    {
        public FlightMaintenanceScreen(string screenTitle)
        {
            ScreenTitle = screenTitle;
            Options = new List<IOption>
            {
                new OperationOption(Add){Label = "Add a flight"},
                new OperationOption(Search){Label = "Search a flight"},
                new GoToScreenOption{Label = "Go Home", Screen =  ApplicationScreen.Home},
                new ExitOption()
            };
        }

        private void Search()
        {
            throw new NotImplementedException();
        }

        public void Add()
        {
            throw new NotImplementedException();
        }

        public override void Open()
        {
            Console.WriteLine(ScreenTitle);
            DisplayOptions();
        }
    }
}
