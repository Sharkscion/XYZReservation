using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationCaseStudy
{
    public abstract class BaseScreen
    {
        #region Private Fields

        private int _ChosenOption;

        #endregion

        #region Protected Fields        
        protected List<IOption> Options;
        #endregion

        #region Public Fields
        public string ScreenTitle { get; set; }
        #endregion

        #region Private Methods
        private void ExecuteCommand()
        {
            Close();
            Options.ElementAt(_ChosenOption).Execute();
        }

        private int AskUserForMenuOption()
        {
            Console.Write("Chosen Option: ");
            var input = Console.ReadLine();
            int result = -1;

            while (!int.TryParse(input, out result) || result > Options.Count() || result < 1)
            {
                Console.WriteLine("Invalid option. Please choose only between 1 to " + Options.Count());
                Console.Write("Chosen Option: ");
                input = Console.ReadLine();
            }

            return result;
        }
        #endregion

        #region Public Methods
        public void Display(object value)
        {
            Console.WriteLine(value);

        }

        public abstract void Open();
       

        public void DisplayOptions()
        {
            if (Options != null)
            {
                for (int i = 1; i <= Options.Count; i++)
                {
                    Console.WriteLine("[{0}] {1}", i, Options.ElementAt(i - 1).Label);
                }

                _ChosenOption = AskUserForMenuOption() - 1;
                ExecuteCommand();
            }
        }

        public void Close()
        {
            Console.Clear();
        } 
        #endregion

    }
}
