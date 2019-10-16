using System;
using System.Collections.Generic;
using System.Text;

namespace NutritionClinicLibrary
{
    public class Food
    {
        public int KcalPerPortion { get; set; }
        public int ProteinPerPortion { get; set; }

        public Food(int kcal, int protein)
        {
            KcalPerPortion = kcal;
            ProteinPerPortion = protein;
        }
    }
}
