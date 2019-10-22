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
        private BorderedDisplay headerMessageBoard = new BorderedDisplay(0, 0, 25, 3) { };
        private RollingDisplay messageBoard = new RollingDisplay(0, 2, 90, 21) { };
        private BorderedDisplay commandBox = new BorderedDisplay(0, 22, 90, 10) { };
        private BorderedDisplay patientInfo = new BorderedDisplay(95, 2, 50, 20) { };
        private BorderedDisplay clockDisplay = new BorderedDisplay(95, 20, 50, 3) { };
        private BorderedDisplay clinicInfo = new BorderedDisplay(95, 22, 50, 10) { };


        private readonly TextInput input;

        private List<ICommand> Commands { get; set; }
        private bool StandardState { get; set; }
        private int MakeSmoothieState;
        private string choice1;
        private string choice2;


        private DateTime startTime;
        private DateTime runningTime;

        private Dietitian theDietitian { get => theClinic.Dietitian; }
        private PersonalTrainer thePersonalTrainer { get => theClinic.PersonalTrainer; }
        private NutritionClinic theClinic { get; set; }
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
            StandardState = true;
            PopulateCommandList(Commands = new List<ICommand>());

            messageBoard.Log($"This is the {theClinic.Name} nutrition clinic!");
            messageBoard.Log($"We help people get back in shape. Lets start by signing in a new client!");
            messageBoard.Log(theClinic.SignInNewClient(ClientGenerator.GenerateRandomClient(theClinic)));

        }

        public override void PassTime(int deltaTime)
        {
            runningTime = runningTime.AddMinutes(120).AddMilliseconds(deltaTime);

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

            if (StandardState)
            {
                headerMessageBoard.Value = "MESSAGE BOARD";
                messageBoard.Log("");
                commandBox.Value = "Available commands" + Environment.NewLine + ConstructCommandOptions(Commands);
            }
            else
            {
                headerMessageBoard.Value = "**SMOOTHIEBAR**".Pastel(Color.FromArgb(169, 253, 172));
                messageBoard.Log("");
                commandBox.Value = "Available ingredients" + Environment.NewLine + ConstructSmoothieBarOptions(SmoothieBar.Pantry).Pastel(Color.FromArgb(169, 253, 172));
            }

            while (input.HasInput)
            {
                if (StandardState)
                {
                    string command = input.Consume();
                    int indexForCommand;

                    if (int.TryParse(command, out indexForCommand))
                    {
                        if (Commands[indexForCommand].Name.Equals("Drink Smoothie"))
                        {
                            StandardState = false;
                            messageBoard.Log(Commands[indexForCommand].Execute(theClinic));

                        }
                        else
                        {
                            messageBoard.Log(Commands[indexForCommand].Execute(theClinic));
                        }

                    }
                }
                else
                {
                    
                    if (MakeSmoothieState == 0)
                    {
                        choice1 = input.Consume();
                        MakeSmoothieState++;
                        messageBoard.Log("Pick another ingredient");
                    }
                    else if (MakeSmoothieState == 1)
                    {
                        choice2 = input.Consume();

                        if (int.TryParse(choice1, out int index1))
                        {
                            if (int.TryParse(choice2, out int index2))
                            {
                                messageBoard.Log(theClinic.CurrentClient.DrinkSmoothie(SmoothieBar.Pantry[index1], SmoothieBar.Pantry[index2]));
                                MakeSmoothieState = 0;
                                StandardState = true;
                            }
                            else
                            {
                                GiveInvalidSmoothieChoicesMessageAndThrowOutClientFromSmoothieBar();
                            }
                        }
                        else
                        {
                            GiveInvalidSmoothieChoicesMessageAndThrowOutClientFromSmoothieBar();
                        }

                    }
                    

                }
            }

        }

        private static void PopulateCommandList(List<ICommand> someList)
        {
            someList.Add(new SayHiToDietitian());
            someList.Add(new SayHiToPT());
            someList.Add(new GetDietitianAdvice());
            someList.Add(new GetPTAdvice());
            someList.Add(new DrinkSmoothie());
            someList.Add(new Train());
        }

        private static string ConstructCommandOptions(List<ICommand> someList)
        {
            string commands = "";
            int count = 0;
            foreach(ICommand c in someList)
            {
                commands += $"[{count}] {c.Name} {Environment.NewLine}";
                count++;
            }

            return commands;
            
        }

        private static string ConstructSmoothieBarOptions(List<Food> someList)
        {
            string commands = "";
            int count = 0;
            foreach (Food c in someList)
            {
                commands += $"[{count}] {c.Name} {Environment.NewLine}";
                count++;
            }

            return commands;

        }

        private void GiveInvalidSmoothieChoicesMessageAndThrowOutClientFromSmoothieBar()
        {
            messageBoard.Log("Something was wrong with your choices... Did you pick something strange?!");
            messageBoard.Log("Comeback later and try again");
            MakeSmoothieState = 0;
            StandardState = true;
        }

    }
}
