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

            var input = new TextInput();
            var gui = new ConsoleGUI() { Input = input };
            var sim = new MySimulation(gui, input, theClinic);
            await gui.Start(sim);

        }
    }

    public class MySimulation : Simulation
    {
        private BorderedDisplay headerMessageBoard = new BorderedDisplay(0, 0, 90, 9);
        private RollingDisplay messageBoardBox = new RollingDisplay(0, 3, 90, 9);
        private BorderedDisplay commandBox = new BorderedDisplay(0, 11, 90, 9) {};
        private BorderedDisplay patientInfoBox = new BorderedDisplay(95, 3, 50, 20) { };
        private BorderedDisplay clinicInfoBox = new BorderedDisplay(0, 17, 90, 6) { };
        private BorderedDisplay clockDisplay = new BorderedDisplay(95, 20, 50, 3) { };

        private readonly ConsoleGUI gui;
        private readonly TextInput input;

        private DateTime startTime;
        private DateTime runningTime;

        private Dietitian theDietitian { get => theClinic.Dietitian; }
        private PersonalTrainer thePersonalTrainer { get => theClinic.PersonalTrainer; }
        private NutritionClinic theClinic { get; set; }
        private Client CurrentClient { get => theClinic.CurrentClient; }

        public override List<BaseDisplay> Displays => new List<BaseDisplay>() {
        headerMessageBoard,
        messageBoardBox,
        patientInfoBox,
        clinicInfoBox,
        clockDisplay,
        commandBox,
        input.CreateDisplay(0, -3, -1) };

        public MySimulation(ConsoleGUI gui, TextInput input, NutritionClinic theClinic)
        {
            this.gui = gui;
            this.input = input;
            startTime = DateTime.Now;
            runningTime = DateTime.Now;
            this.theClinic = theClinic;
            
            messageBoardBox.Log($"Welcome to the {theClinic.Name} nutrition clinic!");
            messageBoardBox.Log($"Everyday we take in a new client, and it's up to you to get him/her " +
                $"{Environment.NewLine}back in shape in 24 hours! Lets see who will be out first client...{Environment.NewLine}");
            theClinic.SignInNewClient(messageBoardBox, GenerateRandomClient());

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="deltaTime"></param>
        public override void PassTime(int deltaTime)
        {
            runningTime = runningTime.AddMinutes(60).AddMilliseconds(deltaTime);
            
            if(runningTime.Day > startTime.Day)
            {
                messageBoardBox.Log("It's a new day!");
                startTime = runningTime;
                theClinic.SignInNewClient(messageBoardBox, GenerateRandomClient());
            }
            
            clinicInfoBox.Value = 
                $"Clinic Name : {theClinic.Name}{Environment.NewLine}{Environment.NewLine}" +
                $"Staff information: {Environment.NewLine}" +
                $"Dietitian: {theDietitian.Name} {Environment.NewLine}" +
                $"Personal trainer: {thePersonalTrainer.Name} {Environment.NewLine}{Environment.NewLine}" +
                $"Clients helped: {theClinic.ClientRecord.Count}"; 
            
            commandBox.Value = $"Available commands: Press [1] Eat, [2] Train {Environment.NewLine}[3] Get dietitians advice [4] Get PTs advice [5] Drink Random Smoothie";
            
            patientInfoBox.Value = $"CURRENT CLIENT: {Environment.NewLine}{CurrentClient.CurrentState(messageBoardBox)}{Environment.NewLine}{Environment.NewLine}CLIENT GOALS: {Environment.NewLine}{CurrentClient.Goals()}{Environment.NewLine}{Environment.NewLine}TODAYS INTAKE:{Environment.NewLine}{CurrentClient.TodaysIntake()}";
            
            clockDisplay.Value = runningTime.ToString("HH:mm:ss");

            messageBoardBox.Log("");

            while (input.HasInput)
            {
                string command = input.Consume();
                if(command == "1")
                {
                    messageBoardBox.Log($"{CurrentClient.Name} ate");
                    CurrentClient.Eat(messageBoardBox);
                }
                else if(command == "2")
                {
                    messageBoardBox.Log($"{CurrentClient.Name} trained");
                    CurrentClient.Train(messageBoardBox);
                }
                else if(command == "3")
                {
                    theDietitian.GiveAdvice(CurrentClient, messageBoardBox);
                }
                else if (command == "4")
                {
                    thePersonalTrainer.GiveAdvice(CurrentClient, messageBoardBox);
                }
                else if(command == "5")
                {
                    CurrentClient.DrinkSmoothie(messageBoardBox);
                }
            }
        }

        public Client GenerateRandomClient()
        {
            Random r = new Random();

            return new Client(GenerateName(r.Next(4,10)), (Math.Round((r.Next(140, 190) / 100.0),2)), r.Next(300, 2000) / 10, theDietitian, thePersonalTrainer);
        }

        public static string GenerateName(int len)
        {
            Random r = new Random();
            string[] consonants = { "b", "c", "d", "f", "g", "h", "j", "k", "l", "m", "l", "n", "p", "q", "r", "s", "sh", "zh", "t", "v", "w", "x" };
            string[] vowels = { "a", "e", "i", "o", "u", "ae", "y" };
            string Name = "";
            Name += consonants[r.Next(consonants.Length)].ToUpper();
            Name += vowels[r.Next(vowels.Length)];
            int b = 2; //b tells how many times a new letter has been added. It's 2 right now because the first two letters are already in the name.
            while (b < len)
            {
                Name += consonants[r.Next(consonants.Length)];
                b++;
                Name += vowels[r.Next(vowels.Length)];
                b++;
            }

            return Name;


        }
    }
}
