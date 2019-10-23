using System;
using System.Collections.Generic;
using System.Text;

namespace NutritionClinicLibrary
{
    public class Food
    {
        public string Name { get; private set; }
        public int KcalPerPortion { get; private set; }
        public int ProteinPerPortion { get; private set; }

        public Food(string name, int kcal, int protein)
        {
            Name = name;
            KcalPerPortion = kcal;
            ProteinPerPortion = protein;
        }
    }
}
