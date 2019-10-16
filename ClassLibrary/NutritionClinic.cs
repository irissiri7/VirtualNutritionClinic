using System;
using System.Collections.Generic;

namespace NutritionClinicLibrary
{
    public class NutritionClinic
    {
        //PROPERTIES
        public string Name { get; private set; }
        private List<Employee> EmployeeRecord { get; set; }
        private List<Client> ClientRecord { get; set; }
        public decimal Revenue { get; set; }
        
        //FIELDS
        private static NutritionClinic instance;
        
        //CONSTRUCTOR (SINGELTON)
        private NutritionClinic(string name)
        {
            Name = name;
            EmployeeRecord = new List<Employee>();
            ClientRecord = new List<Client>();

        }

        public static NutritionClinic CreateNutritionClinic(string name)
        {
            if(instance == null)
            {
                instance = new NutritionClinic(name);
            }
            return instance;
        }
        
        //METHODS
        internal static void HireNewEmployee(Employee newEmployee)
        {
            instance.EmployeeRecord.Add(newEmployee);
        }

        public static void CheckInNewClient(Client newClient)
        {
            instance.ClientRecord.Add(newClient);
        }

        public void PrintEmployeeRecord()
        {
            foreach(Employee e in EmployeeRecord)
            {
                Console.WriteLine(e.Name);
                Console.WriteLine(e.Position);
                Console.WriteLine(e.Salary);
                Console.WriteLine(e.Id);
                Console.WriteLine();

            }
        }
    }
}
