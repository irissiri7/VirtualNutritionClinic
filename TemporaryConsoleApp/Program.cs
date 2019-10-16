using NutritionClinicLibrary;
using System;

namespace TemporaryConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            NutritionClinic myClinic = NutritionClinic.CreateNutritionClinic("TheLindFoundation");

            Dietitian dt1 = new Dietitian("Lydia", 32000, HealthCoach.Positions.Dietitian, "Good job!");
            PersonalTrainer pt1 = new PersonalTrainer("John", 31000, HealthCoach.Positions.PersonalTrainer, "Never give up!");


            myClinic.PrintEmployeeRecord();
            myClinic.PrintEmployeeRecord();
        }
    }
}
