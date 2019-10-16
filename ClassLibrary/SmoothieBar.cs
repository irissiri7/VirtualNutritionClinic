using System;
using System.Collections.Generic;
using System.Text;

namespace NutritionClinicLibrary
{
    public class SmoothieBar
    {
        public static Smoothie MakeSmoothie()
        {
            Console.WriteLine("Welcome to the smoothiebar! Here you get to pick two ingredients for you smoothie");
            Console.WriteLine("This is our available ingredients: \n[1]Apple\n[2]Banana\n[3]Spinach\n[4]Milk\n[5]Full fat cream\n[6]Chocolate\n[7]Peanuts");
            Console.WriteLine("Pick your first ingredient");
            string choice1 = Console.ReadLine();
            Console.WriteLine("Pick your second ingredient");
            string choice2 = Console.ReadLine();

            Food choice1AsFood = ConvertToFood(choice1);
            Food choice2AsFood = ConvertToFood(choice2);

            return new Smoothie(choice1AsFood, choice2AsFood);
        }

        private static Food ConvertToFood(string choice)
        {
            //Ingrediens inventory
            Food apple = new Food(50, 5);
            Food banana = new Food(100, 7);
            Food spinach = new Food(15, 2);
            Food milk = new Food(50, 10);
            Food fullFatCream = new Food(350, 15);
            Food chocolate = new Food(250, 5);
            Food peanuts = new Food(500, 55);

            int caseSwitch = int.Parse(choice);

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
