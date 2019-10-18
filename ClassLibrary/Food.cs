using System;
using System.Collections.Generic;
using System.Text;

namespace NutritionClinicLibrary
{
    public class Food
    {
        public string Name { get; set; }
        public int KcalPerPortion { get; set; }
        public int ProteinPerPortion { get; set; }

        public Food(string name, int kcal, int protein)
        {
            Name = name;
            KcalPerPortion = kcal;
            ProteinPerPortion = protein;
        }
    }
}
