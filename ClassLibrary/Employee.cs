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
        public Positions Position { get; private set; }

        //CONSTRUCTOR
        public Employee(string name, Positions position)
        {
            Name = name;
            Position = position;
        }
        
        //METHODS
        public abstract string Introduction();
        public abstract string GiveAdvice(Client someClient);

        public string RandomPositiveFeedback()
        {
            Random r = new Random();
            int randomNum = r.Next(1, 5);
            if (randomNum == 1)
            {
                return $"{this.Name} says: Awesome!";
            }
            else if (randomNum == 2)
            {
                return $"{this.Name} says: Excellent, keep up the good work";
            }
            else if (randomNum == 3)
            {
                return $"{this.Name} says: You're doing great";
            }
            else
            {
                return $"{this.Name} says: Wohoo, progress!";
            }
        }
        public string RandomNegativeFeedback()
        {
            Random r = new Random();
            int randomNum = r.Next(1, 4);
            if (randomNum == 1)
            {
                return $"{this.Name} says: Oh, that's a setback";
            }
            else if (randomNum == 2)
            {
                return $"{this.Name} says: Well... next time will be better!";
            }
            else if (randomNum == 3)
            {
                return $"{this.Name} says: It's like tango, two steps forward and one back.";
            }
            else
            {
                return $"{this.Name} says: Okay, let's fokus harder from now on.";
            }
        }

    }
}
