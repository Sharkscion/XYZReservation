using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReservationCaseStudy.Helpers;
using ReservationCaseStudy.Models;

namespace ReservationCaseStudy.Views.Screens
{
    public class AddPassengerView : IManagePassengerView
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }

        public List<Passenger> Passengers { get; set; }
        public bool IsSaveEnabled { get; set; }

        public event EventHandler Save;
        public event EventHandler<SearchArgs> Load;

        public void Open()
        {
            String input = "";

            // First Name
            do
            {
                Console.Write("First Name:");
                input = Console.ReadLine();
                Validate(new NameValidator(), input);

                if (IsSaveEnabled)
                {
                    FirstName = input;
                }
            } while (!IsSaveEnabled);

            //Last name
            do
            {
                Console.Write("Last Name:");
                input = Console.ReadLine();
                Validate(new NameValidator(), input);

                if (IsSaveEnabled)
                {
                    LastName = input;
                }
            } while (!IsSaveEnabled);

            //Birthday
            do
            {
                Console.Write("Birth Date:");
                input = Console.ReadLine();
                Validate(new BirthDateValidator(), input);

                if (IsSaveEnabled)
                {
                    Birthday = DateTime.Parse(input);
                }
            } while (!IsSaveEnabled);

        }

        public void ShowErrorMessage()
        {
            throw new NotImplementedException();
        }

        public void ShowMessage(string message)
        {
            throw new NotImplementedException();
        }

        public void ShowSuccessMessage()
        {
            throw new NotImplementedException();
        }

        public void Validate(BaseValidator validator, string input)
        {
            throw new NotImplementedException();
        }
    }
}
