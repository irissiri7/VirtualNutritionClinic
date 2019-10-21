﻿using System;
using System.Collections.Generic;
using System.Text;
using NutritionClinicLibrary;

namespace MattiasSimulator
{
    interface ICommand
    {
        public string Name { get; }

        string Execute(NutritionClinic someNutClin);
    }
}
