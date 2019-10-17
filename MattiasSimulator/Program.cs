using System;
using System.Collections.Generic;
using ConsoleSimulationEngine2000;

namespace MattiasSimulator
{
    class Program
    {
        static async System.Threading.Tasks.Task Main(string[] args)
        {
            var gui = new ConsoleGUI();
            var input = new TextInput();

            var sim = new MySimulation(gui, input);
            await gui.Start(sim);
        }
    }

    public class MySimulation : Simulation
    {
        private RollingDisplay log = new RollingDisplay(0, 0, -1, 12);
        private BorderedDisplay clockDisplay = new BorderedDisplay(0, 11, 20, 3) { };
        private BorderedDisplay updateDisplay = new BorderedDisplay(0, 14, 20, 3) { };
        private BorderedDisplay renderDisplay = new BorderedDisplay(0, 17, 20, 3) { };
        private BorderedDisplay printDisplay = new BorderedDisplay(0, 20, 20, 3) { };
        private readonly ConsoleGUI gui;
        private readonly TextInput input;


        public override List<BaseDisplay> Displays => new List<BaseDisplay>() {
        log,
        clockDisplay,
        updateDisplay,
        renderDisplay,
        printDisplay,
        input.CreateDisplay(0, -3, -1) };

        public MySimulation(ConsoleGUI gui, TextInput input)
        {
            this.gui = gui;
            this.input = input;
        }
        public override void PassTime(int deltaTime)
        {
            log.Log($"{deltaTime} milliseconds has passed");
            clockDisplay.Value = DateTime.Now.ToString("HH:mm:ss");
            updateDisplay.Value = "Update: " + gui.LastUpdateTime.Milliseconds;
            renderDisplay.Value = "Render: " + gui.BackBufferRenderTime.Milliseconds;
            printDisplay.Value = "Print: " + gui.ScreenRenderTime.Milliseconds;
            while (input.HasInput)
            {
                log.Log("Input: " + input.Consume());
            }
        }
    }
}
