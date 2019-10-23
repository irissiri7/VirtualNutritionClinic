using System;
using System.Collections.Generic;
using System.Text;

namespace MattiasSimulator
{
    public abstract class State
    {
        public string Title;
        public abstract void HandleInput(string input, MySimulation sim);
        public abstract string FillCommandBox(MySimulation sim);
        public State(string title)
        {
            Title = title;
        }


    }
}
