using XYZReservation.Helpers;
using XYZReservation.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XYZReservation.Views
{
    public interface IManageView: IView
    {
        bool IsSaveEnabled { get; set; }

        event EventHandler<SearchArgs> Load;

        void ShowSuccessMessage();
        void ShowErrorMessage();
        void Validate(BaseValidator validator, string input);
    }
}
