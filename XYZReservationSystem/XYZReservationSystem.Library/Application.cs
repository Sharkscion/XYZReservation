using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XYZReservationSystem.Library
{
    enum ApplicationScreen
    {
        FlightMaintenance,
        Reservation
    }

    public class Application
    {
        private int mChosenOption;

        public const string mInputErrorMessage = "Please enter a valid menu option";

        public Screen GetPage(string input)
        {
            if (!IsOptionValid(input))
                return null;

            // TODO: CreateScreenFactory because get page 
            // method only gets the page not generate the 
            // chosen page
            switch (mChosenOption)
            {
                case (int)ApplicationScreen.FlightMaintenance: break;
                case (int)ApplicationScreen.Reservation: break;
            }   

            return null;
            
        }

        public bool IsOptionValid(string input)
        {
            var IsNumeric = int.TryParse(input, out mChosenOption);

            if (!IsNumeric)
            {
                return false;
            }

            if (!Enum.IsDefined(typeof(ApplicationScreen), mChosenOption))
            {
                return false;
            }

            return true;
        }
    }
}
