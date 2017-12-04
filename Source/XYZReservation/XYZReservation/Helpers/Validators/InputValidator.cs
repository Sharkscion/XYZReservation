using XYZReservation.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace XYZReservation.Helpers
{
    public static class InputValidator
    {
        private static Regex _alphaNumericRegEx = new Regex("^[a-zA-Z0-9]*$");
        private static Regex _nameRegEx = new Regex(@"^[a-zA-Z''-'\s]*$");
       
        public static bool IsNumeric(string input)
        {
            int result;
            if(int.TryParse(input, out result))
            {
                return true;
            }
            return false;
        }

        public static bool IsDate(string input)
        {
            DateTime result;
            if(!DateTime.TryParseExact(input, "mm/dd/yyyy", new CultureInfo("en-US"), DateTimeStyles.None, out result))
            {
                return false;
            }

            return true;
        }

       

        public static bool IsName(string input)
        {
            if (_nameRegEx.IsMatch(input))
            {
                return true;
            }
            return false;
        }

        public static bool IsAlphaNumeric(string input)
        {
            if (_alphaNumericRegEx.IsMatch(input))
            {
                return true;
            }
            return false;
        }

        public static bool IsDigit(char input)
        {
           
            if(input < 48 || input > 57)
            {
                return false;
            }

            return true;
        }

        public static bool IsLetter(char input)
        {
            if (input > 65 && input < 90 || input > 97 && input < 122)
            {
                return true;
            }

            return false;
        }
 
    }
}
