using System;
using System.Collections.Generic;
using System.Text;

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

        }

        public void DoHeavyLifting()
        {
            KcalEatenToday -= 250;
        }

        public void DoCardio()
        {
            KcalEatenToday -= 500;
        }

    }
}
