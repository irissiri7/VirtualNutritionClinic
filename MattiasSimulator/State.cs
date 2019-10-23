using System;
using System.Collections.Generic;
using System.Text;

namespace MattiasSimulator
{
    public abstract class State
    {
        public readonly string title;
        
        public abstract void HandleInput(string input, MySimulation sim);
        
        public abstract string FillCommandBox(MySimulation sim);
        
        public State(string title)
        {
            this.title = title;
        }


    }
}
