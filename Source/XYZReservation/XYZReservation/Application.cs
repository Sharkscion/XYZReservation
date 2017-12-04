using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XYZReservation.Views;

namespace XYZReservation
{
    public class Application
    {
        private BaseScreen _StartScreen;

        public Application(BaseScreen screen)
        {
            _StartScreen = screen;
        }



        public void Start()
        {
            _StartScreen.Open();
        }
    }
}
