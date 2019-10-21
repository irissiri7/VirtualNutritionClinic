using System;
using System.Collections.Generic;
using System.Text;
using NutritionClinicLibrary;

namespace MattiasSimulator.Commands
{
    public class DrinkCustomMadeSmoothie : ICommand
    {
        public string Name => "Drink Custom Made Smoothie";

        public string Execute(NutritionClinic someNutClin)
        {
            return someNutClin.CurrentClient.DrinkRandomSmoothie();

        }
    }
}
