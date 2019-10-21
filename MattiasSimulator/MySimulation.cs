using System;
using System.Collections.Generic;
using ConsoleSimulationEngine2000;
using MattiasSimulator.Commands;
using NutritionClinicLibrary;

namespace MattiasSimulator
{
    public class MySimulation : Simulation
    {
        private BorderedDisplay headerMessageBoard = new BorderedDisplay(0, 0, 25, 3) { Value = "MESSAGE BOARD" };
        private RollingDisplay messageBoard = new RollingDisplay(0, 2, 90, 16);
        private BorderedDisplay commandBox = new BorderedDisplay(0, 17, 90, 15) { };
        private BorderedDisplay patientInfo = new BorderedDisplay(95, 2, 50, 20) { };
        private BorderedDisplay clockDisplay = new BorderedDisplay(95, 20, 50, 3) { };

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
            messageBoard.Log(theClinic.SignInNewClient(ClientGenerator.GenerateRandomClient(theDietitian, thePersonalTrainer)));

        }

        public override void PassTime(int deltaTime)
        {
            runningTime = runningTime.AddMinutes(30).AddMilliseconds(deltaTime);

            if (runningTime.Day > startTime.Day)
            {
                messageBoard.Log("It's a new day! Let's check the progress:");
                messageBoard.Log(CurrentClient.ChekingCurrentIntake());
                startTime = runningTime;
            }
            if (CurrentClient.NeedsHozpitalization())
            {
                messageBoard.Log("Oups, this has gotten out of hand");
                messageBoard.Log($"{CurrentClient.Name} is dangerouzly underweight and needs hospital care");
                messageBoard.Log($"Bye {CurrentClient.Name} hope you feel better soon");
                messageBoard.Log($"Let's sign in a new patient");
                theClinic.SignInNewClient(ClientGenerator.GenerateRandomClient(theDietitian, thePersonalTrainer));
            }
            if (CurrentClient.HasReachedNormalWeight())
            {
                messageBoard.Log("Congrats, the client has reached normal BMI!");
                messageBoard.Log("We will sign him/her out and sign in a new client");
                messageBoard.Log(theClinic.SignInNewClient(ClientGenerator.GenerateRandomClient(theDietitian, thePersonalTrainer)));
            }

            patientInfo.Value = $"CURRENT CLIENT: {Environment.NewLine}{CurrentClient.CurrentState()}{Environment.NewLine}{Environment.NewLine}CLIENT GOALS: {Environment.NewLine}{CurrentClient.Goals()}{Environment.NewLine}{Environment.NewLine}TODAYS INTAKE:{Environment.NewLine}{CurrentClient.TodaysIntake()}";
            clockDisplay.Value = "Current time: " + runningTime.ToString("HH:mm:ss");


            if (StandardState)
            {
                commandBox.Value = ConstructCommandOptions(Commands);
                messageBoard.Log("");

            }
            else
            {
                messageBoard.Log("Welcome to the smoothiebar!");
                messageBoard.Log("Pick two ingredients for your smoothie");
                commandBox.Value = ConstructSmoothieBarOptions(SmoothieBar.Pantry);
            }

            while (input.HasInput)
            {
                if (StandardState)
                {
                    string command = input.Consume();
                    int indexForCommand;

                    if (int.TryParse(command, out indexForCommand))
                    {
                        if (Commands[indexForCommand].Name.Equals("Drink Custom Made Smoothie"))
                        {
                            StandardState = false;

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
                    }
                    else if(MakeSmoothieState == 1)
                    {
                        choice2 = input.Consume();

                        if (int.TryParse(choice1, out int index1))
                            if (int.TryParse(choice2, out int index2))
                            {
                                messageBoard.Log(theClinic.CurrentClient.DrinkCustomMadeSmoothie(SmoothieBar.Pantry[index1], SmoothieBar.Pantry[index2]));
                            }
                        MakeSmoothieState = 0;
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
            someList.Add(new DrinkRandomSmoothie());
            someList.Add(new DrinkCustomMadeSmoothie());
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

    }
}
