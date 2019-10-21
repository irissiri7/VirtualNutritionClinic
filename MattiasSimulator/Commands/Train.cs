using System;
using System.Collections.Generic;
using System.Text;
using NutritionClinicLibrary;

namespace MattiasSimulator
{
    public class Train : ICommand
    {
        public string Name => "Train";

        public string Execute(NutritionClinic someNutClin)
        {
            return $"{someNutClin.CurrentClient.Name} trained! {someNutClin.CurrentClient.Train()}";
        }
    }
}
