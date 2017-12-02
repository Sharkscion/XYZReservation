using ReservationCaseStudy.Library.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationCaseStudy.Library.Views
{
    //event publisher
    public interface IManageView: IView
    {
        bool IsSaveEnabled { get; set; } 
        Action Save { get; set; }
        Action<Enum> Load { get; set; }
        
        void ShowMessage(string message);
    }
}
