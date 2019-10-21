using System;
using System.Collections.Generic;
using System.Text;
using ConsoleSimulationEngine2000;

namespace NutritionClinicLibrary
{
    public class Client
    {
        //PROPERTIES
        public string Name { get; set; }
        public double Height { get; set; }
        public double Weight { get; set; }
        public double BMI => Math.Round(Weight / (Height * Height), 1);
        public double IdealWeight { get => Math.Round(25 * (Height * Height), 1); }

        public Dietitian PersonalDietitian { get; set; }
        public PersonalTrainer PersonalTrainer { get; set; }


        public double KcalNeedPerDay { get => PersonalDietitian.EstimateKcalNeedPerDay(this); }
        public double ProteinNeedPerDay { get => PersonalTrainer.EstimateProteinNeedPerDay(this); }

        public int KcalEatenToday { get; private set; }
        public int ProteinEatenToday { get; private set; }


        //CONSTRUCTOR
        public Client(string name, double height, double weight, Dietitian dt, PersonalTrainer pt)
        {
            Name = name;
            Height = Math.Round(height, 2);
            Weight = Math.Round(weight, 1);
            PersonalDietitian = dt;
            PersonalTrainer = pt;
        }

        //METHODS
        public string Train()
        {
            KcalEatenToday -= 100;
            return $"{PersonalTrainer.Name} says: {PersonalTrainer.PositiveFeedback()}";

        }
        public string DrinkRandomSmoothie()
        {
            Smoothie smoothie = SmoothieBar.MakeSmoothie();
            KcalEatenToday += smoothie.KcalPerportion;
            ProteinEatenToday += smoothie.ProteinPerportion;

            return $"{Name} drank a smoothie with {smoothie.IngredientOne.Name} and {smoothie.IngredientTwo.Name}. {Environment.NewLine}" +
                $"It had {smoothie.KcalPerportion} kcal and {smoothie.ProteinPerportion} g protein {Environment.NewLine}" +
                $"{PersonalDietitian.Name} says: {PersonalDietitian.Evaluate(smoothie, this)} {Environment.NewLine}" +
                $"{PersonalTrainer.Name} says: {PersonalTrainer.Evaluate(smoothie, this)} {Environment.NewLine}";
        }

        public string DrinkCustomMadeSmoothie(Food food1, Food food2)
        {
            Smoothie smoothie = SmoothieBar.MakeSmoothie(food1, food2);
            KcalEatenToday += smoothie.KcalPerportion;
            ProteinEatenToday += smoothie.ProteinPerportion;

            return $"{Name} drank a smoothie with {smoothie.IngredientOne.Name} and {smoothie.IngredientTwo.Name}. {Environment.NewLine}" +
                $"It had {smoothie.KcalPerportion} kcal and {smoothie.ProteinPerportion} g protein {Environment.NewLine}" +
                $"{PersonalDietitian.Name} says: {PersonalDietitian.Evaluate(smoothie, this)} {Environment.NewLine}" +
                $"{PersonalTrainer.Name} says: {PersonalTrainer.Evaluate(smoothie, this)} {Environment.NewLine}";
        }
        public string ChekingCurrentIntake()
        {
            if (KcalEatenToday > KcalNeedPerDay)
            {
                Weight++;
                KcalEatenToday = 0;
                return $"{this.Name} ate more calories than calorie need { Environment.NewLine}" +
                    $"Weight has increased 5 kg and calories has been reset.";
            }
            else if (KcalEatenToday < KcalNeedPerDay)
            {
                KcalEatenToday = 0;
                Weight--;
                return $"{this.Name} ate less calories than calorie need. {Environment.NewLine}" +
                    $"Weight has decreased 5 kg and calories has been reset.";
            }
            else
            {
                return "Calorie intake is equal to calorie need. Weight is unchanged";
            }
        }
        public bool NeedsHozpitalization()
        {
            return BMI < 12;
        }
        public string CurrentState()
        {
            return $"Name: {Name}. {Environment.NewLine}Height: {Height}. {Environment.NewLine}Weight: {Weight}. {Environment.NewLine}BMI: {BMI}";
        }
        public string Goals()
        {
            return $"Ideal weight: {IdealWeight}. {Environment.NewLine}Kcal/day: {KcalNeedPerDay} kcal. {Environment.NewLine}Protein/day {ProteinNeedPerDay} g.";


        }
        public string TodaysIntake()
        {
            return $"Kcal: {KcalEatenToday} kcal. {Environment.NewLine}Protein: {ProteinEatenToday} g.";


        }
        public bool HasReachedNormalWeight()
        {
            return BMI > 18.5 && BMI < 25;
        }

    }
}
