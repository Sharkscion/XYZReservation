using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XYZReservation.Helpers
{
    public class TimeValidator : BaseValidator
    {
        public override bool IsValid(string input)
        {
            input.Trim();
            TimeSpan parsed;
            if (TimeSpan.TryParseExact(input, StringFormats.STANDARD_TIME_FORMAT, new CultureInfo("en-US"),  out parsed))
            {
                return true;
            }

            ErrorMessage = "The scheduled time should follow the 24 hours format (hh:mm) (eg 14:30, 04:30)";
            return false;
        }
    }
}
