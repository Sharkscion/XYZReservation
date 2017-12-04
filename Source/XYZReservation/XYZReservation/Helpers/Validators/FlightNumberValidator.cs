using XYZReservation.Models;
using System.Text;

namespace XYZReservation.Helpers
{
    public class FlightNumberValidator : BaseValidator
    {
        private string _airlineCode;
        private bool _IsForAdd;

        public FlightNumberValidator(bool isForAdd, string airlineCode = null)
        {
            _airlineCode = airlineCode;
            _IsForAdd = isForAdd;
        }

        public override bool IsValid(string input)
        {
            input.Trim();
            bool result = true;
            int parsedResult = 0;
            var flightManager = new FlightManager();

            StringBuilder message = new StringBuilder();

            if (!InputValidator.IsNumeric(input))
            {
                ErrorMessage = "A flight number should be a number";
                return false;
            }
            else
            {
                int.TryParse(input, out parsedResult);

                if (parsedResult < 1 || parsedResult > Flight.MAX_FLIGHT_NUMBER)
                {
                    result = false;
                    message.Append("A flight number can only be between 1 to ");
                    message.Append(Flight.MAX_FLIGHT_NUMBER);
                    message.AppendLine();
                }

                if(_airlineCode != null && _IsForAdd)
                {
                    if (flightManager.SearchFlightById(_airlineCode, parsedResult) != null)
                    {
                        result = false;
                        message.Append("The flight with airline code: ");
                        message.Append(_airlineCode);
                        message.Append(" and flight number: ");
                        message.Append(parsedResult);
                        message.AppendLine(" already exists");
                    } 
                    
                }
                
            }

            ErrorMessage = message.ToString();
            return result;
        }
    }
}
