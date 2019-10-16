using System;
using System.Collections.Generic;
using System.Text;

namespace NutritionClinicLibrary
{
    public class SmoothieBar
    {
        //Kcal per portion of food
        public enum Ingredients
        {
            Apple = 50,
            Orange = 60,
            Kiwi = 25,

            Milk = 50,
            HeavyCream = 200,
            Water = 0,

            Spinache = 10,
            Broccoli = 10,
            Kale = 1,

            Chocolate = 150,
            Peanuts = 200,
            Candy = 150,
            
        }
        public static Smoothie MakeSmoothie(Ingredients one, Ingredients two)
        {
            return new Smoothie(one, two);
        }

    }
}
