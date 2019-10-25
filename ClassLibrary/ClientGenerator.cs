using System;
using System.Collections.Generic;
using System.Text;

namespace NutritionClinicLibrary
{
    public static class ClientGenerator
    {
        public static Client GenerateRandomClient(NutritionClinic clinic)
        {
            Random r = new Random();
            Client randomClient;
            do
            {
                var randomHeight = Math.Round((r.Next(140, 190) / 100.0), 2);
                var randomWeight = r.Next(200, 1000) / 10;

                randomClient = new Client(GenerateRandomName(), randomHeight, randomWeight, clinic);

            } while (randomClient.BMI < 12 || (randomClient.BMI > 18.5 && randomClient.BMI < 25));

            return randomClient;
        }

        private static string GenerateRandomName()
        {
            List<string> randomNames = new List<string>
                {
                    "Dart Vader",
                    "Lucky Luuk",
                    "Harry Potter",
                    "Donald Duck",
                    "Mattias Nourdqvist",
                    "Frodo of Baggins",
                    "Samwise Gamgi",
                    "Galadriel",
                    "Keanu Reeves",
                    "Boba Fet",
                    "Chewbacha",
                    "Hermione",
                    "Micke Mouse",
                    "Daisy Duck",
                    "Pippi Longstocking",
                    "Legolas",
                    "Yoda",
                    "Luuk Skywalker",
                    "Princess Leiah"
                };

            Random r = new Random();
            int randomIndex = r.Next(0, randomNames.Count);

            return randomNames[randomIndex];
        }
    }
}
