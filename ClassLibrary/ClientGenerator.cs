using System;
using System.Collections.Generic;
using System.Text;

namespace NutritionClinicLibrary
{
    public class ClientGenerator
    {
        public static Client GenerateRandomClient(Dietitian dt, PersonalTrainer pt)
        {
            Random r = new Random();
            Client randomClient;
            do
            {
                randomClient = new Client(GenerateRandomName(), (Math.Round((r.Next(140, 190) / 100.0), 2)), r.Next(200, 1500) / 10, dt, pt);
            } while (randomClient.BMI > 18.5 && randomClient.BMI < 25);

            return randomClient;
        }

        private static string GenerateRandomName()
        {
            Random r = new Random();
            string[] consonants = { "b", "c", "d", "f", "g", "h", "j", "k", "l", "m", "l", "n", "p", "q", "r", "s", "sh", "zh", "t", "v", "w", "x" };
            string[] vowels = { "a", "e", "i", "o", "u", "ae", "y" };
            string Name = "";
            Name += consonants[r.Next(consonants.Length)].ToUpper();
            Name += vowels[r.Next(vowels.Length)];
            int b = 2; //b tells how many times a new letter has been added. It's 2 right now because the first two letters are already in the name.
            int len = r.Next(3, 9);
            while (b < len)
            {
                Name += consonants[r.Next(consonants.Length)];
                b++;
                Name += vowels[r.Next(vowels.Length)];
                b++;
            }
            return Name;
        }
    }
}
