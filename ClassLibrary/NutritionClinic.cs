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
        public PersonalTrainer PersonalTrainer { get; private set; }
        public Client CurrentClient { get; private set; }
        public List<Client> ClientRecord { get; private set; }
        public SmoothieBar SmoothieBar {get; private set;}
        
        //CONSTRUCTOR
        public NutritionClinic(string name, Dietitian dietitian, PersonalTrainer personalTrainer)
        {
            Name = name;
            Dietitian = dietitian;
            PersonalTrainer = personalTrainer;
            ClientRecord = new List<Client>();
            SmoothieBar = new SmoothieBar();
        }
        
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
