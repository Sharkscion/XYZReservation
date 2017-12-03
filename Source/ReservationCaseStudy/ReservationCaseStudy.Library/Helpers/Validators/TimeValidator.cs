using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationCaseStudy.Helpers
{
    public class TimeValidator : BaseValidator
    {
        public override bool IsValid(string input)
        {
            input.Trim();
            if (TimeSpan.TryParse(input, out var parsed))
            {
                return true;
            }

            ErrorMessage = "The scheduled time should follow the 24 hours format (hh:mm) (eg 14:30, 04:30)";
            return false;
        }
    }
}
