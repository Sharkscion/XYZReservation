using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationCaseStudy.Helpers
{
    public class FlightDateValidator : BaseValidator
    {
        public override bool IsValid(string input)
        {
            input.Trim();
            if (!InputValidator.IsDate(input))
            {
                ErrorMessage = "Enter a valid flight date with the format (mm/dd/yyyy)";
                return false;
            }

            if (DateParser.Parse(input) < DateTime.Today)
            {
                ErrorMessage = "A flight date cannot be a past date";
                return false;
            }

            return true;
        }
    }
}
