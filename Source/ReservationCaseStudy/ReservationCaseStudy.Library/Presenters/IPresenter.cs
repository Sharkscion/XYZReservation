using ReservationCaseStudy.Library.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationCaseStudy.Library.Presenters
{
    //event receiver
    public interface IPresenter<V> where V : IManageView
    {
        V View { get; set; }
        void OnSave();
        void OnLoad();
    }
}
