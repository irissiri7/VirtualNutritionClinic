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
        public Client Client { get; private set; }
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
        public void SignInNewClient(RollingDisplay log, Client client)
        {

            log.Log($"Welcome {client.Name} to the {Name} clinic!");
            log.Log("Let us sign you in");
            log.Log($"Your personal dietitian will be {Dietitian.Name}. He/she will help you with anything food related");
            log.Log($"Your personal trainer will be {PersonalTrainer.Name}. He/she will help you with anything related to training");

            ClientRecord.Add(client);
            Client = client;
        }

    }
}
