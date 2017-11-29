using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XYZReservationSystem.Library
{
    public class Passenger
    {

        #region Public Properties
        public string FirstName { get; set; } 

        public string LastName { get; set; }

        public DateTime Birthday { get; set; }
        
        public int Age
        {
            get
            {
                DateTime now = DateTime.Today;
                int age = now.Year - Birthday.Year;
                if (now < Birthday.AddYears(age))
                    age--;

                return age;
            }
        }
        #endregion

    }
}
