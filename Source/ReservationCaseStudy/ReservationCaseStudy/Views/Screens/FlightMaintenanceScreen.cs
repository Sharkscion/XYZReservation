using ReservationCaseStudy.Helpers;
using ReservationCaseStudy.Models;
using ReservationCaseStudy.Presenters;
using ReservationCaseStudy.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationCaseStudy.Views
{

    public class FlightMaintenanceScreen : BaseScreen, IManageFlightView
    {
        private List<IOption> _searchOptions;
        private List<Flight> _flights;
        private BaseValidator _validator;

        public event EventHandler Save;
        public event EventHandler<SearchArgs> Load;

        public bool IsSaveEnabled { get; set; } = true;
        public List<Flight> Flights {
            get
            {
                return _flights;
            }

            set
            {
                _flights = value;
                DisplayFlights();
            }
        }

        public string AirlineCode { get; set; }
        public int FlightNumber { get; set; }
        public string ArrivalStationCode { get; set; }
        public string DepartureStationCode { get; set; }
        public TimeSpan ScheduledTimeArrival { get; set; }
        public TimeSpan ScheduledTimeDeparture { get ; set; }

        public BaseValidator BaseValidator { get; set; }

        public FlightMaintenanceScreen()
        {
            ScreenTitle = "Manage XYZ Flights";
            MainOptions = new List<IOption>
            {
                new OperationOption(OpenAddForm){Label = "Add a flight"},
                new OperationOption(OpenSearchForm){Label = "Search a flight"},
                new GoToScreenOption{Label = "Go Home", Screen =  ApplicationScreen.Home},
                new ExitOption()
            };
        }

        private void OpenSearchForm()
        {
            InitSearchOptions();

            DisplaySearchOptions();

            int chosenOption = AskUserForOption(_searchOptions) - 1;
            
            SearchOption searchOption = (SearchOption) _searchOptions.ElementAt(chosenOption);
            searchOption.Execute();

            FlightSearchBy searchBy = EnumHelpers.GetValueFromDescription<FlightSearchBy>(searchOption.Label);

            if(searchBy == FlightSearchBy.AirlineCode)
            {
                do
                {
                    Validate(new AirlineCodeValidator(), searchOption.Input);

                    if (!IsSaveEnabled)
                    {
                        searchOption.Execute();
                    }
                    else
                    {
                        OnLoad(searchOption.Label, searchOption.Input);
                    }

                } while (!IsSaveEnabled);
            }

            else if (searchBy == FlightSearchBy.FlightNumber)
            {
                do
                {
                    Validate(new FlightNumberValidator(false), searchOption.Input);

                    if (!IsSaveEnabled)
                    {
                        searchOption.Execute();
                    }
                    else
                    {
                        OnLoad(searchOption.Label, int.Parse(searchOption.Input));
                    }

                } while (!IsSaveEnabled);
            }

            else if (searchBy == FlightSearchBy.OriginDestination)
            {
                do
                {
                    Validate(new StationValidator(), searchOption.Input);

                    if (!IsSaveEnabled)
                    {
                        searchOption.Execute();
                    }
                    else
                    {
                        OnLoad(searchOption.Label, searchOption.Input);
                    }

                } while (!IsSaveEnabled);
            }

            if (Flights == null || Flights?.Count() == 0)
                Console.WriteLine("\nFlights with {0}:{1} are not found\n", searchOption.Label, searchOption.Input);

            DisplayMainOptions();
        }
     
        private void OpenAddForm()
        {
            // Form title
            Console.WriteLine("--------------Add a Flight Form------------");
           
            string input = "";

            // Airline code field
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
                Validate(new FlightNumberValidator(true,AirlineCode), input);

                if (IsSaveEnabled)
                {
                    FlightNumber = int.Parse(input);
                }

            } while (!IsSaveEnabled);
            
           
            // Arrival station code field
            do
            {
                Console.Write("Arrival Station Code:");
                input = Console.ReadLine();
                Validate(new StationValidator(), input);

                if (IsSaveEnabled)
                {
                    ArrivalStationCode = input;
                }

            } while (!IsSaveEnabled);
            
        

            // Departure station code field
            do
            {
                Console.Write("Departure Station Code:");
                input = Console.ReadLine();
                Validate(new StationValidator(ArrivalStationCode), input);

                if (IsSaveEnabled)
                {
                    DepartureStationCode = input;
                }

            } while (!IsSaveEnabled);
            
           

            // Scheduled time arrival field
            do
            {
                Console.Write("Scheduled time arrival (hh:mm):");
                input = Console.ReadLine();
                Validate(new TimeValidator(), input);

                if (IsSaveEnabled)
                {
                    ScheduledTimeArrival = TimeSpan.Parse(input);
                }

            } while (!IsSaveEnabled);

            // Scheduled time departure field
            do
            {
                Console.Write("Scheduled time departure (hh:mm):");
                input = Console.ReadLine();
                Validate(new TimeValidator(), input);

                if (IsSaveEnabled)
                {
                    ScheduledTimeDeparture = TimeSpan.Parse(input);
                }

            } while (!IsSaveEnabled);
            
       
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

        private void DisplaySearchOptions()
        {
            for (int i = 0; i < _searchOptions.Count(); i++)
            {
                Console.WriteLine("[{0}] {1}", i + 1, _searchOptions.ElementAt(i).Label);
            }
        }

        private void InitSearchOptions()
        {
            _searchOptions = new List<IOption>();
            var options = EnumHelpers.GetEnumList<FlightSearchBy>();

            for (int i = 1; i < options.Count(); i++)
            {
                _searchOptions.Add(new SearchOption() { Label = options.ElementAt(i) });
            }
        }

        protected virtual void OnSave()
        {
            Save?.Invoke(this, EventArgs.Empty);
        }

        protected virtual void OnLoad(string description, object input)
        {
            FlightSearchBy searchBy = EnumHelpers.GetValueFromDescription<FlightSearchBy>(description);
            Load?.Invoke(this, new SearchArgs(searchBy, input));
        }

        public override void Open()
        {
            Console.WriteLine(ScreenTitle);
            DisplayMainOptions();
        }

        public void AskSearchValue(object value)
        {
            Console.WriteLine("asdjkasd");
            Console.WriteLine("Hello {0}:", value);
            Console.ReadLine();
        }

        public void DisplayFlights()
        {
            if(Flights != null)
            {
                Console.WriteLine("-------------------------------------------------------------------------------------------------------------");
                Console.WriteLine("| {0, -15} {1, -15} {2, -20} {3, -20} {4, -15} {5, -15} |", "Airline Code", "Flight Number", "Arrival Station", "Departure Station", "STA", "STD");
                Console.WriteLine("-------------------------------------------------------------------------------------------------------------");

                foreach (var flight in Flights)
                {
                    Console.WriteLine("| {0, -15} {1, -15} {2, -20} {3, -20} {4, -15} {5, -15} |", 
                        flight.AirlineCode, 
                        flight.Number, 
                        flight.ArrivalStationCode, 
                        flight.DepartureStationCode, 
                        flight.ScheduledTimeArrival.ToString(), 
                        flight.ScheduledTimeDeparture.ToString());
                }

                Console.WriteLine("-------------------------------------------------------------------------------------------------------------");
            }
            
        }

        public void ShowSuccessMessage()
        {
            Console.WriteLine("Flight is successfully added! \n");
        }

        public void ShowErrorMessage()
        {
            Console.WriteLine("Failed to submit the form \n");
        }

        public void Validate(BaseValidator validator, string input)
        {
            _validator = validator;
            IsSaveEnabled = _validator.IsValid(input);

            if(!IsSaveEnabled)
            {
                Console.WriteLine(_validator.ErrorMessage);
            }
        }
    }
}
