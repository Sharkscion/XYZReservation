using XYZReservation.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XYZReservation.Views
{
    public abstract class BaseScreen : IView
    {
        #region Private Fields

        private int _ChosenOption;

        #endregion

        #region Protected Fields        
        protected List<IOption> MainOptions;
        #endregion

        #region Public Fields
        public string ScreenTitle { get; set; }
        #endregion

        #region Private Methods
   
        public int AskUserForOption(List<IOption> options)
        {
            Console.Write("Enter Option: ");
            var input = Console.ReadLine();
            int result = -1;

            while (!int.TryParse(input, out result) || result > options.Count() || result < 1)
            {
                Console.WriteLine("Invalid option. Please choose only between 1 to " + options.Count());
                Console.Write("Enter Option: ");
                input = Console.ReadLine();
            }

            return result;
        }
        #endregion

        #region Public Methods
        
        public void DisplayMainOptions()
        {
            if (MainOptions != null)
            {
                for (int i = 1; i <= MainOptions.Count; i++)
                {
                    Console.WriteLine("[{0}] {1}", i, MainOptions.ElementAt(i - 1).Label);
                }

                _ChosenOption = AskUserForOption(MainOptions) - 1;

                Clear();
                MainOptions.ElementAt(_ChosenOption).Execute();
            }
        }

        public void Clear()
        {
            Console.Clear();
        }

        public abstract void Open();
        #endregion

    }
}
