﻿using System;
using System.Collections.Generic;
using System.Text;
using ConsoleSimulationEngine2000;

namespace NutritionClinicLibrary
{
    public class PersonalTrainer : Employee, ISmoothieEvaluator
    {
        //CONSTRUCTOR
        public PersonalTrainer(string name, Positions position) : base(name, position)
        {
        }

        //METHODS
        public override string GiveAdvice(Client someClient)
        {
            if (someClient.IsOverWeight)
            {
                return $"{Name} says: You should choose cardio workouts";
            }
            else if (someClient.IsUnderWeight)
            {
                return $"{Name} says: You should choose heavy lifting";
            }
            else
            {
                return $"{Name} says: You should vary between cardio and heavy lifting";
            }
        }
        public double EstimateProteinNeedPerDay(Client someClient)
        {
            if(someClient.IsUnderWeight)
            {
                return Math.Round(someClient.Weight * 1.5);
            }
            
            return Math.Round(someClient.Weight * 0.8);
        }
        public string Evaluate(Smoothie someSmoothie, Client someClient)
        {
            double proteinGoalPerSmoothie = someClient.ProteinNeedPerDay * 0.2;
            
            if (someSmoothie.ProteinPerportion < proteinGoalPerSmoothie)
            {
                return $"{Name} says: Too little protein in that smoothie.";
            }
            else
            {
                return $"{Name} says: Good amount of protein in that smoothie!!!";
            }
        }
        public override string Introduction()
        {
            return $"Hi! My name is {Name} and I'll make you break some serious sweat!!";

        }
    }
}
