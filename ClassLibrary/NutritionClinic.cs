using System;
using System.Collections.Generic;
using ConsoleSimulationEngine2000;

namespace NutritionClinicLibrary
{
    public class NutritionClinic
    {
        //PROPERTIES
        public string Name { get; private set; }
        public Dietitian Dietitian { get; private set; }
        public PersonalTrainer PersonalTrainer { get; set; }
        public Client CurrentClient { get; private set; }
        public List<Client> ClientRecord { get; private set; }
        

        //FIELDS
        //CONSTRUCTOR (SINGELTON)///////////////////////////
        private static NutritionClinic instance;
        private NutritionClinic(string name, Dietitian dietitian, PersonalTrainer personalTrainer)
        {
            Name = name;
            Dietitian = dietitian;
            PersonalTrainer = personalTrainer;
            ClientRecord = new List<Client>();
        }
        public static NutritionClinic CreateNutritionClinic(string name, Dietitian dietitian, PersonalTrainer personalTrainer)
        {
            if(instance == null)
            {
                instance = new NutritionClinic(name, dietitian, personalTrainer);
            }
            return instance;
        }
        ////////////////////////////////////////////////////////

        //METHODS
        public string SignInNewClient(Client client)
        {
            ClientRecord.Add(client);
            CurrentClient = client;

            return 
                $"Welcome {client.Name} to the {Name} clinic! {Environment.NewLine}" +
                $"Your personal dietitian will be {Dietitian.Name}.{Environment.NewLine}" +
                $"Your personal trainer will be {PersonalTrainer.Name}.{Environment.NewLine}" +
                $"Enjoy your stay!";
        }

    }
}
