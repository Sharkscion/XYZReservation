using ReservationCaseStudy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationCaseStudy.Views
{
    public interface IManagePassengerView : IManageView
    {
        string FirstName { get; set; }
        string LastName { get; set; }
        DateTime Birthday { get; set; }

        List<Passenger> Passengers { get; set; }
    }
}
