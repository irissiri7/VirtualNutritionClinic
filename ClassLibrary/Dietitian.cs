using System;
using System.Collections.Generic;
using System.Text;
using ConsoleSimulationEngine2000;

namespace NutritionClinicLibrary
{
    public class Dietitian : Employee, ISmoothieEvaluator
    {
        //FIELDS
        //PROPERTIES
        //CONSTRUCTOR
        public Dietitian(string name, Positions position) : base(name, position)
        {
        }

        //METHODS
        public override string GiveAdvice(Client someClient)
        {
            if (someClient.BMI > 25.0F)
            {
                return $"{Name}: You should choose low calorie foods";
            }
            else if (someClient.BMI < 18.5F)
            {
                return $"{Name}: You should choose high calorie foods";
            }
            else
            {
                return $"{Name}: You should probably vary between low and high calorie foods";
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

            if (someClient.BMI > 25.0F)
            {
                return Math.Round(someClient.Weight * kcalNeedPerKgOverWeight);
            }
            else if (someClient.BMI < 18.5F)
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
            if((someClient.BMI > 25 && someSmoothie.KcalPerportion > 200))
            {
                return $"Too much calories, go for something lighter next time";
            }
            else if(someClient.BMI < 18.5 && someSmoothie.KcalPerportion < 100)
            {
                return $"Too little calories, you should have something sturdier!";
            }
            else
            {
                return $"{PositiveFeedback()}";

            }
        }

        public override string Introduction()
        {
            return $"Hi! My name is {this.Name} and I will help you with anything and everything regarding food";
        }
    }
}
