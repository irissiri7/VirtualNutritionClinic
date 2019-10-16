namespace NutritionClinicLibrary
{
    public class Smoothie
    {
        public int KcalPerportion { get; private set; }

        public Smoothie(SmoothieBar.Ingredients one, SmoothieBar.Ingredients two)
        {
            KcalPerportion = (int)one + (int)two;
            
        }

    }
}