using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConsoleSimulationEngine2000;

namespace NutritionClinicLibrary
{
    public class SmoothieBar
    {
        //PROPERTIES
        public List<Food> Pantry { get =>
                new List<Food>
                {
                    new Food("Water", 0, 0),
                    new Food("Milk", 50, 10),
                    new Food("Oatly", 45, 4),
                    new Food("Full fat cream", 350, 15),
                    
                    new Food("Apple", 50, 5),
                    new Food("Banana", 100, 7),
                    new Food("Lemon", 30, 5),
                    new Food("Orange", 75, 2),

                    new Food("Spinach", 15, 2),
                    new Food("Kale", 30, 0),
                    new Food("Broccoli", 30, 0),

                    new Food("Peanuts", 500, 55),
                    new Food("Walnuts", 600, 10),
                    new Food("Sesame seeds", 600, 15),

                    new Food("Chocolate", 250, 5),
                    new Food("Ahlgrens bilar", 350, 3),
                    new Food("Appel cider vinegar", 5, 0),
                };
        }

        //CONSTRUCTOR
        public Smoothie MakeSmoothie(Food food1, Food food2)
        {
            return new Smoothie(food1, food2);
        }
    }
}
