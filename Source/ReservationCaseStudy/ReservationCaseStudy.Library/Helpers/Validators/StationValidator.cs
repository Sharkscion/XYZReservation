using ReservationCaseStudy.Library;
using ReservationCaseStudy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationCaseStudy.Helpers
{
    public class StationValidator : BaseValidator
    {
        private string _arrivalStationCode; 

        public StationValidator(string code = null)
        {
            _arrivalStationCode = code;
        }

        public override bool IsValid(string input)
        {
            input.Trim();
            var stationManager = new StationManager();

            if (input.Count() != Station.CODE_LENGTH)
            {
                StringBuilder message = new StringBuilder();
                message.Append("A station code should consists exactly of ");
                message.Append(Station.CODE_LENGTH);
                message.AppendLine(" characters");

                ErrorMessage = message.ToString();
                return false;
            }

            if (!InputValidator.IsAlphaNumeric(input))
            {
                ErrorMessage = "A station code should only consists of alphanumeric characters";
                return false;
            }

            if (stationManager.SearchObjectBy(s => s.Code == input) == null)
            {
                ErrorMessage = "The station code does not exist";
                return false;
            }

            if(_arrivalStationCode != null)
            {
                if(_arrivalStationCode == input)
                {
                    ErrorMessage = "The arrival station and departure station cannot be the same";
                    return false;
                }
            }

            return true;
        }
    }
}
