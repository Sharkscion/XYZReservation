using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationCaseStudy
{
    public class GoToScreenCommand : IMenuCommand
    {
        public string Label { get; set; }

        public ApplicationScreen Screen { get; set; }

        public void Execute()
        {
            ScreenFactory.GenerateScreen(Screen).Open();
        }
    }
}
