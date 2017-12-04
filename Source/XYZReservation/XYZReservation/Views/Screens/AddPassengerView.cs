using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XYZReservation.Helpers;
using XYZReservation.Models;

namespace XYZReservation.Views
{
    public class AddPassengerView : IManagePassengerView
    {
        private BaseValidator _validator;

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }

        public List<Passenger> Passengers { get; set; }
        public bool IsSaveEnabled { get; set; }

        public event EventHandler<PassengerArgs> Save;
        public event EventHandler<SearchArgs> Load;

        public void Open()
        {
            string input = "";

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

            OnSave();
        }

        protected virtual void OnSave()
        {
            Save?.Invoke(this, new PassengerArgs(FirstName, LastName, Birthday));
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
            _validator = validator;
            IsSaveEnabled = _validator.IsValid(input);

            if (!IsSaveEnabled)
            {
                Console.WriteLine(_validator.ErrorMessage);
            }
        }
    }
}
