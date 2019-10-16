using System;
using System.Collections.Generic;
using System.Text;

namespace NutritionClinicLibrary
{
    public class PersonalTrainer : Employee, IEvaluate
    {
        //PROPERTIES
        //FIELDS
        //CONSTRUCTOR
        public PersonalTrainer(string name, Positions position) : base(name, position)
        {
        }

        //METHODS
        public static void GiveAdvice(Client someClient)
        {
            if (someClient.BMI > 25.0F)
            {
                Console.WriteLine("You should choose cardio workouts");
            }
            else if (someClient.BMI < 18.0F)
            {
                Console.WriteLine("You should choose heavy lifting");
            }
            else
            {
                Console.WriteLine("You should vary between cardio and heavy lifting");
            }
        }
        public double EstimateProteinNeedPerDay(Client someClient)
        {
            if(someClient.BMI < 18.5)
            {
                return someClient.Weight * 1.5;
            }
            
            return someClient.Weight * 0.8;
        }
        public void Evaluate(Smoothie someSmoothie, Client someClient)
        {
            double proteinGoalPerSmoothie = someClient.ProteinNeedPerDay * 0.1;
            if (someSmoothie.ProteinPerportion < proteinGoalPerSmoothie)
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
