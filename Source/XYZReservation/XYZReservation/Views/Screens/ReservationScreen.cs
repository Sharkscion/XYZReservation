using System;
using System.Collections.Generic;
using System.Linq;
using XYZReservation.Helpers;
using XYZReservation.Models;
using XYZReservation.Presenters;

namespace XYZReservation.Views
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
                new OperationOption(OpenViewReservations){Label = "View all reservations"},
                new OperationOption(OpenSearchForm){Label = "Search reservations"},
                new GoToScreenOption{Label = "Go Home", Screen = ApplicationScreen.Home},
                new ExitOption()
            };
        }

        public event EventHandler Save;
        public event EventHandler<SearchArgs> Load;
        private void DisplayReservationSummary()
        {
            Console.WriteLine("-------------------------------------------------------------------------------------------");
            Console.WriteLine("| {0, -15} {1, -20} {2, -15} {3, -15} |", "Airline Code", "Flight Number", "Flight Date", "Passenger Count");
            Console.WriteLine("-------------------------------------------------------------------------------------------");

            Console.WriteLine("| {0, -15} {1, -20} {2, -15} {3, -15} |",
                                AirlineCode,
                                FlightNumber.ToString(StringFormats.DISPLAY_FORMAT_FLIGHTNUMBER),
                                FlightDate.ToString(StringFormats.STANDARD_DATE_FORMAT),
                                NumPassengers);

            if (Passengers != null)
            {
                Console.WriteLine("-------------------------------------------------------------------------------------------");

                Console.WriteLine("| {0, -15} {1, -15} {2, -20} {3, -31} |",
                            "First Name",
                            "Last Name",
                            "Birthday",
                            "Age");

                foreach (var passenger in Passengers)
                {
                    Console.WriteLine("| {0, -15} {1, -15} {2, -20} {3, -31} |",
                                passenger.FirstName,
                                passenger.LastName,
                                passenger.Birthday.ToString(StringFormats.STANDARD_DATE_FORMAT),
                                passenger.Age);
                }

                Console.WriteLine("-------------------------------------------------------------------------------------------");

            }
        }

        private void DisplayReservations()
        {
            if(Reservations != null)
            {
                Console.WriteLine("-------------------------------------------------------------------------------------------");
                Console.WriteLine("| {0, -15} {1, -15} {2, -20} {3, -15} {4, -15} |", "PNR Number", "Airline Code", "Flight Number", "Flight Date", "Passenger Count");
                Console.WriteLine("-------------------------------------------------------------------------------------------");

                foreach (var reservaton in Reservations)
                {
                    Console.WriteLine("| {0, -15} {1, -15} {2, -20} {3, -15} {4, -15} |", 
                                    reservaton.PNRNumber,
                                    reservaton.FlightAirlineCode, 
                                    reservaton.FlightNumber.ToString(StringFormats.DISPLAY_FORMAT_FLIGHTNUMBER), 
                                    reservaton.FlightDate.ToString(StringFormats.STANDARD_DATE_FORMAT),
                                    reservaton.NumPassengers);

                    if(reservaton?.Passengers != null)
                    {
                        Console.WriteLine("-------------------------------------------------------------------------------------------");

                        Console.WriteLine("| {0, -15} {1, -15} {2, -20} {3, -31} |",
                                    "First Name",
                                    "Last Name",
                                    "Birthday",
                                    "Age");

                        foreach (var passenger in reservaton?.Passengers)
                        {
                            Console.WriteLine("| {0, -15} {1, -15} {2, -20} {3, -31} |",
                                        passenger.FirstName,
                                        passenger.LastName,
                                        passenger.Birthday.ToString(StringFormats.STANDARD_DATE_FORMAT),
                                        passenger.Age);
                        }

                        Console.WriteLine("-------------------------------------------------------------------------------------------");
                    }
                }
            }
        }

        private void OpenSearchForm()
        {
            string label = EnumHelpers.GetEnumDescription(ReservationSearchBy.PNRNumber);
            Console.Write("{0}:", label);
            string input = Console.ReadLine();
            OnLoad(label, input);

            if (Reservations == null || Reservations?.Count() == 0)
                Console.WriteLine("\nReservations with {0}:{1} are not found\n", label, input);

            DisplayMainOptions();
        }

        private void OpenViewReservations()
        {
            OnLoad(EnumHelpers.GetEnumDescription(ReservationSearchBy.All),"");

            DisplayMainOptions();
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
                        AirlineCode = input.ToUpper();
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

                AddPassengerView addPassengerView = new AddPassengerView();
                addPassengerView.Save += (s, a) =>
                {
                    Passengers.Add(new Passenger()
                    {
                        FirstName = addPassengerView.FirstName,
                        LastName = addPassengerView.LastName,
                        Birthday = addPassengerView.Birthday
                    });
                };
                addPassengerView.Open();
                Console.WriteLine();
            }


            DisplayReservationSummary();


            // submit field 
            do
            {
                Console.Write("\nSubmit [y/n]: ");
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

            if (choice.Count() != 1)
            {
                Console.WriteLine("Please enter an option either [y] or [n]");
                return false;
            }

            if (choice.ElementAt(0) != 89 && choice.ElementAt(0) != 121 &&
               choice.ElementAt(0) != 78 && choice.ElementAt(0) != 110)
            {
                Console.WriteLine("Please choose only between the letters [y] or [n]");
                return false;
            }

            return true;
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

        public override void Open()
        {
            Console.WriteLine(ScreenTitle);
            DisplayMainOptions();
        }

        public void ShowSuccessMessage()
        {
            Console.WriteLine("\nReservation is successfully added!");
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
