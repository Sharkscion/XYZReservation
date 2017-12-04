using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XYZReservation.Views
{
    public class SearchArgs : EventArgs
    {
        public Enum ParameterType { get; private set; }
        public object Input { get; set; }

        public SearchArgs(Enum paramType, object input)
        {
            ParameterType = paramType;
            Input = input;
        }
    }
}
