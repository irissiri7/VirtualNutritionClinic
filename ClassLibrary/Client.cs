using System;
using System.Collections.Generic;
using System.Text;
using ConsoleSimulationEngine2000;

namespace NutritionClinicLibrary
{
    public class Client
    {
        //PROPERTIES
        public string Name { get; private set; }
        public double Height { get; private set; }
        public double Weight { get; private set; }
        
        public double BMI => Math.Round(Weight / (Height * Height), 1);
        public bool IsOverWeight => BMI > 25;
        public bool IsUnderWeight => BMI < 18.5;
        public double IdealWeight => Math.Round(25 * (Height * Height), 1); 

        public Dietitian PersonalDietitian { get; private set; }
        public PersonalTrainer PersonalTrainer { get; private set; }
        public NutritionClinic MyClinic { get; private set; }


        public double KcalNeedPerDay => PersonalDietitian.EstimateKcalNeedPerDay(this); 
        public double ProteinNeedPerDay => PersonalTrainer.EstimateProteinNeedPerDay(this);

        public int KcalEatenToday { get; private set; }
        public int ProteinEatenToday { get; private set; }


        //CONSTRUCTOR
        public Client(string name, double height, double weight, NutritionClinic clinic)
        {
            Name = name;
            Height = Math.Round(height, 2);
            Weight = Math.Round(weight, 1);
            MyClinic = clinic;
            PersonalDietitian = clinic.Dietitian;
            PersonalTrainer = clinic.PersonalTrainer;
        }

        //METHODS
        public string Train()
        {
            KcalEatenToday -= 300;
            return PersonalTrainer.RandomPositiveFeedback();

        }
        public string DrinkSmoothie(int index1, int index2)
        {
            Smoothie smoothie = MyClinic.SmoothieBar.MakeSmoothie(MyClinic.SmoothieBar.Pantry[index1], MyClinic.SmoothieBar.Pantry[index2]);
            KcalEatenToday += smoothie.KcalPerportion;
            ProteinEatenToday += smoothie.ProteinPerportion;

            return $"{Name} drank a smoothie with {smoothie.IngredientOne.Name} and {smoothie.IngredientTwo.Name}. {Environment.NewLine}" +
                $"It had {smoothie.KcalPerportion} kcal and {smoothie.ProteinPerportion} g protein {Environment.NewLine}" +
                $"{PersonalDietitian.Evaluate(smoothie, this)} {Environment.NewLine}" +
                $"{PersonalTrainer.Evaluate(smoothie, this)} {Environment.NewLine}";
        }
        //State
        public string GetGoals()
        {
            return $"Ideal weight: {IdealWeight}. {Environment.NewLine}Kcal/day: {KcalNeedPerDay} kcal. {Environment.NewLine}Protein/day {ProteinNeedPerDay} g.";
        }
        public string GetCurrentState()
        {
            return $"Name: {Name}. {Environment.NewLine}Height: {Height}. {Environment.NewLine}Weight: {Weight}. {Environment.NewLine}BMI: {BMI}";
        }
        public string GetTodaysIntake()
        {
            return $"Kcal: {KcalEatenToday} kcal. {Environment.NewLine}Protein: {ProteinEatenToday} g.";


        }
        public string CheckTodaysIntake()
        {
            if (KcalEatenToday > KcalNeedPerDay)
            {
                Weight += 5;
                KcalEatenToday = 0;
                ProteinEatenToday = 0;
                if (IsOverWeight)
                {
                    return PrintWeightIncreaseMessage() + Environment.NewLine + PersonalDietitian.RandomNegativeFeedback();
                }
                else if(IsUnderWeight)
                {
                    return PrintWeightIncreaseMessage() + Environment.NewLine + PersonalDietitian.RandomPositiveFeedback();
                }
                else
                {
                    return PrintWeightIncreaseMessage();
                }
                
            }
            else if (KcalEatenToday < KcalNeedPerDay)
            {
                Weight-=5;
                KcalEatenToday = 0;
                ProteinEatenToday = 0;
                if (IsOverWeight)
                {
                    return PrintWeightDecreaseMessage() + Environment.NewLine + PersonalDietitian.RandomPositiveFeedback();
                }
                else if(IsUnderWeight)
                {
                    return PrintWeightDecreaseMessage() + Environment.NewLine + PersonalDietitian.RandomNegativeFeedback();
                }
                else
                {
                    return PrintWeightDecreaseMessage();
                }
            }
            else
            {
                return "Calorie intake is equal to calorie need. Weight is unchanged";
            }
        }
        
        public string PrintWeightIncreaseMessage()
        {
            return $"{Name} ate more calories than calorie need.{Environment.NewLine}" + 
                    $"Weight has increased 5 kg and prevoius intakes has been reset.";
        }
        public string PrintWeightDecreaseMessage()
        {
            return $"{Name} ate less calories than calorie need.{Environment.NewLine}" +
                    $"Weight has decreased 5 kg and prevoius intakes has been reset.";
        }
        //Bools
        public bool NeedsHozpitalization()
        {
            return BMI < 12;
        }
        public bool HasReachedNormalWeight()
        {
            return BMI > 18.5 && BMI < 25;
        }
        
    }
}
