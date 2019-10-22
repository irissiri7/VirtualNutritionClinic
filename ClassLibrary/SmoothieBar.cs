using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConsoleSimulationEngine2000;

namespace NutritionClinicLibrary
{
    public class SmoothieBar
    {
        public static List<Food> Pantry { get =>
                new List<Food>
                {
                    new Food("apple", 50, 5),
                    new Food("banana", 100, 7),
                    new Food("spinach", 15, 2),
                    new Food("milk", 50, 10),
                    new Food("full fat cream", 350, 15),
                    new Food("chocolate", 250, 5),
                    new Food("peanuts", 500, 55)
                };
        }
        
        public static Smoothie MakeSmoothie(Food food1, Food food2)
        {
            return new Smoothie(food1, food2);
        }

    }
}
