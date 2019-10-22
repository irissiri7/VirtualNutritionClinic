using ConsoleSimulationEngine2000;
using NutritionClinicLibrary;
using Pastel;
using System.Drawing;

namespace MattiasSimulator
{
    class Program
    {
        static async System.Threading.Tasks.Task Main(string[] args)
        {
            //Setting up employees
            Dietitian theDietitian = new Dietitian("Mrs Lind", Employee.Positions.Dietitian);
            PersonalTrainer thePersonalTrainer = new PersonalTrainer("Arnold Schwarzenegger", Employee.Positions.PersonalTrainer);
            //Setting up clinic
            NutritionClinic theClinic = new NutritionClinic("Mayonaise Foundation", theDietitian, thePersonalTrainer);

            var input = new TextInput();
            var gui = new ConsoleGUI() { Input = input };
            var sim = new MySimulation( input, theClinic);
            await gui.Start(sim);
            
        }
    }
}
