using System;
using System.Collections.Generic;
using ConsoleSimulationEngine2000;
using MattiasSimulator.Commands;
using NutritionClinicLibrary;
using Pastel;
using System.Drawing;

namespace MattiasSimulator
{
    public class MySimulation : Simulation
    {
        public BorderedDisplay headerMessageBoard = new BorderedDisplay(0, 0, 25, 3) { };
        public RollingDisplay messageBoard = new RollingDisplay(0, 2, 90, 21) { };
        public BorderedDisplay commandBox = new BorderedDisplay(0, 22, 90, 10) { };
        public BorderedDisplay patientInfo = new BorderedDisplay(95, 2, 50, 20) { };
        public BorderedDisplay clockDisplay = new BorderedDisplay(95, 20, 50, 3) { };
        public BorderedDisplay clinicInfo = new BorderedDisplay(95, 22, 50, 10) { };


        private readonly TextInput input;
        public State simState;

        private DateTime startTime;
        private DateTime runningTime;

        public NutritionClinic theClinic { get; set; }
        private Dietitian theDietitian { get => theClinic.Dietitian; }
        private PersonalTrainer thePersonalTrainer { get => theClinic.PersonalTrainer; }
        private Client CurrentClient { get => theClinic.CurrentClient; }

        public override List<BaseDisplay> Displays => new List<BaseDisplay>() {
        headerMessageBoard,
        messageBoard,
        patientInfo,
        clockDisplay,
        commandBox,
        clinicInfo,
        input.CreateDisplay(0, -3, -1) };

        public MySimulation(TextInput input, NutritionClinic theClinic)
        {
            this.input = input;
            startTime = DateTime.Now;
            runningTime = DateTime.Now;
            this.theClinic = theClinic;
            simState = new StandardState("MESSAGEBOARD");

            messageBoard.Log($"This is the {theClinic.Name} nutrition clinic!");
            messageBoard.Log($"We help people get back in shape. Lets start by signing in a new client!");
            messageBoard.Log(theClinic.SignInNewClient(ClientGenerator.GenerateRandomClient(theClinic)));

        }

        public override void PassTime(int deltaTime)
        {
            runningTime = runningTime.AddMinutes(30).AddMilliseconds(deltaTime);

            patientInfo.Value = $"CURRENT CLIENT: {Environment.NewLine}{CurrentClient.GetCurrentState()}{Environment.NewLine}{Environment.NewLine}CLIENT GOALS: {Environment.NewLine}{CurrentClient.GetGoals()}{Environment.NewLine}{Environment.NewLine}TODAYS INTAKE:{Environment.NewLine}{CurrentClient.GetTodaysIntake()}";
            clockDisplay.Value = "Current time: " + runningTime.ToString("HH:mm:ss");
            clinicInfo.Value = $"CLINIC NAME: {theClinic.Name} {Environment.NewLine}{Environment.NewLine}CLINIC STAFF: {Environment.NewLine}{theDietitian.Position}: {theDietitian.Name} {Environment.NewLine}{thePersonalTrainer.Position}: {thePersonalTrainer.Name} {Environment.NewLine}{Environment.NewLine}CLIENTS HELPED:{Environment.NewLine}{theClinic.ClientRecord.Count - 1}";

            if (runningTime.Day > startTime.Day)
            {
                messageBoard.Log("It's a new day! Let's check the progress:");
                messageBoard.Log(CurrentClient.CheckTodaysIntake());
                startTime = runningTime;
            }
            if (CurrentClient.NeedsHozpitalization())
            {
                messageBoard.Log("Oups, this has gotten out of hand");
                messageBoard.Log($"{CurrentClient.Name} is dangerouzly underweight and needs hospital care");
                messageBoard.Log($"Bye {CurrentClient.Name} hope you feel better soon");
                messageBoard.Log($"Let's sign in a new patient");
                messageBoard.Log(theClinic.SignInNewClient(ClientGenerator.GenerateRandomClient(theClinic)));
            }
            if (CurrentClient.HasReachedNormalWeight())
            {
                messageBoard.Log("Congrats, the client has reached normal BMI!");
                messageBoard.Log($"We will sign him/her out and sign in a new client {Environment.NewLine}");
                messageBoard.Log(theClinic.SignInNewClient(ClientGenerator.GenerateRandomClient(theClinic)));
            }

            
            headerMessageBoard.Value = simState.title;
            commandBox.Value = simState.FillCommandBox();

            while (input.HasInput)
            {
                string command = input.Consume();
                simState.HandleInput(command, this); 
            }
            
            messageBoard.Log("");
        }

        

        
    }
}
