using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XYZReservation.Views
{
    public class PassengerArgs : EventArgs
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }

        public PassengerArgs(string firstName, string lastName, DateTime birthday)
        {
            FirstName = firstName;
            LastName = lastName;
            Birthday = birthday;
        }
    }
}
