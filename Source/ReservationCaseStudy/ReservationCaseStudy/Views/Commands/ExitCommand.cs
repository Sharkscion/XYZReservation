﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationCaseStudy
{
    public class ExitCommand : IMenuCommand
    {
        public string Label { get; set; } = "Quit";

        public void Execute()
        {
            Environment.Exit(0);
        }
    }
}
