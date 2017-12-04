using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationCaseStudy.Helpers
{
    public abstract class BaseValidator
    {
        public string ErrorMessage { get; set; }
        public abstract bool IsValid(string input);
    }
}
