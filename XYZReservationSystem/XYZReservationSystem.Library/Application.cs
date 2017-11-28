using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XYZReservationSystem.Library
{
    enum ApplicationPage
    {
        FlightMaintenance,
        Reservation
    }

    public class Application
    {
        private int mChosenOption;

        public const string mInputErrorMessage = "Please enter a valid menu option";

        public Page GetPage(string input)
        {
            if (!IsOptionValid(input))
                return null;
            else
                
            if (!Enum.IsDefined(typeof(ApplicationPage), input))
                throw new ArgumentOutOfRangeException();


            switch (mChosenOption)
            {
                case (int)ApplicationPage.FlightMaintenance: break;
                case (int)ApplicationPage.Reservation: break;
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

            if (!Enum.IsDefined(typeof(ApplicationPage), mChosenOption))
            {
                return false;
            }

            return true;
        }
    }
}
