using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XYZReservation.Helpers
{
    public class BirthDateValidator : BaseValidator
    {
        public override bool IsValid(string input)
        {
            input.Trim();
            if (!InputValidator.IsDate(input))
            {
                ErrorMessage = "Enter a valid birth date with the format (mm/dd/yyyy)";
                return false;
            }


            if(DateParser.Parse(input) >= DateTime.Today)
            {
                ErrorMessage = "A birth date cannot be a future date";
                return false;
            }

            return true;
        }
    }
}
