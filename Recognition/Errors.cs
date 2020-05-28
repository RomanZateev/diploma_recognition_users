using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Recognition
{
    public partial class Errors : Form
    {
        static public string pathSessions = @"stats/generated.json";

        public Errors()
        {
            InitializeComponent();

            //подсчет FRR
            //CalculateFRR(res);

            ////подсчет FAR
            //CalculateFAR(res);

            ////подсчет точности
            //Correctness(res);
        }

        //подсчет FRR
        private void CalculateFRR(List<UserСomparison> userСomparisons)
        {
            int summ = 0;

            foreach (UserСomparison userСomparison in userСomparisons)
                if (userСomparison.FRR())
                    summ++;

            frr.Text = Math.Round(((double)summ / userСomparisons.Count * 100), 2).ToString() + "%";
        }

        //подсчет FAR
        private void CalculateFAR(List<UserСomparison> userСomparisons)
        {
            int summ = 0;
            foreach (UserСomparison userСomparison in userСomparisons)
                if (userСomparison.FAR())
                    summ++;

            far.Text = Math.Round(((double)summ / userСomparisons.Count * 100), 2).ToString() + "%";
        }

        //подсчет точности
        private void Correctness(List<UserСomparison> userСomparisons)
        {
            int summ = 0;
            foreach (UserСomparison userСomparison in userСomparisons)
                if (userСomparison.Correctness())
                    summ++;

            correctness.Text = Math.Round(((double)summ / userСomparisons.Count * 100), 2).ToString() + "%";
        }
    }
}
