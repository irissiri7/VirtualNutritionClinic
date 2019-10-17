using System;
using System.Collections.Generic;
using System.Text;
using ConsoleSimulationEngine2000;

namespace NutritionClinicLibrary
{
    public class Client
    {
        //FIELDS
        //PROPERTIES
        public string Name { get; set; }
        
        public double Height { get; set; }
        public double Weight { get; set; }
        public double BMI { get => Math.Round(Weight / (Height * Height),1); }
        public double IdealWeight { get => Math.Round(25 * (Height * Height),1); }


        public Dietitian PersonalDietitian { get; set; }
        public PersonalTrainer PersonalTrainer { get; set; }


        public double KcalNeedPerDay { get => PersonalDietitian.EstimateKcalNeedPerDay(this); }
        public double ProteinNeedPerDay { get => PersonalTrainer.EstimateProteinNeedPerDay(this); }

        public int KcalEatenToday { get; private set; }
        public int ProteinEatenToday { get; private set; }


        //CONSTRUCTOR
        public Client(string name, double height, double weight, Dietitian dt, PersonalTrainer pt)
        {
            Name = name;
            Height = Math.Round(height,2);
            Weight = Math.Round(weight,1);
            PersonalDietitian = dt;
            PersonalTrainer = pt;
        }

        //METHODS
        public void DrinkSmoothie()
        {
            Smoothie smoothie = SmoothieBar.MakeSmoothie();
            PersonalDietitian.Evaluate(smoothie, this);
            
            KcalEatenToday += smoothie.KcalPerportion;
            ProteinEatenToday += smoothie.ProteinPerportion;


        }

        public void DoHeavyLifting()
        {
            KcalEatenToday -= 250;
        }

        public void DoCardio()
        {
            KcalEatenToday -= 500;
        }

        public string CurrentState()
        {
            return $"Name: {Name}. Height: {Height}. Weight: {Weight}. BMI: {BMI}";  
        }

        public string Goals()
        {
            return $"Ideal weight: {IdealWeight}. Kcal/day: {KcalNeedPerDay} kcal. Protein/day {ProteinNeedPerDay} g.";


        }

        public string TodaysIntake()
        {
            return $"Kcal: {KcalEatenToday} kcal. Protein: {ProteinEatenToday} g.";


        }

        public void testmethod(BorderedDisplay display)
        {
            display.Value="WelcomeToTheSmoothiebar";
        }
    }
}
