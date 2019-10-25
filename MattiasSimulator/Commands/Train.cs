using System;
using System.Collections.Generic;
using System.Text;
using NutritionClinicLibrary;

namespace MattiasSimulator
{
    public class Train : ICommand
    {
        public string Name => "Train";

        public string Execute(MySimulation sim)
        {
            return $"{sim.TheClinic.CurrentClient.Name} trained! {sim.TheClinic.CurrentClient.Train()}";
        }
    }
}
