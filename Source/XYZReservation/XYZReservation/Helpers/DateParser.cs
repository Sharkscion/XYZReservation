using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XYZReservation.Helpers
{
    public static class DateParser
    {
        public const string STANDARD_DATE_FORMAT = "mm/dd/yyyy";

        public static DateTime Parse(string input)
        {
            return DateTime.ParseExact(input, STANDARD_DATE_FORMAT, new CultureInfo("en-US"));
        }
    }
}
