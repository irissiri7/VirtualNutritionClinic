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
        //FIELDS
        private BorderedDisplay headerMessageBoard = new BorderedDisplay(0, 0, 25, 3) { };
        public readonly RollingDisplay messageBoard = new RollingDisplay(0, 2, 90, 21) { };
        private BorderedDisplay commandBox = new BorderedDisplay(0, 22, 90, 10) { };
        private BorderedDisplay patientInfo = new BorderedDisplay(95, 2, 50, 20) { };
        private BorderedDisplay clockDisplay = new BorderedDisplay(95, 20, 50, 3) { };
        private BorderedDisplay clinicInfo = new BorderedDisplay(95, 22, 50, 10) { };


        private readonly TextInput input;
        public State simState;
        private DateTime startTime;
        private DateTime runningTime;

        //PROPERTIES
        public NutritionClinic TheClinic { get; private set; }
        private Dietitian TheDietitian => TheClinic.Dietitian; 
        private PersonalTrainer ThePersonalTrainer  => TheClinic.PersonalTrainer; 
        private Client CurrentClient  => TheClinic.CurrentClient; 

        public override List<BaseDisplay> Displays => new List<BaseDisplay>() {
        headerMessageBoard,
        messageBoard,
        patientInfo,
        clockDisplay,
        commandBox,
        clinicInfo,
        input.CreateDisplay(0, -3, -1) };

        //CONSTRUCTOR
        public MySimulation(TextInput input, NutritionClinic theClinic)
        {
            this.input = input;
            startTime = DateTime.Now;
            runningTime = DateTime.Now;
            this.TheClinic = theClinic;
            simState = new StandardState("MESSAGEBOARD");

            messageBoard.Log($"This is the {theClinic.Name} nutrition clinic!");
            messageBoard.Log($"We help people get back in shape. Lets start by signing in a new client!");
            messageBoard.Log(theClinic.SignInNewClient(ClientGenerator.GenerateRandomClient(theClinic)));

        }

        //METHODS
        public override void PassTime(int deltaTime)
        {
            runningTime = runningTime.AddMinutes(30).AddMilliseconds(deltaTime);

            patientInfo.Value = 
                $"CURRENT CLIENT: {Environment.NewLine}{CurrentClient.GetCurrentState()}{Environment.NewLine}{Environment.NewLine}" +
                $"CLIENT GOALS: {Environment.NewLine}{CurrentClient.GetGoals()}{Environment.NewLine}{Environment.NewLine}" +
                $"TODAYS INTAKE:{Environment.NewLine}{CurrentClient.GetTodaysIntake()}";
            
            clockDisplay.Value = "Current time: " + runningTime.ToString("HH:mm:ss");
            clinicInfo.Value = $"CLINIC NAME: {TheClinic.Name} {Environment.NewLine}{Environment.NewLine}CLINIC STAFF: {Environment.NewLine}{TheDietitian.Position}: {TheDietitian.Name} {Environment.NewLine}{ThePersonalTrainer.Position}: {ThePersonalTrainer.Name} {Environment.NewLine}{Environment.NewLine}CLIENTS HELPED:{Environment.NewLine}{TheClinic.ClientRecord.Count - 1}";

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

                messageBoard.Log(TheClinic.SignInNewClient(ClientGenerator.GenerateRandomClient(TheClinic)));
            }
            if (CurrentClient.HasReachedNormalWeight())
            {
                messageBoard.Log("Congrats, the client has reached normal BMI!");
                messageBoard.Log($"We will sign him/her out and sign in a new client {Environment.NewLine}");
                messageBoard.Log(TheClinic.SignInNewClient(ClientGenerator.GenerateRandomClient(TheClinic)));
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
