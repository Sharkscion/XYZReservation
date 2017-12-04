using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationCaseStudy.Views
{
    public class OperationOption : IOption
    {
        private Action _Action;

        public string Label { get; set; }

        public OperationOption(Action action)
        {
            _Action = action;
        }
        
        public void Execute()
        {
            _Action();
        }
    }
}
