using System;
using System.Collections.Generic;
using System.Text;
using ConsoleSimulationEngine2000;
using NutritionClinicLibrary;
using Pastel;
using System.Drawing;
using MattiasSimulator.Commands;

namespace MattiasSimulator
{
    public class StandardState : State
    {
        private List<ICommand> CommandList { get =>
                new List<ICommand>
                {
                    new SayHiToDietitian(),
                    new SayHiToPT(),
                    new GetDietitianAdvice(),
                    new GetPTAdvice(),
                    new DrinkSmoothie(),
                    new Train(),
                };
        }
        
        public StandardState(string title) : base(title)
        {
        }

        public override string FillCommandBox()
        {
            StringBuilder commands = new StringBuilder();
            commands.Append($"Available Commands: {Environment.NewLine}");
            int count = 0;
            foreach (ICommand c in CommandList)
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
                try
                {
                sim.messageBoard.Log(CommandList[index].Execute(sim));
                }
                catch (ArgumentOutOfRangeException)
                {
                    sim.messageBoard.Log("Not a valid command");
                }
            }
        }
        
        
    }
}
