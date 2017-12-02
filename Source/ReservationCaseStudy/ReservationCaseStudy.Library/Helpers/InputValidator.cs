using ReservationCaseStudy.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ReservationCaseStudy.Library
{
    public static class InputValidator
    {
        private static Regex _alphaNumericRegEx = new Regex("^[a-zA-Z0-9]*$");

        public static bool IsValidTimeFormat(string input)
        {
            if(TimeSpan.TryParse(input, out var parsed))
            {
                return true;
            }

            return false;
        }

        public static bool IsNumeric(string input)
        {
            if(int.TryParse(input, out int result))
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
