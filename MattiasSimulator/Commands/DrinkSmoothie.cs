using System;
using System.Collections.Generic;
using System.Text;
using NutritionClinicLibrary;

namespace MattiasSimulator.Commands
{
    public class DrinkSmoothie : ICommand
    {
        public string Name => "Drink Smoothie";

        public string Execute(NutritionClinic someNutClin)
        {
            return "Welcome to the Smoothie Bar. Pick two ingredients for your smoothie";

        }
    }
}
