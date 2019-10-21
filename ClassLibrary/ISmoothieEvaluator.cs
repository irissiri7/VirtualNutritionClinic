namespace NutritionClinicLibrary
{
    internal interface ISmoothieEvaluator
    {
        string Evaluate(Smoothie someSmoothie, Client someClient);
    }
}