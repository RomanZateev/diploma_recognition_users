using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Recognition
{
    //распознавание
    public class MetricsCalculation
    {
        static public string pathPatterns = @"stats/patterns.json";
        static public string pathLettersFrequency = @"stats/letterFrequency.json";
        static public string BorderPath = @"stats/border.txt";

        static public List<UserPattern> UserPatterns = JsonConvert.DeserializeObject<List<UserPattern>>(File.ReadAllText(pathPatterns));
        //Сгенерированные сессии
        static public List<Session> Sessions = new List<Session>();
        //Частотность букв
        static public List<Letter> LettersFrequency = JsonConvert.DeserializeObject<List<Letter>>(File.ReadAllText(pathLettersFrequency));

        static readonly List<string> Distance = new List<string> {
            "Эвклидово расстояние",
            "Эвклидово расстояние + частотность",
            "Манхэттенское расстояние",
            "Манхэттенское расстояние + частотность"
        };

        public MetricsCalculation(string pathSessions)
        {
            Sessions = JsonConvert.DeserializeObject<List<Session>>(File.ReadAllText(pathSessions));
        }

        public MetricsCalculation()
        {

        }

        public void RecognitionMethodCalculation(string SelectedMethod, int SelectedSessionIndex)
        {
            var SessionToDetermine = Sessions[SelectedSessionIndex];

            string RecognizedUserLogin = "unknown";

            List<Letter> letters = new List<Letter>();

            List<Letter> SortedList = new List<Letter>();

            GetBorder();

            if (Distance.Contains(SelectedMethod))
            {
                List<double> differences = new List<double>();

                double difference = 0.0;

                foreach (UserPattern user in UserPatterns)
                {
                    switch (SelectedMethod)
                    {
                        case "Эвклидово расстояние":
                            difference = Evklidean(SessionToDetermine, user.ExpectedValues);
                            break;
                        case "Эвклидово расстояние + частотность":
                            difference = EvklFrequency(SessionToDetermine, user.ExpectedValues);
                            break;
                        case "Манхэттенское расстояние":
                            difference = Manhetten(SessionToDetermine, user.ExpectedValues);
                            break;
                        case "Манхэттенское расстояние + частотность":
                            difference = ManhFrequency(SessionToDetermine, user.ExpectedValues);
                            break;
                    }
                    differences.Add(difference);
                }

                //нахождение минимальной разницы
                double min = Int32.MaxValue;
                int index = 0;
                for (int i = 0; i < differences.Count; i++)
                {
                    if (min > differences[i])
                    {
                        min = differences[i];
                        index = i;
                    }
                }

                RecognizedUserLogin = Sessions[index].Login;

                for (int i = 0; i < differences.Count; i++)
                {
                    letters.Add(new Letter(Sessions[i].Login, differences[i]));
                }

                SortedList = letters.OrderBy(o => o.Value).ToList();
            }
            else
            {
                //Метод ближайшего соседа
                int NumberOfLetters = SessionToDetermine.Letters.Count();

                double[,] differences = new double[UserPatterns.Count, NumberOfLetters];

                int i = 0;
                foreach (UserPattern user in UserPatterns)
                {
                    int j = 0;
                    foreach (Letter letter in user.ExpectedValues)
                    {
                        differences[i, j] = Math.Abs(letter.Value - SessionToDetermine.Letters.FirstOrDefault(x => x.Key == letter.Key).Value);
                        j++;
                    }
                    i++;
                }

                //подбор ближайшего пользователя по минимальному расстоянию
                int[] arr = { 0, 0, 0, 0, 0, 0 };

                for (int k = 0; k < NumberOfLetters; k++)
                {
                    double min = Int32.MaxValue;
                    int index = 0;

                    for (int l = 0; l < differences.GetLength(0); l++)
                        if (min > differences[l, k])
                        {
                            min = differences[l, k];
                            index = l;
                        }
                    arr[index]++;
                }

                int max = -1;
                int maxIndex = 0;
                for (int m = 0; m < arr.Length; m++)
                    if (max < arr[m])
                    {
                        max = arr[m];
                        maxIndex = m;
                    }

                RecognizedUserLogin = Sessions[maxIndex].Login;

                for (int j = 0; j < arr.Length; j++)
                {
                    letters.Add(new Letter(Sessions[j].Login, arr[j]));
                }

                SortedList = letters.OrderByDescending(o => o.Value).ToList();
            }

            if (UnknownUserBorder(SessionToDetermine, UserPatterns.FirstOrDefault(x => x.Login == RecognizedUserLogin).ExpectedValues))
                RecognizedUserLogin = "unknown";

            //форма результата
            Result result = new Result(RecognizedUserLogin, SortedList);
            result.Show();
        }

        public List<UserСomparison> RecognitionList(string method)
        {
            List<UserСomparison> userСomparisonList = new List<UserСomparison>();

            string RecognizedUserLogin = "unknown";

            List<Letter> letters = new List<Letter>();

            GetBorder();

            foreach (Session SessionToDetermine in Sessions)
            {
                if (Distance.Contains(method))
                {
                    List<double> differences = new List<double>();

                    double difference = 0.0;

                    foreach (UserPattern user in UserPatterns)
                    {
                        switch (method)
                        {
                            case "Эвклидово расстояние":
                                difference = Evklidean(SessionToDetermine, user.ExpectedValues);
                                break;
                            case "Эвклидово расстояние + частотность":
                                difference = EvklFrequency(SessionToDetermine, user.ExpectedValues);
                                break;
                            case "Манхэттенское расстояние":
                                difference = Manhetten(SessionToDetermine, user.ExpectedValues);
                                break;
                            case "Манхэттенское расстояние + частотность":
                                difference = ManhFrequency(SessionToDetermine, user.ExpectedValues);
                                break;
                        }
                        differences.Add(difference);
                    }

                    //нахождение минимальной разницы
                    double min = Int32.MaxValue;
                    int index = 0;
                    for (int i = 0; i < differences.Count; i++)
                    {
                        if (min > differences[i])
                        {
                            min = differences[i];
                            index = i;
                        }
                    }

                    RecognizedUserLogin = Sessions[index].Login;

                    for (int i = 0; i < differences.Count; i++)
                    {
                        letters.Add(new Letter(Sessions[i].Login, differences[i]));
                    }

                    if (UnknownUserBorder(SessionToDetermine, UserPatterns.FirstOrDefault(x => x.Login == RecognizedUserLogin).ExpectedValues))
                        RecognizedUserLogin = "unknown";

                    userСomparisonList.Add(new UserСomparison(SessionToDetermine.Login, RecognizedUserLogin));
                }
                else
                {
                    //Метод ближайшего соседа
                    int NumberOfLetters = SessionToDetermine.Letters.Count();

                    double[,] differences = new double[UserPatterns.Count, NumberOfLetters];

                    int i = 0;
                    foreach (UserPattern user in UserPatterns)
                    {
                        int j = 0;
                        foreach (Letter letter in user.ExpectedValues)
                        {
                            differences[i, j] = Math.Abs(letter.Value - SessionToDetermine.Letters.FirstOrDefault(x => x.Key == letter.Key).Value);
                            j++;
                        }
                        i++;
                    }

                    //подбор ближайшего пользователя по минимальному расстоянию
                    int[] arr = { 0, 0, 0, 0, 0, 0 };

                    for (int k = 0; k < NumberOfLetters; k++)
                    {
                        double min = Int32.MaxValue;
                        int index = 0;

                        for (int l = 0; l < differences.GetLength(0); l++)
                            if (min > differences[l, k])
                            {
                                min = differences[l, k];
                                index = l;
                            }
                        arr[index]++;
                    }

                    int max = -1;
                    int maxIndex = 0;
                    for (int m = 0; m < arr.Length; m++)
                        if (max < arr[m])
                        {
                            max = arr[m];
                            maxIndex = m;
                        }

                    RecognizedUserLogin = Sessions[maxIndex].Login;

                    for (int j = 0; j < arr.Length; j++)
                    {
                        letters.Add(new Letter(Sessions[j].Login, arr[j]));
                    }

                    if (UnknownUserBorder(SessionToDetermine, UserPatterns.FirstOrDefault(x => x.Login == RecognizedUserLogin).ExpectedValues))
                        RecognizedUserLogin = "unknown";

                    userСomparisonList.Add(new UserСomparison(SessionToDetermine.Login, RecognizedUserLogin));
                }
            }

            return userСomparisonList;
        }

        static double ManhFrequency(Session currentSession, List<Letter> userPattern)
        {
            double summOfDifference = 0;

            foreach (Letter letter in currentSession.Letters)
            {
                int index = userPattern.FindIndex(f => f.Key == letter.Key);
                int let = LettersFrequency.FindIndex(x => x.Key == letter.Key);

                if ((index >= 0) && (let >= 0))
                    summOfDifference += Math.Abs(letter.Value - userPattern.FirstOrDefault(x => x.Key == letter.Key).Value) * LettersFrequency.FirstOrDefault(x => x.Key == letter.Key).Value;
            }

            return summOfDifference;
        }

        static double Manhetten(Session currentSession, List<Letter> userPattern)
        {
            double summOfDifference = 0;

            foreach (Letter letter in currentSession.Letters)
            {
                int index = userPattern.FindIndex(f => f.Key == letter.Key);

                if (index >= 0)
                    summOfDifference += Math.Abs(letter.Value - userPattern.FirstOrDefault(x => x.Key == letter.Key).Value);
            }

            return summOfDifference;
        }

        static double EvklFrequency(Session currentSession, List<Letter> userPattern)
        {
            double summOfDifference = 0;

            foreach (Letter letter in currentSession.Letters)
            {
                int index = userPattern.FindIndex(f => f.Key == letter.Key);
                int let = LettersFrequency.FindIndex(x => x.Key == letter.Key);

                if ((index >= 0) && (let >= 0))
                    summOfDifference += Math.Pow(letter.Value - userPattern.FirstOrDefault(x => x.Key == letter.Key).Value, 2) * LettersFrequency.FirstOrDefault(x => x.Key == letter.Key).Value;
            }

            return Math.Sqrt(summOfDifference);
        }

        static double Evklidean(Session currentSession, List<Letter> userPattern)
        {
            double summOfDifference = 0;

            foreach (Letter letter in currentSession.Letters)
            {
                int index = userPattern.FindIndex(f => f.Key == letter.Key);

                if (index >= 0)
                    summOfDifference += Math.Pow(letter.Value - userPattern.FirstOrDefault(x => x.Key == letter.Key).Value, 2);
            }

            return Math.Sqrt(summOfDifference);
        }

        //окрестность сессии
        static private double Border = 50;

        static public void GetBorder()
        {
            Border = Convert.ToDouble(File.ReadAllText(BorderPath));
        }

        //проверка на неопознанного пользователя
        static bool UnknownUserBorder(Session currentSession, List<Letter> userPattern)
        {
            double letterSum = 0;

            foreach (Letter letter in currentSession.Letters)
                letterSum += letter.Value;

            double patternSum = 0;

            foreach (Letter letter in userPattern)
                patternSum += letter.Value;

            if (Math.Abs(letterSum - patternSum) > patternSum * Border / 100)
                return true;
            else
                return false;
        }
    }
}
