using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConsoleSimulationEngine2000;

namespace NutritionClinicLibrary
{
    public abstract class Employee
    {
        public enum Positions { Dietitian, PersonalTrainer}
        
        //PROPERTIES
        public string Name { get; private set; }
        public string Id { get; private set; }
        public Positions Position { get; private set; }

        //FIELDS
        //CONSTRUCTOR
        public Employee(string name, Positions position)
        {
            Name = name;
            Id = GenerateId();
            Position = position;
        }
        //METHODS
        private string GenerateId()
        {
            Random random = new Random();
            int lengthOfId = 8;
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            
            return new string(Enumerable.Repeat(chars, lengthOfId).Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public string PositiveFeedback()
        {
            Random r = new Random();
            int randomNum = r.Next(1, 4);
            if (randomNum == 1)
            {
                return "Awesome!";
            }
            else if (randomNum == 2)
            {
                return "Excellent, keep up the good work";
            }
            else if (randomNum == 3)
            {
                return "Great, believe in yourself";
            }
            else
            {
                return "Halleluja, progress!";
            }
        }

        public string NotSoPositiveFeedback()
        {
            Random r = new Random();
            int randomNum = r.Next(1, 4);
            if (randomNum == 1)
            {
                return "Oh, that's a setback";
            }
            else if (randomNum == 2)
            {
                return "Well... next time will be better!";
            }
            else if (randomNum == 3)
            {
                return "It's like tango, two steps forward and one back.";
            }
            else
            {
                return "Okay, let's fokus harder from now on.";
            }
        }

        public abstract string Introduction();
        public abstract string GiveAdvice(Client someClient);
    }
}
