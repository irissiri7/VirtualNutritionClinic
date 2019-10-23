using System;
using System.Collections.Generic;
using System.Text;
using NutritionClinicLibrary;

namespace MattiasSimulator.Commands
{
    public class SayHiToPT : ICommand
    {
        public string Name => "Say hi to personal trainer";
        
        public string Execute(MySimulation sim)
        {
            return sim.theClinic.PersonalTrainer.Introduction();
        }
    }
}
