using ReservationCaseStudy.Library.Models;
using ReservationCaseStudy.Library.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationCaseStudy.Library.Views
{
    public class FlightMaintenanceScreen : BaseScreen, IManageFlightView
    {
        public bool IsSaveEnabled { get; set; } = true;
        public List<Flight> Flights { get; set; }
        public Action<string> SetAirlineCode { get; set; }
        public Action<string> SetFlightNumber { get; set; }
        public Action<string> SetArrivalStationCode { get; set; }
        public Action<string> SetDepartureStationCode { get; set; } 
        public Action<string> SetScheduledTimeArrival { get; set; } 
        public Action<string> SetScheduledTimeDeparture { get; set; }                                                                                                                                                                                                                                                                                                                                    
        public Action Save { get; set; }
        public Action<Enum> Load { get; set; }

        public FlightMaintenanceScreen()
        {
            Options = new List<IOption>
            {
                new OperationOption(OpenAddForm){Label = "Add a flight"},
                new OperationOption(Search){Label = "Search a flight"},
                new GoToScreenOption{Label = "Go Home", Screen =  ApplicationScreen.Home},
                new ExitOption()
            };
        }

        private void Search()
        {
            throw new NotImplementedException();
        }

        public void OpenAddForm()
        {
            // Form title
            Console.WriteLine("--------------Add a Flight Form------------");

            
            string input = "";

            // Airline code field
            if (SetAirlineCode != null)
            {
                do
                {
                    Console.Write("Airline Code:");
                    input = Console.ReadLine();
                    SetAirlineCode(input);

                } while (!IsSaveEnabled);
            }

            // Flight number
            if (SetFlightNumber != null)
            {
                do
                {
                    Console.Write("Flight Number:");
                    input = Console.ReadLine();
                    SetFlightNumber(input);

                } while (!IsSaveEnabled);
            }
           
            // Arrival station code field
            if(SetArrivalStationCode != null)
            {
                do
                {
                    Console.Write("Arrival Station Code:");
                    input = Console.ReadLine();
                    SetArrivalStationCode(input);
                } while (!IsSaveEnabled);
            }
        

            // Departure station code field
            if(SetDepartureStationCode != null)
            {
                do
                {
                    Console.Write("Departure Station Code:");
                    input = Console.ReadLine();
                    SetDepartureStationCode(input);
                } while (!IsSaveEnabled);
            }
           

            // Scheduled time arrival field
            if(SetScheduledTimeArrival != null)
            {
                do
                {
                    Console.Write("Scheduled time arrival (hh:mm):");
                    input = Console.ReadLine();
                    SetScheduledTimeArrival(input);

                } while (!IsSaveEnabled);
            }

            // Scheduled time departure field
            if(SetScheduledTimeDeparture != null)
            {
                do
                {
                    Console.Write("Scheduled time departure (hh:mm):");
                    input = Console.ReadLine();
                    SetScheduledTimeDeparture(input);
                } while (!IsSaveEnabled);
            }
       
            // submit field
            do
            {
                Console.Write("Submit [y/n]: ");
                input = Console.ReadLine();

            } while (!IsValidSubmitOption(input));


            char choice = input.ElementAt(0);

            if (choice == 89 || choice == 121)
            {
                if (Save != null)
                {
                    Save();
                    Console.WriteLine("Flight is successfully added! \n");
                }
                else
                {
                    Console.WriteLine("Failed to submit the form \n");
                }
            }
            
            DisplayOptions();
            
            
        }

        public bool IsValidSubmitOption(string choice)
        {
            bool isValid = true;
            string errorMessage = "Please choose only between the letters [y] or [n]";

            if (choice.Count() != 1)
            {
                isValid = false;
            }

            if(choice.ElementAt(0) != 89 && choice.ElementAt(0) != 121 &&
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

        public override void Open()
        {
            Console.WriteLine(ScreenTitle);
            DisplayOptions();
        }

        public void ShowMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}
