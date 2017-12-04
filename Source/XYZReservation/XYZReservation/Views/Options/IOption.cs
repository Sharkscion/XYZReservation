﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XYZReservation.Views
{
    public interface IOption
    {
        string Label { get; set; }
        void Execute();
    }

}
