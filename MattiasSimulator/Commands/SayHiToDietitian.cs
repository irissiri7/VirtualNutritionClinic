using System;
using System.Collections.Generic;
using System.Text;
using NutritionClinicLibrary;

namespace MattiasSimulator.Commands
{
    public class SayHiToDietitian : ICommand
    {
        public string Name => "Say hi to dietitian";

        public string Execute(NutritionClinic someNutClin)
        {
            return someNutClin.Dietitian.Introduction();
        }
    }
}
