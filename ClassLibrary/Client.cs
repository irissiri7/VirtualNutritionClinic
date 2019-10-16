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
        public float IdealWeight { get => Dietitian.CalculateIdealWeight(this); }
        public float KcalNeedPerDay { get => Dietitian.EstimateKcalNeedPerDay(this); }

        public float KcalEatenToday { get; private set; }

        //CONSTRUCTOR
        public Client(string name, float height, float weight)
        {
            Name = name;
            Height = height;
            Weight = weight;
            NutritionClinic.CheckInNewClient(this);

        }
        //METHODS
        public void DrinkSmoothie(SmoothieBar.Ingredients food1, SmoothieBar.Ingredients food2)
        {
            Smoothie smoothie = SmoothieBar.MakeSmoothie(food1, food2);
            
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
