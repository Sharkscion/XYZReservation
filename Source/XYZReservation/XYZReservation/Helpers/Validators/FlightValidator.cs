using XYZReservation.Models;
using System.Text;

namespace XYZReservation.Helpers
{
    public class FlightValidator : BaseValidator
    {
        private string _airlineCode;
        private int _flightNumber;

        public FlightValidator(string airlineCode, int flightNumber)
        {
            _airlineCode = airlineCode;
            _flightNumber = flightNumber;
        }

        public override bool IsValid(string input = null)
        {
            StringBuilder message = new StringBuilder();
            var flightManager = new FlightManager();

            if (flightManager.SearchFlightById(_airlineCode, _flightNumber) == null)
            {
                message.Append("The flight with airline code: ");
                message.Append(_airlineCode);
                message.Append(" and flight number: ");
                message.Append(_flightNumber);
                message.AppendLine(" does not exists");

                ErrorMessage = message.ToString();
                return false;
            }
            return true;
        }
    }
}
