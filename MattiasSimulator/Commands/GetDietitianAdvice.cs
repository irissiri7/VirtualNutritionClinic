using System;
using System.Collections.Generic;
using System.Text;
using NutritionClinicLibrary;

namespace MattiasSimulator.Commands
{
    public class GetDietitianAdvice : ICommand
    {
        public string Name => "Get advice from dietitian";

        public string Execute(NutritionClinic someNutClin)
        {
            return someNutClin.Dietitian.GiveAdvice(someNutClin.CurrentClient);
        }
    }
}
