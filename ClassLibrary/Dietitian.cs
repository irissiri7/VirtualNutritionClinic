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
        public float EstimateKcalNeedPerDay(Client someClient)
        {
            int kcalNeedPerKgBodyWeightIfOverWeight = 25;
            int kcalNeedPerKgBodyWeightIfUnderWeight = 35;
            int kcalNeedPerKgBodyWeightIfNormalWeight = 30;

            if (someClient.BMI > 25.0F)
            {
                return someClient.Weight * kcalNeedPerKgBodyWeightIfOverWeight;
            }
            else if (someClient.BMI < 18.5F)
            {
                return someClient.Weight * kcalNeedPerKgBodyWeightIfUnderWeight;

            }
            else
            {
                return someClient.Weight * kcalNeedPerKgBodyWeightIfNormalWeight;

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
    }
}
