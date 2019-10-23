using System;
using System.Collections.Generic;
using System.Text;
using NutritionClinicLibrary;

namespace MattiasSimulator.Commands
{
    public class GetPTAdvice : ICommand
    {
        public string Name => "Get advice from personal trainer";

        public string Execute(MySimulation sim)
        {
            return sim.theClinic.PersonalTrainer.GiveAdvice(sim.theClinic.CurrentClient);
        }
    }
}
