using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationCaseStudy
{
    class Program
    {
        static void Main(string[] args)
        {
            HomeScreen homeScreen = new HomeScreen();
            Application app = new Application(homeScreen);
            app.Start();
            
        }
    }
}
