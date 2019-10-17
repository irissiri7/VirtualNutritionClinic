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
            NutritionClinic theClinic = NutritionClinic.CreateNutritionClinic("LydiaFoundation", theDietitian, thePersonalTrainer);
            
            //Setting up clients
            Client theClient = new Client("Helena", 1.78F, 60.5F, theDietitian, thePersonalTrainer);

            theClinic.SignInNewClient(theClient);

        }
    }
}
