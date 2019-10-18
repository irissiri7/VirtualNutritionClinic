using System;
using System.Collections.Generic;
using System.Text;
using ConsoleSimulationEngine2000;

namespace NutritionClinicLibrary
{
    public class Client
    {
        //FIELDS
        //PROPERTIES
        public string Name { get; set; }
        public DateTime timeOfCreation { get; private set; }
        public double Height { get; set; }
        public double Weight { get; set; }
        public double BMI { get => Math.Round(Weight / (Height * Height),1); }
        public double IdealWeight { get => Math.Round(25 * (Height * Height),1); }


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
            timeOfCreation = DateTime.Now;
            Height = Math.Round(height,2);
            Weight = Math.Round(weight,1);
            PersonalDietitian = dt;
            PersonalTrainer = pt;
        }

        //METHODS
        public void Eat(RollingDisplay log)
        {
            log.Log($"{PersonalDietitian.Name} says: {PersonalDietitian.PositiveFeedback()}");
            KcalEatenToday += 500;
            ProteinEatenToday += 20;
        }

        public void Train(RollingDisplay log)
        {
            log.Log($"{PersonalTrainer.Name} says: {PersonalTrainer.PositiveFeedback()}");
            KcalEatenToday -= 100;
        }
        public void DrinkSmoothie(RollingDisplay log)
        {
            Smoothie smoothie = SmoothieBar.MakeSmoothie();
            log.Log($"You drank a smoothie with {smoothie.IngredientOne.Name} and {smoothie.IngredientTwo.Name}. {Environment.NewLine}" +
                $"It had {smoothie.KcalPerportion} kcal and {smoothie.ProteinPerportion} g protein {Environment.NewLine}");
            string feedbackDt = PersonalDietitian.Evaluate(smoothie, this);
            string feedbackPt = PersonalTrainer.Evaluate(smoothie, this);

            log.Log(feedbackDt);
            log.Log(feedbackPt);

            KcalEatenToday += smoothie.KcalPerportion;
            ProteinEatenToday += smoothie.ProteinPerportion;


        }

        public void DoHeavyLifting()
        {
            KcalEatenToday -= 250;
        }

        public void DoCardio()
        {
            KcalEatenToday -= 500;
        }

        public string CurrentState(RollingDisplay log)
        {
            if(KcalEatenToday > KcalNeedPerDay)
            {
                Weight++;
                log.Log($"{this.Name} ate more calories than calorie need. Weight has increased and calories eaten is reset");
                KcalEatenToday = 0;
            }
            return $"Name: {Name}. Height: {Height}. Weight: {Weight}. BMI: {BMI}";  
        }

        public string Goals()
        {
            return $"Ideal weight: {IdealWeight}. Kcal/day: {KcalNeedPerDay} kcal. Protein/day {ProteinNeedPerDay} g.";


        }

        public string TodaysIntake()
        {
            return $"Kcal: {KcalEatenToday} kcal. Protein: {ProteinEatenToday} g.";


        }

    }
}
