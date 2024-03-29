﻿using System;
using System.Collections.Generic;
using System.Text;
using ConsoleSimulationEngine2000;

namespace NutritionClinicLibrary
{
    public class Dietitian : Employee, ISmoothieEvaluator
    {
        //CONSTRUCTOR
        public Dietitian(string name, Positions position) : base(name, position)
        {
        }

        //METHODS
        public override string Introduction()
        {
            return $"Hi! My name is {this.Name} and I will help you with everything food related!";
        }
        public override string GiveAdvice(Client someClient)
        {
            if (someClient.IsOverWeight)
            {
                return $"{Name} says: You should choose low calorie foods";
            }
            else if (someClient.IsUnderWeight)
            {
                return $"{Name} says: You should choose high calorie foods";
            }
            else
            {
                return $"{Name} says: You should probably vary between low and high calorie foods";
            }
        }
        public float CalculateIdealWeight(Client someClient)
        {
            float idealBMI = 25;
            float idealWeight = idealBMI * (float)Math.Pow(someClient.Height, 2);
            return idealWeight;
        }
        public double EstimateKcalNeedPerDay(Client someClient)
        {
            int kcalNeedPerKgOverWeight = 25;
            int kcalNeedPerKgNormalWeight = 30;
            int kcalNeedPerKgUnderWeight = 35;

            if (someClient.IsOverWeight)
            {
                return Math.Round(someClient.Weight * kcalNeedPerKgOverWeight);
            }
            else if (someClient.IsUnderWeight)
            {
                return Math.Round(someClient.Weight * kcalNeedPerKgUnderWeight);

            }
            else
            {
                return Math.Round(someClient.Weight * kcalNeedPerKgNormalWeight);

            }
        }
        public string Evaluate(Smoothie someSmoothie, Client someClient)
        {
            if((someClient.IsOverWeight && someSmoothie.KcalPerportion > 200))
            {
                return $"{Name} says: Too much calories, go for something lighter next time";
            }
            else if(someClient.IsUnderWeight && someSmoothie.KcalPerportion < 100)
            {
                return $"{Name} says: Too little calories, you should have something sturdier!";
            }
            else
            {
                return RandomPositiveFeedback();

            }
        }


    }
}
