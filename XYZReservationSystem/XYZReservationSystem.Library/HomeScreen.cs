using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XYZReservationSystem.Library
{

    public class HomeScreen
    {
        private ApplicationScreen mChosenScreen;

        public const string mInputErrorMessage = "Please enter a valid menu option";

        public void GoToScreen(string input)
        {
            if (IsOptionValid(input))
            {
                mChosenScreen = (ApplicationScreen)Enum.Parse(typeof(ApplicationScreen), input);

                // TODO: CreateScreenFactory because get page 
                // method only gets the page not generate the 
                // chosen page
                switch (mChosenScreen)
                {
                    case ApplicationScreen.FlightMaintenance: break;
                    case ApplicationScreen.Reservation: break;
                }
            }

        }

        public bool IsOptionValid(string input)
        {
            int parsedInput;
            var IsNumeric = int.TryParse(input, out parsedInput);

            if (!IsNumeric)
            {
                return false;
            }

            if (!Enum.IsDefined(typeof(ApplicationScreen), parsedInput))
            {
                return false;
            }

            return true;
        }
    }
}
