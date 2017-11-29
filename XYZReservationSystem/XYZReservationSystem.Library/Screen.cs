using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XYZReservationSystem.Library
{
    public abstract class Screen
    {
        #region Private Properties
        private int _ChosenOption;

        private string _TitlePage;
        #endregion

        #region Public Methods

        public bool IsOptionValid(Enum enumOption, string input)
        {
            var IsNumeric = int.TryParse(input, out _ChosenOption);

            if (enumOption == null)
                throw new ArgumentNullException("enumOption");

            if (!IsNumeric)
            {
                return false;
            }

            if (!Enum.IsDefined(enumOption.GetType(), _ChosenOption))
            {
                return false;
            }

            return true;
        }

        public abstract void Close();

        public abstract void Print();

        public void Open()
        {
            
        }
        #endregion
    }
}
