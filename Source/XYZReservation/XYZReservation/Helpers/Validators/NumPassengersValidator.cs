using XYZReservation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XYZReservation.Helpers
{
    public class NumPassengersValidator : BaseValidator
    {
        public override bool IsValid(string input)
        {
            input.Trim();

            if (!InputValidator.IsNumeric(input))
            {
                ErrorMessage = "Enter a valid number of passengers";
                return false;
            }

            int result = -1;
            int.TryParse(input, out result);

            if(result > Reservation.MAX_PASSENGER_COUNT || result < 1 )
            {
                ErrorMessage = "You can only reserve for 1 to 5 passengers";
                return false;
            }

            return true;
        }
    }
}
