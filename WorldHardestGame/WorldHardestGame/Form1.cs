﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WorldHardestGame;

namespace WorldHardestGame
{
    public partial class Form1 : Form
    {
        GameController gc = new GameController();
        GameArea ga;
        Brain winnerBrain = null;

        int populationSize = 100;
        int nbrOfSteps = 10;
        int nbrOfStepsIncrement = 10;
        int generation = 1;

        public Form1()
        {
            InitializeComponent();

            ga = gc.ActivateDisplay();
            this.Controls.Add(ga);
            gc.GameOver += Gc_GameOver;

            for (int i = 0; i < populationSize; i++)
            {
                gc.AddPlayer(nbrOfSteps);
            }
            gc.Start();
        }

        private void Gc_GameOver(object sender)
        {
            var playerList = from p in gc.GetCurrentPlayers()
                             orderby p.GetFitness() descending
                             select p;
            var topPerformers = playerList.Take(populationSize / 2).ToList();

            generation++;
            label1.Text = string.Format(
                "{0}. generáció",
                generation);

            gc.ResetCurrentLevel();
            foreach (var p in topPerformers)
            {
                var b = p.Brain.Clone();
                if (generation % 3 == 0)
                    gc.AddPlayer(b.ExpandBrain(nbrOfStepsIncrement));
                else
                    gc.AddPlayer(b);

                if (generation % 3 == 0)
                    gc.AddPlayer(b.Mutate().ExpandBrain(nbrOfStepsIncrement));
                else
                    gc.AddPlayer(b.Mutate());
            }

            var winners = from p in topPerformers
                          where p.IsWinner
                          select p;
            if (winners.Count() > 0)
            {
                winnerBrain = winners.FirstOrDefault().Brain.Clone();
                gc.GameOver -= Gc_GameOver;
                return;
            }

            gc.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            gc.ResetCurrentLevel();
            gc.AddPlayer(winnerBrain.Clone());
            gc.AddPlayer();
            ga.Focus();
            gc.Start(true);
        }
    }
}
© 2021 GitHub, Inc.
Terms
Privacy
Security
Status
Docs
Contact GitHub
Pricing
API
Training
Blog
About