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
        
        public float Height { get; set; }
        public float Weight { get; set; }
        public float BMI { get => Weight / (Height * Height); }

        public Dietitian PersonalDietitian { get; set; }
        public PersonalTrainer PersonalTrainer { get; set; }


        public float KcalNeedPerDay { get => PersonalDietitian.EstimateKcalNeedPerDay(this); }
        public double ProteinNeedPerDay { get => PersonalTrainer. }

        public float KcalEatenToday { get; private set; }
        public float ProteinEatenToday { get; private set; }


        //CONSTRUCTOR
        public Client(string name, float height, float weight, Dietitian dt)
        {
            Name = name;
            Height = height;
            Weight = weight;
            PersonalDietitian = dt;
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
