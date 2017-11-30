using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationCaseStudy.Helpers
{
    public static class InputValidator
    {
        public static bool IsNumeric(string input)
        {
            if(!int.TryParse(input, out int result))
            {
                return false;
            }

            return true;
        }


    }
}
