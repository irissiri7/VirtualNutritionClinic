using System;
using System.Collections.Generic;
using System.Text;
using ConsoleSimulationEngine2000;

namespace NutritionClinicLibrary
{
    public class SmoothieBar
    {
        public static Smoothie MakeSmoothie()
        {
            Food choice1AsFood = GenerateRandomIngredient();
            Food choice2AsFood = GenerateRandomIngredient();

            return new Smoothie(choice1AsFood, choice2AsFood);
        }

        private static Food GenerateRandomIngredient()
        {
            //Ingrediens inventory
            Food apple = new Food(50, 5);
            Food banana = new Food(100, 7);
            Food spinach = new Food(15, 2);
            Food milk = new Food(50, 10);
            Food fullFatCream = new Food(350, 15);
            Food chocolate = new Food(250, 5);
            Food peanuts = new Food(500, 55);

            Random r = new Random();
            int caseSwitch = r.Next(1, 8);
            Food foodToReturn = null;

            switch (caseSwitch)
            {
                case 1:
                    foodToReturn = apple;
                    break;
                case 2:
                    foodToReturn = banana;
                    break;
                case 3:
                    foodToReturn = spinach;
                    break;
                case 4:
                    foodToReturn = milk;
                    break;
                case 5:
                    foodToReturn = fullFatCream;
                    break;
                case 6:
                    foodToReturn = chocolate;
                    break;
                case 7:
                    foodToReturn = peanuts;
                    break;
                default:
                    break;
            }

            return foodToReturn;
        }
    }
}
