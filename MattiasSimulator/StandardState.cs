using System;
using System.Collections.Generic;
using System.Text;
using ConsoleSimulationEngine2000;
using NutritionClinicLibrary;

namespace MattiasSimulator
{
    public class StandardState : State
    {
        public StandardState(string title) : base(title)
        {
        }

        public override string FillCommandBox(MySimulation sim)
        {
            return sim.ConstructCommandOptions();
        }

        public override void HandleInput(string command, MySimulation sim)
        {
            int indexForCommand;

            if (int.TryParse(command, out indexForCommand))
            {
                if (sim.Commands[indexForCommand].Name.Equals("Drink Smoothie"))
                {
                    sim.messageBoard.Log("Welcome to the Smoothie Bar! Pick two ingredients");
                    sim.simState = new SmoothieState("SMOOTHIE BAR");
                }
                else
                {
                    sim.messageBoard.Log(sim.Commands[indexForCommand].Execute(sim.theClinic));
                }

            }
        }
        
        
    }
}
