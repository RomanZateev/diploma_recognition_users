﻿using System;
using System.Collections.Generic;

namespace Recognition
{
    public class ErrorsCalculation
    {
        static public string pathSessions = @"stats/sessions.json";

        static readonly List<string> Methods = new List<string> {
            "Эвклидово расстояние",
            "Эвклидово расстояние + частотность",
            "Манхэттенское расстояние",
            "Манхэттенское расстояние + частотность",
            "Ближайшего соседа"
        };

        public void Calculate()
        {
            MetricsCalculation metricsCalculation = new MetricsCalculation(pathSessions);

            List<List<string>> DataToForm = new List<List<string>>();

            foreach (string method in Methods)
            {
                List<string> vs = new List<string>();
                var res = metricsCalculation.RecognitionList(method);

                //метод
                vs.Add(method);
                //FAR
                vs.Add(CalculateFAR(res).ToString());
                //FRR
                vs.Add(CalculateFRR(res).ToString());
                //Точность
                vs.Add(Correctness(res).ToString());

                DataToForm.Add(vs);
            }

            Errors errors = new Errors(DataToForm);

            errors.Show();
        }

        private double CalculateFRR(List<UserСomparison> userСomparisons)
        {
            int summ = 0;

            foreach (UserСomparison userСomparison in userСomparisons)
                if (userСomparison.FRR())
                    summ++;

            return Math.Round(((double)summ / userСomparisons.Count * 100), 2);
        }

        //подсчет FAR
        private double CalculateFAR(List<UserСomparison> userСomparisons)
        {
            int summ = 0;
            foreach (UserСomparison userСomparison in userСomparisons)
                if (userСomparison.FAR())
                    summ++;

            return Math.Round(((double)summ / userСomparisons.Count * 100), 2);
        }

        //подсчет точности
        private double Correctness(List<UserСomparison> userСomparisons)
        {
            int summ = 0;
            foreach (UserСomparison userСomparison in userСomparisons)
                if (userСomparison.Correctness())
                    summ++;

            return Math.Round(((double)summ / userСomparisons.Count * 100), 2);
        }
    }
}
