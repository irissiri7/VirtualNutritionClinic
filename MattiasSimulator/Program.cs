using System;
using System.Collections.Generic;
using ConsoleSimulationEngine2000;
using NutritionClinicLibrary;

namespace MattiasSimulator
{
    class Program
    {
        static async System.Threading.Tasks.Task Main(string[] args)
        {
            //Setting up employees
            Dietitian theDietitian = new Dietitian("Louise", Employee.Positions.Dietitian);
            PersonalTrainer thePersonalTrainer = new PersonalTrainer("Mats", Employee.Positions.PersonalTrainer);

            //Setting up clinic
            NutritionClinic theClinic = NutritionClinic.CreateNutritionClinic("Mayo Foundation", theDietitian, thePersonalTrainer);

            //Setting up client
            Client theClient = new Client("Helena", 1.78F, 60.5F, theDietitian, thePersonalTrainer);

            var input = new TextInput();
            var gui = new ConsoleGUI() { Input = input };
            var sim = new MySimulation(gui, input, theClinic, theDietitian, thePersonalTrainer, theClient);
            await gui.Start(sim);

        }
    }

    public class MySimulation : Simulation
    {
        private RollingDisplay log = new RollingDisplay(0, 0, -1, 6);
        private BorderedDisplay patientDisplayCurrent = new BorderedDisplay(0, 5, 90, 3) { };
        private BorderedDisplay patientDisplayGoals = new BorderedDisplay(0, 7, 90, 3) { };
        private BorderedDisplay patientIntake = new BorderedDisplay(0, 9, 90, 3) { };
        private BorderedDisplay test = new BorderedDisplay(0,11, 90, 6) { };



        private readonly ConsoleGUI gui;
        private readonly TextInput input;

        private Dietitian theDietitian;
        private PersonalTrainer thePersonalTrainer;
        private NutritionClinic theClinic;
        private Client theClient;

        public override List<BaseDisplay> Displays => new List<BaseDisplay>() {
        log,
        patientDisplayCurrent,
        patientDisplayGoals,
        patientIntake,
        test,
        input.CreateDisplay(0, -3, -1) };

        public MySimulation(ConsoleGUI gui, TextInput input, NutritionClinic theClinic, Dietitian dt, PersonalTrainer pt, Client cl)
        {
            log.Log($"Welcome to the {theClinic.Name} nutrition clinic!");
            this.gui = gui;
            this.input = input;
            this.theClinic = theClinic;
            this.theDietitian = dt;
            this.thePersonalTrainer = pt;
            this.theClient = cl;

        }

        public override void PassTime(int deltaTime)
        {
            log.Log($"{deltaTime} milliseconds has passed");
            patientDisplayCurrent.Value = "CURRENT CLIENT: " + theClient.CurrentState();
            patientDisplayGoals.Value = "CLIENT GOALS: " + theClient.Goals();
            patientIntake.Value = "TODAYS INTAKE " + theClient.TodaysIntake();
            
            while (input.HasInput)
            {
                if(input.Consume() == "1")
                {
                    theClient.testmethod(test);
                }
            }
        }
    }
}
