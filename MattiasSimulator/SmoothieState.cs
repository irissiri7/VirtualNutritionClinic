﻿using NutritionClinicLibrary;
using System;
using System.Collections.Generic;
using System.Text;
using Pastel;
using System.Drawing;

namespace MattiasSimulator
{
    public class SmoothieState : State
    {
        private int MakeSmoothieState = 0;
        private string choice1 = "";
        private string choice2 = "";
        
        public SmoothieState(string title) : base(title)
        {
        }

        public override string FillCommandBox(MySimulation sim)
        {
            StringBuilder commands = new StringBuilder();
            commands.Append($"Available Ingredients:{Environment.NewLine}");
            int count = 0;
            foreach (Food c in sim.theClinic.SmoothieBar.Pantry)
            {
                commands.Append($"[{count}] {c.Name} {Environment.NewLine}");
                count++;
            }
            
            return commands.ToString().Pastel(Color.FromArgb(132, 226, 150));
        }

        public override void HandleInput(string command, MySimulation sim)
        {
            if (MakeSmoothieState == 0)
            {
                choice1 = command;
                MakeSmoothieState++;
                sim.messageBoard.Log("Pick another ingredient");
            }
            else if (MakeSmoothieState == 1)
            {
                choice2 = command;

                if (int.TryParse(choice1, out int index1))
                {
                    if (int.TryParse(choice2, out int index2))
                    {
                        sim.messageBoard.Log(sim.theClinic.CurrentClient.DrinkSmoothie(index1, index2));
                        MakeSmoothieState = 0;
                        sim.simState = new StandardState("MESSAGE BOARD");
                    }
                    else
                    {
                        GiveInvalidSmoothieChoicesMessageAndThrowOutClientFromSmoothieBar(sim);
                        MakeSmoothieState = 0;
                    }
                }
                else
                {
                    GiveInvalidSmoothieChoicesMessageAndThrowOutClientFromSmoothieBar(sim);
                    MakeSmoothieState = 0;

                }

            }
        }

        public void GiveInvalidSmoothieChoicesMessageAndThrowOutClientFromSmoothieBar(MySimulation sim)
        {
            sim.messageBoard.Log("Something was wrong with your choices... Did you pick something strange?!");
            sim.messageBoard.Log("Comeback later and try again");
            sim.simState = new StandardState("MESSAGE BOARD");
        }

        }

    }

