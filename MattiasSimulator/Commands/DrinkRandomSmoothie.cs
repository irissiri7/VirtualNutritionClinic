using System;
using System.Collections.Generic;
using System.Text;
using NutritionClinicLibrary;

namespace MattiasSimulator
{
    public class DrinkRandomSmoothie : ICommand
    {
        public string Name => "Drink Random Smoothie";

        public string Execute(NutritionClinic someNutClin)
        {
            return someNutClin.CurrentClient.DrinkRandomSmoothie();

        }
    }
}
