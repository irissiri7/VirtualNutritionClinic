using System;
using System.Collections.Generic;

namespace NutritionClinicLibrary
{
    public class NutritionClinic
    {
        //PROPERTIES
        public string Name { get; private set; }
        public Dietitian Dietitian { get; private set; }
        public PersonalTrainer PersonalTrainer { get; set; }
        public Client Client { get; set; }

        //FIELDS
        private static NutritionClinic instance;
        //CONSTRUCTOR (SINGELTON)
        private NutritionClinic(string name, Dietitian dietitian, PersonalTrainer personalTrainer)
        {
            Name = name;
            Dietitian = dietitian;
            PersonalTrainer = personalTrainer;
        }

        public static NutritionClinic CreateNutritionClinic(string name, Dietitian dietitian, PersonalTrainer personalTrainer)
        {
            if(instance == null)
            {
                instance = new NutritionClinic(name, dietitian, personalTrainer);
            }
            return instance;
        }

        public void SignInNewClient(Client client)
        {
            Console.WriteLine($"Welcome {client.Name} to the {Name} clinic!");
            Console.WriteLine("Let us sign you in");
            Console.WriteLine($"Your personal dietitian will be {Dietitian.Name}. He/she will help you with anything food related");
            Console.WriteLine($"Your personal trainer will be {PersonalTrainer.Name}. He/she will help you with anything related to training");

            Client = client;
        }
        
        //METHODS
    }
}
