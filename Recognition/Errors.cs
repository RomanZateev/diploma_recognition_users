using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace Recognition
{
    public partial class Errors : Form
    {
        static public string BorderPath = @"stats/border.txt";

        public Errors(List<List<string>> listViewItems)
        {
            InitializeComponent();

            listView.View = View.Details;

            InitializelistViewItems(listViewItems);

            GetBorder();
        }

        private void InitializelistViewItems(List<List<string>> listViewItems)
        {
            listView.Items.Clear();

            foreach (List<string> item in listViewItems)
            {
                //метод, FAR, FRR, точность
                string[] row = { item[0], item[1], item[2], item[3] };
                var listViewItem = new ListViewItem(row);
                listView.Items.Add(listViewItem);
            }
        }

        private void GetBorder()
        {
            BorderInPercent.Text = File.ReadAllText(BorderPath);
        }

        private void SetBorder_Click(object sender, System.EventArgs e)
        {
            File.WriteAllText(BorderPath, String.Empty);

            using (StreamWriter file = File.CreateText(BorderPath))
            {
                file.WriteLine(BorderInPercent.Text);
            }

            ErrorsCalculation errors = new ErrorsCalculation();

            var data = errors.Calculate();

            InitializelistViewItems(data);
        }
    }
}
