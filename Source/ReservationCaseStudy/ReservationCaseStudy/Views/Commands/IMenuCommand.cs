using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationCaseStudy
{
    public interface IMenuCommand
    {
        string Label { get; set; }
        void Execute();
    }
}
