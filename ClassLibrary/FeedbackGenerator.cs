using System;
using System.Collections.Generic;
using System.Text;

namespace NutritionClinicLibrary
{
    public class FeedbackGenerator
    {
        public static void PositiveFeedback()
        {
            Random r = new Random();
            int randomNum = r.Next(1, 4);
            if(randomNum == 1)
            {
                Console.WriteLine("Awesome!");
            }
            else if(randomNum == 2)
            {
                Console.WriteLine("Excellent, keep up the good work");
            }
            else if(randomNum == 3)
            {
                Console.WriteLine("Great, believe in yourself");
            }
            else
            {
                Console.WriteLine("Halleluja, progress!");
            }
        }
        public static void NotSoPositiveFeedback()
        {
            Random r = new Random();
            int randomNum = r.Next(1, 4);
            if (randomNum == 1)
            {
                Console.WriteLine("Oh, that's a setback");
            }
            else if (randomNum == 2)
            {
                Console.WriteLine("Well... next time will be better!");
            }
            else if (randomNum == 3)
            {
                Console.WriteLine("It's like tango, two steps forward and one back.");
            }
            else
            {
                Console.WriteLine("Okay, let's fokus harder from now on.");
            }
        }

    }

}
