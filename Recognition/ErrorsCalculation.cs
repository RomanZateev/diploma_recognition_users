using System;
using System.Collections.Generic;

namespace Recognition
{
    public class ErrorsCalculation
    {
        static public string pathSessions = @"stats/sessions.json";

        static readonly List<string> Methods = new List<string> {
            "Евклидово расстояние",
            "Евклидово расстояние + частотность",
            "Манхэттенское расстояние",
            "Манхэттенское расстояние + частотность",
            "Ближайшего соседа"
        };

        public List<List<string>> Calculate()
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
                vs.Add(CalculateCorrectness(res).ToString());

                DataToForm.Add(vs);
            }

            return DataToForm;
        }

        public void ErrorsForm(List<List<string>> DataToForm)
        {
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
        private double CalculateCorrectness(List<UserСomparison> userСomparisons)
        {
            int summ = 0;
            foreach (UserСomparison userСomparison in userСomparisons)
                if (userСomparison.Correctness())
                    summ++;

            return Math.Round(((double)summ / userСomparisons.Count * 100), 2);
        }
    }
}
