using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReservationCaseStudy.Helpers;
using ReservationCaseStudy.Models;
using ReservationCaseStudy.Presenters;

namespace ReservationCaseStudy.Views
{

    public class ReservationScreen : BaseScreen, IManageReservationView
    {
        private BaseValidator _validator;
        private List<Reservation> _reservations;


        public string PNRNumber { get; set; }
        public string AirlineCode { get; set; }
        public int FlightNumber { get; set; }
        public DateTime FlightDate { get; set; }

        public List<Reservation> Reservations
        {
            get
            {
                return _reservations;
            }

            set
            {
                _reservations = value;
                DisplayReservations();
            }
        }

     

        public List<Passenger> Passengers { get; set; }

        public bool IsSaveEnabled { get; set; }
        public int NumPassengers { get; set; }

        public ReservationScreen()
        {
            ScreenTitle = "Manage Your Reservations";

            MainOptions = new List<IOption>
            {
                new OperationOption(OpenAddForm){Label = "Add a reservation"},
                new OperationOption(View){Label = "View all reservations"},
                new OperationOption(OpenSearchForm){Label = "Search reservations"},
                new GoToScreenOption{Label = "Go Home", Screen = ApplicationScreen.Home},
                new ExitOption()
            };
        }

        public event EventHandler Save;
        public event EventHandler<SearchArgs> Load;

        private void DisplayReservations()
        {
            if(Reservations != null)
            {
                Console.WriteLine("-------------------------------------------------------------------------------------------------------------");
                Console.WriteLine("| {0, -15} {1, -15} {2, -20} {3, -20} {4, -15} |", "PNR Number", "Airline Code", "Flight Number", "Flight Date", "Passenger Count");
                Console.WriteLine("-------------------------------------------------------------------------------------------------------------");

                foreach(var reservaton in Reservations)
                {
                    Console.WriteLine("| {0, -15} {1, -15} {2, -20} {3, -20} {4, -15} |", 
                                    reservaton.PNRNumber,
                                    reservaton.FlightAirlineCode, 
                                    reservaton.FlightNumber, 
                                    reservaton.FlightDate,
                                    reservaton.NumPassengers);

                    if(reservaton?.Passengers != null)
                    {
                        foreach (var passenger in reservaton?.Passengers)
                        {
                            Console.WriteLine("| {0, -15} {1, -15} {2, -32} |",
                                        passenger.FirstName,
                                        passenger.LastName,
                                        passenger.Birthday);
                        }

                        Console.WriteLine("-------------------------------------------------------------------------------------------------------------");

                    }

                }
            }
        }

        private void OpenSearchForm()
        {
            string label = EnumHelpers.GetEnumDescription(ReservationSearchBy.PNRNumber);

            Console.WriteLine("{0}:", label);
            string input = Console.ReadLine();
            OnLoad(label, input);

            if (Reservations == null || Reservations?.Count() == 0)
                Console.WriteLine("\nReservations with {0}:{1} are not found\n", label, input);

            DisplayMainOptions();
        }

        private void View()
        {
            throw new NotImplementedException();
        }

        private void OpenAddForm()
        {
            // Form title
            Console.WriteLine("--------------Add a Reservation------------");

            string input = "";

            // Airline code field and flight number
            do
            {
                // Airline Code
                do
                {
                    Console.Write("Airline Code:");
                    input = Console.ReadLine();
                    Validate(new AirlineCodeValidator(), input);

                    if (IsSaveEnabled)
                    {
                        AirlineCode = input;
                    }

                } while (!IsSaveEnabled);

                // Flight number
                do
                {
                    Console.Write("Flight Number:");
                    input = Console.ReadLine();
                    Validate(new FlightNumberValidator(false,AirlineCode), input);

                    if (IsSaveEnabled)
                    {
                        FlightNumber = int.Parse(input);
                    }

                } while (!IsSaveEnabled);

                Validate(new FlightValidator(AirlineCode, FlightNumber),"");

            } while (!IsSaveEnabled);

            // Flight date
            do
            {
                Console.Write("Flight Date (mm/dd/yyyy):");
                input = Console.ReadLine();
                Validate(new FlightDateValidator(), input);

                if (IsSaveEnabled)
                {
                    FlightDate = DateParser.Parse(input);
                }

            } while (!IsSaveEnabled);

            // Number of passengers
            do
            {
                Console.Write("Number of Passengers:");
                input = Console.ReadLine();
                Validate(new NumPassengersValidator(), input);

                if (IsSaveEnabled)
                {
                    NumPassengers = int.Parse(input);
                }
            } while (!IsSaveEnabled);

            Passengers = new List<Passenger>();

            for(int i = 1; i <= NumPassengers; i++)
            {
                Console.WriteLine("-----------------------------------------------------");
                Console.WriteLine("\nEnter basic information of passenger# {0}",i);
                OpenPassengerForm();
                Console.WriteLine();
            }

            // submit field 
            do
            {
                Console.Write("Submit [y/n]: ");
                input = Console.ReadLine();

            } while (!IsConfirmOptionValid(input));


            char choice = input.ElementAt(0);

            if (choice == 89 || choice == 121)
            {
                if (Save != null)
                {
                    OnSave();
                }
                else
                {
                    ShowErrorMessage();
                }
            }

            DisplayMainOptions();

        }

        private bool IsConfirmOptionValid(string choice)
        {
            bool isValid = true;
            string errorMessage = "Please choose only between the letters [y] or [n]";

            if (choice.Count() != 1)
            {
                isValid = false;
            }

            if (choice.ElementAt(0) != 89 && choice.ElementAt(0) != 121 &&
               choice.ElementAt(0) != 78 && choice.ElementAt(0) != 110)
            {
                isValid = false;
            }

            if (isValid)
            {
                return true;
            }
            else
            {
                Console.WriteLine(errorMessage);
                return false;
            }
        }

        protected virtual void OnSave()
        {
            Save?.Invoke(this, EventArgs.Empty);
        }

        protected virtual void OnLoad(string description, object input)
        {
            ReservationSearchBy searchBy = EnumHelpers.GetValueFromDescription<ReservationSearchBy>(description);
            Load?.Invoke(this, new SearchArgs(searchBy, input));
        }


        public void OpenPassengerForm()
        {
            String input = "";
            String firstName = "";
            String lastName = "";
            DateTime birthday = DateTime.Now;

            // First Name
            do
            {
                Console.Write("First Name:");
                input = Console.ReadLine();
                Validate(new NameValidator(), input);

                if (IsSaveEnabled)
                {
                    firstName = input;
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
                    lastName = input;
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
                    birthday = DateParser.Parse(input);
                }

            } while (!IsSaveEnabled);

            if (IsSaveEnabled)
            {
                Passengers.Add(new Passenger()
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Birthday = birthday
                });
            }
           
        }

        public override void Open()
        {
            Console.WriteLine(ScreenTitle);
            DisplayMainOptions();
        }

        public void ShowPassengerView()
        {
            throw new NotImplementedException();
        }

        public void ShowSuccessMessage()
        {
            Console.WriteLine("Reservation is successfully added! \n");
            Console.WriteLine("PNR Number: {0} \n", PNRNumber);
        }

        public void ShowErrorMessage()
        {
            Console.WriteLine("Failed to submit the form \n");
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
