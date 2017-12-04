using ReservationCaseStudy.Helpers;
using ReservationCaseStudy.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationCaseStudy.Views
{
    public interface IManageView: IView
    {
        bool IsSaveEnabled { get; set; }

        event EventHandler Save;
        event EventHandler<SearchArgs> Load;

        void ShowSuccessMessage();
        void ShowErrorMessage();
        void Validate(BaseValidator validator, string input);
    }
}
