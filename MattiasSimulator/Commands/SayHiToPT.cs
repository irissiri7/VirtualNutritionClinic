using System;
using System.Collections.Generic;
using System.Text;
using NutritionClinicLibrary;

namespace MattiasSimulator.Commands
{
    public class SayHiToPT : ICommand
    {
        public string Name => "Say hi to personal trainer";
        
        public string Execute(NutritionClinic someNutClin)
        {
            return someNutClin.PersonalTrainer.Introduction();
        }
    }
}
