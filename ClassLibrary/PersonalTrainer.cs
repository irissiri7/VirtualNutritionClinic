using System;
using System.Collections.Generic;
using System.Text;

namespace NutritionClinicLibrary
{
    public class PersonalTrainer : HealthCoach, ICoach
    {
        //PROPERTIES
        public string EncouragingCatchPhrase { get; set; }
        //FIELDS
        //CONSTRUCTOR
        public PersonalTrainer(string name, decimal salaryClaim, Positions position, string catchPhrase) : base(name, position, salaryClaim)
        {
            EncouragingCatchPhrase = catchPhrase;
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

        public void GiveEncouragement()
        {
            Console.WriteLine();
        }
    }
}
