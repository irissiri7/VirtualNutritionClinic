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
            return $"{sim.theClinic.CurrentClient.Name} trained! {sim.theClinic.CurrentClient.Train()}";
        }
    }
}
