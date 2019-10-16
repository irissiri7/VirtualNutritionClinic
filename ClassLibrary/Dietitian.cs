using System;
using System.Collections.Generic;
using System.Text;

namespace NutritionClinicLibrary
{
    public class Dietitian : Employee, ICoach
    {
        //FIELDS
        //PROPERTIES
        public string EncouragingCatchPhrase { get; set; }
        //CONSTRUCTOR
        public Dietitian(string name, decimal salaryClaim, Positions position, string catchPhrase) : base(name, position, salaryClaim)
        {
            EncouragingCatchPhrase = catchPhrase;
        }

        //METHODS - SPECIFIC
        public static float CalculateIdealWeight(Client someClient)
        {
            float idealBMI = 25;
            float idealWeight = idealBMI * (float)Math.Pow(someClient.Height, 2);
            return idealWeight;
        }

        public static float EstimateKcalNeedPerDay(Client someClient)
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

        public static void GiveAdvice(Client someClient)
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

        public void GiveEncouragement()
        {
            Console.WriteLine(EncouragingCatchPhrase);
        }
    }
}
