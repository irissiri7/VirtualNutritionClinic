using System;
using System.Collections.Generic;
using System.Text;

namespace NutritionClinicLibrary
{
    public class Dietitian : Employee, IEvaluate
    {
        //FIELDS
        //PROPERTIES
        //CONSTRUCTOR
        public Dietitian(string name, Positions position) : base(name, position)
        {
        }

        //METHODS
        public void GiveAdvice(Client someClient)
        {
            if (someClient.BMI > 25.0F)
            {
                Console.WriteLine("You should choose low calorie foods");
            }
            else if (someClient.BMI < 18.5F)
            {
                Console.WriteLine("You should choose high calorie foods");
            }
            else
            {
                Console.WriteLine("You should probably vary between low and high calorie foods");
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

        public void Evaluate(Smoothie someSmoothie, Client someClient)
        {
            if((someClient.BMI > 25 && someSmoothie.KcalPerportion > 200) || (someClient.BMI < 18.5 && someSmoothie.KcalPerportion < 100))
            {
                FeedbackGenerator.NotSoPositiveFeedback();
            }
            else
            {
                FeedbackGenerator.PositiveFeedback();

            }
        }

        public override void Introduction()
        {
            Console.WriteLine($"Hi! My name is {this.Name} and I love food");
        }
    }
}
