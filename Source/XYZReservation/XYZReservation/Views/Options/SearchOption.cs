using XYZReservation.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XYZReservation.Views
{
    public class SearchOption : IOption
    {
        public string Label { get; set; }

        public string Input { get; set; }

        public void Execute()
        {
            Console.Write("Enter {0}:", Label);
            Input = Console.ReadLine();
        }
    }
}
