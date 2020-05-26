using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Recognition
{
    public partial class MainForm : Form
    {
        static public string pathPatterns = @"stats/patterns.json";
        static public string pathSessions = @"stats/generated.json";
        static public string pathLettersFrequency = @"stats/letterFrequency.json";

        //Шаблоны
        static public List<UserPattern> users = JsonConvert.DeserializeObject<List<UserPattern>>(File.ReadAllText(pathPatterns));
        //Сгенерированные сессии
        static public List<UserActivity> UserActivities = JsonConvert.DeserializeObject<List<UserActivity>>(File.ReadAllText(pathSessions));
        //Частотность букв
        static public List<Letter> lettersFrequency = JsonConvert.DeserializeObject<List<Letter>>(File.ReadAllText(pathLettersFrequency));

        static List<string> methods = new List<string> { 
            "Ближайшего соседа",
            "Пороговое значение"
        };

        static List<string> distance = new List<string> {
            "Эвклидово расстояние",
            "Эвклидово расстояние + частотность",
            "Манхэттенское расстояние",
            "Манхэттенское расстояние + частотность"
        };

        public MainForm()
        {
            InitializeComponent();

            openFileDialog.Filter = "All files (*.*)|*.*|Text files(*.txt)|*.txt|JSON files(*.json)|*.json";

            setComboboxItems();
        }

        private void setComboboxItems()
        {
            foreach (UserPattern userPattern in users)
                user.Items.Add(userPattern.login);

            foreach (string d in distance)
                method.Items.Add(d);

            foreach (string m in methods)
                method.Items.Add(m);
        }

        private void calculate_Click(object sender, EventArgs e)
        {
            //считать, что ввел пользователь
            string methodSelected = method.SelectedItem.ToString();

            var res = RecognitionMethodCalculation(methodSelected);

            //подсчет FRR
            CalculateFRR(res);

            //подсчет FAR
            CalculateFAR(res);

            //подсчет точности
            Correctness(res);
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

        //тут нужно условие для UNKNOWN USER
        static List<UserСomparison> RecognitionMethodCalculation(string selected)
        {
            List<UserСomparison> userСomparisonList = new List<UserСomparison>();

            if (distance.Contains(selected))
            {
                List<double> differences = new List<double>();

                //int mistakes = 0;
                int numberOfPatterns = users.Count * UserActivities[0].sessions.Count;

                double difference = 0.0;

                foreach (UserActivity ua in UserActivities)
                {
                    foreach (Session session in ua.sessions)
                    {
                        differences.Clear();

                        foreach (UserPattern user in users)
                        {
                            switch (selected)
                            {
                                case "Эвклидово расстояние":
                                    difference = Evklidean(session, user.expectedValues);
                                    break;
                                case "Эвклидово расстояние + частотность":
                                    difference = evklFrequency(session, user.expectedValues);
                                    break;
                                case "Манхэттенское расстояние":
                                    difference = Manhetten(session, user.expectedValues);
                                    break;
                                case "Манхэттенское расстояние + частотность":
                                    difference = manhFrequency(session, user.expectedValues);
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

                        if (unknownUser(session, users[index].expectedValues))
                            userСomparisonList.Add(new UserСomparison(ua.login, UserActivities[index].login));
                        else
                            userСomparisonList.Add(new UserСomparison(ua.login, "unknown"));
                    }
                }
            }
            else
            {
                foreach (UserActivity ua in UserActivities) 
                    foreach (Session session in ua.sessions)
                        switch (selected)
                        {
                            case "Ближайшего соседа":
                                userСomparisonList.Add(сlosestUser(session, ua.login));
                                break;
                            //case "Пороговое значение":
                            //    userСomparisonList.Add(borderValue(session));
                            //    break;
                        }
            }
            return userСomparisonList;
        }


        private static Dictionary<UserPattern, double> UserBarriers = new Dictionary<UserPattern, double>();

        //установка граничного значения
        static void borderValue(Session session)
        {
            for (int i = 0; i < UserActivities.Count; i++)
            {
                UserPattern user = users.Find(x => x.login == UserActivities[i].login);
                List<double> summs = new List<double>();
                summs.Clear();

                for (int j = 0; j < UserActivities[i].sessions.Count; j++)
                    summs.Add(Difference(UserActivities[i].sessions[j].letters, users.FirstOrDefault(x => x.login == UserActivities[i].login).expectedValues));

                UserBarriers.Add(user, summs.Average());
            }
        }

        //Разница между шаблоном и сессией
        static double Difference(List<Letter> session, List<Letter> pattern)
        {
            double summ = 0;

            foreach (Letter kv in session)
            {
                int index = pattern.FindIndex(f => f.key == kv.key);
                if (index >= 0)
                    summ += Math.Abs(kv.value - pattern.FirstOrDefault(x => x.key == kv.key).value) * lettersFrequency.FirstOrDefault(x => x.key == kv.key).value;
            }

            return summ;
        }

        static public double surroundings = 10;
        //проверка на неопознанного пользователя
        static bool unknownUser(Session currentSession, List<Letter> userPattern)
        {
            double letterSum = 0;

            foreach(Letter letter in currentSession.letters)
                letterSum += letter.value;

            double patternSum = 0;

            foreach(Letter letter in userPattern)
                patternSum += letter.value;

            if (Math.Abs(letterSum - patternSum) < patternSum * surroundings / 100)
                return true;
            else
                return false;

        }

        //метод к средних
        static UserСomparison сlosestUser(Session session, string login)
        {
            int letters = session.letters.Count();

            double[,] differences = new double[users.Count, letters];

            //количество паттернов
            int numberOfPatterns = users.Count * UserActivities[0].sessions.Count;

            int i = 0;
            foreach (UserPattern user in users)
            {
                int j = 0;
                foreach (Letter letter in user.expectedValues)
                {
                    differences[i, j] = Math.Abs(letter.value - session.letters.FirstOrDefault(x => x.key == letter.key).value);
                    j++;
                }
                i++;
            }

            //подбор ближайшего пользователя по минимальному расстоянию
            int[] arr = { 0, 0, 0, 0, 0, 0 };

            for (int k = 0; k < letters; k++)
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

            if (unknownUser(session, users[maxIndex].expectedValues))
                return new UserСomparison(login, UserActivities[maxIndex].login);
            else
                return new UserСomparison(login, "unknown");
        }

        static double manhFrequency(Session currentSession, List<Letter> userPattern)
        {
            double summOfDifference = 0;

            foreach (Letter letter in currentSession.letters)
            {
                int index = userPattern.FindIndex(f => f.key == letter.key);
                int let = lettersFrequency.FindIndex(x => x.key == letter.key);

                if ((index >= 0) && (let >= 0))
                    summOfDifference += Math.Abs(letter.value - userPattern.FirstOrDefault(x => x.key  == letter.key).value) * lettersFrequency.FirstOrDefault(x => x.key == letter.key).value;
            }

            return summOfDifference;
        }

        static double Manhetten(Session currentSession, List<Letter> userPattern)
        {
            double summOfDifference = 0;

            foreach (Letter letter in currentSession.letters)
            {
                int index = userPattern.FindIndex(f => f.key == letter.key);
                
                if (index >= 0)
                    summOfDifference += Math.Abs(letter.value - userPattern.FirstOrDefault(x => x.key == letter.key).value);
            }

            return summOfDifference;
        }

        static double evklFrequency(Session currentSession, List<Letter> userPattern)
        {
            double summOfDifference = 0;

            foreach (Letter letter in currentSession.letters)
            {
                int index = userPattern.FindIndex(f => f.key == letter.key);
                int let = lettersFrequency.FindIndex(x => x.key == letter.key);

                if ((index >= 0 )&& (let >= 0))
                    summOfDifference += Math.Pow(letter.value - userPattern.FirstOrDefault(x => x.key == letter.key).value, 2) * lettersFrequency.FirstOrDefault(x => x.key == letter.key).value;
            }

            return Math.Sqrt(summOfDifference);
        }

        static double Evklidean(Session currentSession, List<Letter> userPattern)
        {
            double summOfDifference = 0;

            foreach (Letter letter in currentSession.letters)
            {
                int index = userPattern.FindIndex(f => f.key == letter.key);

                if (index >= 0)
                    summOfDifference += Math.Pow(letter.value - userPattern.FirstOrDefault(x => x.key == letter.key).value, 2);
            }

            return Math.Sqrt(summOfDifference);
        }

        private void chooseFile_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
                pathSessions = openFileDialog.FileName;
        }
    }
}
