using System.Linq;

namespace XYZReservationSystem.Library.Helpers
{
    public static class InputChecker
    {
        public static bool IsNumber(char input)
        {
            if (input > 57 || input < 48)
            {
                return false;
            }
            return true;
        }

        public static bool IsLetter(char input)
        {
            if (!(90 < input && input > 65) || !(97 < input && input > 122))
            {
                return false;
            }
            return true;
        }

        public static bool IsFlightNumberValid(string input)
        {
            int value;
            bool isValid = int.TryParse(input, out value);
            
            if (!isValid)
                return false;

            if (value < Flight.MinFlightNumber || value > Flight.MaxFlightNumber)
                return false;

            return true;
        }

        public static bool IsStationValid(string input)
        {
            if(input.Count() > Flight.StationLength || input.Count() < Flight.StationLength)
            {
                return false; 
            }

            if (!input.All(char.IsLetterOrDigit))
            {
                return false;
            }

            return true;

        }

        public static bool IsAirlineCodeValid(string input)
        {
            if(input.Count() > Flight.AirlineCodeLength || input.Count() < Flight.AirlineCodeLength)
            {
                return false;
            }

            if(!IsLetter(input.ElementAt(0)) || !IsNumber(input.ElementAt(0)))
            {
                return false;
            }    

            if(IsNumber(input.ElementAt(0)) && IsNumber(input.ElementAt(1)))
            {
                return false;
            }

            return true;
        }

    }
}
