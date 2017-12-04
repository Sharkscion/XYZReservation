using ReservationCaseStudy.Library;
using ReservationCaseStudy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationCaseStudy.Helpers
{
    public class AirlineCodeValidator : BaseValidator
    {
        public override bool IsValid(string input)
        {
            input.Trim();
            bool result = true;
            StringBuilder message = new StringBuilder();

            if (input?.Count() != Flight.AIRLINE_CODE_LENGTH)
            {
                result = false;
                message.Append("An airline code must be exactly ");
                message.Append(Flight.AIRLINE_CODE_LENGTH);
                message.AppendLine(" characters");
            }

            if (!InputValidator.IsAlphaNumeric(input))
            {
                result = false;
                message.AppendLine("An airline code must only consists of alphanumeric characters");
            }

            if (input?.Count() == Flight.AIRLINE_CODE_LENGTH &&
               InputValidator.IsDigit(input.ElementAt(0)) &&
               InputValidator.IsDigit(input.ElementAt(1)))
            {
                result = false;
                message.AppendLine("An airline code cannot be both numbers.");
            }

            ErrorMessage = message.ToString();
            return result;
        }
    }
}
