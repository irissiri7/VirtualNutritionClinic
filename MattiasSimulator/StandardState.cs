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
        private readonly List<ICommand> commandList;
        
        public StandardState(string title, List<ICommand> commandList) : base(title)
        {
            this.commandList = commandList;
        }

        public override string FillCommandBox()
        {
            StringBuilder commands = new StringBuilder();
            commands.Append($"Available Commands: {Environment.NewLine}");
            int count = 0;
            foreach (ICommand c in commandList)
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
