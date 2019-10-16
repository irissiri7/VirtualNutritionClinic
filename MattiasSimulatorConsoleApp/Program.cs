using System;
using System.Collections.Generic;
using ConsoleSimulationEngine2000;


namespace MattiasSimulatorConsoleApp
{
    class Program
    {
        static async System.Threading.Tasks.Task Main(string[] args)
        {
            var gui = new ConsoleGUI()
            {
                TargetUpdateTime = 100
            };
            var sim = new MySimulation();
            await gui.Start(sim);
        }
    }

    public class MySimulation : Simulation
    {
        private RollingDisplay log = new RollingDisplay(0, 0, -1, 12);
        private BorderedDisplay clockDisplay = new BorderedDisplay(0, 11, 20, 3) { };
        public override List<BaseDisplay> Displays => new List<BaseDisplay>() { log, clockDisplay, Input.CreateDisplay(0, -3, -1, 3) };

        //public override List<BaseDisplay> Displays => throw new NotImplementedException();

        public override void PassTime(int deltaTime)
        {
            log.Log($"{deltaTime} milliseconds has passed");
            clockDisplay.Value = DateTime.Now.ToString("HH:mm:ss");
            while (Input.HasInput)
            {
                log.Log("Input: " + Input.Consume());
            }
        }
    }
}

