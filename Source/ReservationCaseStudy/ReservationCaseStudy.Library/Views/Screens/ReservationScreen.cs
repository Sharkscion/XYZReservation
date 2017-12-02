using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationCaseStudy.Library.Views
{
    public class ReservationScreen : BaseScreen
    {
        public ReservationScreen()
        {
            Options = new List<IOption>
            {
                new OperationOption(Add){Label = "Add a reservation"},
                new OperationOption(View){Label = "View all reservations"},
                new OperationOption(Search){Label = "Search reservations"},
                new GoToScreenOption{Label = "Go Home", Screen = ApplicationScreen.Home},
                new ExitOption()
            };
        }

        private void Search()
        {
            throw new NotImplementedException();
        }

        private void View()
        {
            throw new NotImplementedException();
        }

        private void Add()
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
