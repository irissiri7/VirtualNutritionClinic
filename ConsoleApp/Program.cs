using System;
using NutritionClinicLibrary;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //Setting up employees
            Dietitian theDietitian = new Dietitian("Louise", Employee.Positions.Dietitian);
            PersonalTrainer thePersonalTrainer = new PersonalTrainer("Mats", Employee.Positions.PersonalTrainer);
            //Setting up clinic
            NutritionClinic theClinic = NutritionClinic.CreateNutritionClinic("Kiwi Clinic", theDietitian, thePersonalTrainer);

            Client newClient = new Client("Helena", 1.75, 60.5, theDietitian, thePersonalTrainer);

            Console.WriteLine($"Welcome to the {theClinic.Name}. We will help you get fit in no time.");
            
            

            Console.WriteLine(theClinic.CurrentClient.Name);

            

        }
    }
}
