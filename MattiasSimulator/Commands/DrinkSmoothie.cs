using System;
using System.Collections.Generic;
using System.Text;
using NutritionClinicLibrary;
using Pastel;
using System.Drawing;

namespace MattiasSimulator.Commands
{
    public class DrinkSmoothie : ICommand
    {
        public string Name => "Drink Smoothie";

        public string Execute(MySimulation sim)
        {
            sim.simState = new SmoothieState("**SMOOTHIE BAR**", sim.TheClinic.SmoothieBar);
            return "Welcome to the Smoothie Bar. Pick two ingredients for your smoothie";

        }
    }
}
