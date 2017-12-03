using ReservationCaseStudy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationCaseStudy.Helpers
{
    public class NameValidator : BaseValidator
    {
        public override bool IsValid(string input)
        {
            input.Trim();

            if (input.Equals("") || !InputValidator.IsName(input))
            {
                ErrorMessage = "Enter a valid name";
                return false;
            }

            if(input.Count() > Passenger.MAX_NAME_LENGTH)
            {
                StringBuilder message = new StringBuilder();
                message.Append("A name cannot be more than ");
                message.Append(Passenger.MAX_NAME_LENGTH);
                message.AppendLine(" characters");
                ErrorMessage = message.ToString();
                return false;
            }

            return true;
        }
    }
}
