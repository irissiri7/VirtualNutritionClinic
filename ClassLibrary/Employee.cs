using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

    }
}
