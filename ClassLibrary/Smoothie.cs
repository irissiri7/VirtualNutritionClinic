namespace NutritionClinicLibrary
{
    public class Smoothie
    {
        //PROPERTIES
        public int KcalPerportion { get; private set; }
        public int ProteinPerportion { get; private set; }
        public Food IngredientOne { get; private set; }
        public Food IngredientTwo { get; private set; }


        //CONSTRUCTOR
        public Smoothie(Food one, Food two)
        {
            IngredientOne = one;
            IngredientTwo = two;

            KcalPerportion = one.KcalPerPortion + two.KcalPerPortion;
            ProteinPerportion = one.ProteinPerPortion + two.ProteinPerPortion;
        }

    }
}