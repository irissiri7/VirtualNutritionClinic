using System;
using System.Collections.Generic;
using System.Text;
using ConsoleSimulationEngine2000;
using NutritionClinicLibrary;
using Pastel;
using System.Drawing;

namespace MattiasSimulator
{
    public class StandardState : State
    {
        public StandardState(string title) : base(title)
        {
        }

        public override string FillCommandBox(MySimulation sim)
        {
            StringBuilder commands = new StringBuilder();
            commands.Append($"Available Commands: {Environment.NewLine}");
            int count = 0;
            foreach (ICommand c in sim.Commands)
            {
                commands.Append($"[{count}] {c.Name} {Environment.NewLine}");
                count++;
            }

            return commands.ToString();
        }

        public override void HandleInput(string command, MySimulation sim)
        {
            int index;

            if (int.TryParse(command, out index))
            {
                sim.messageBoard.Log(sim.Commands[index].Execute(sim));
            }
        }
        
        
    }
}
