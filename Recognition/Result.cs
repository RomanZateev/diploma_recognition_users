using System.Collections.Generic;
using System.Windows.Forms;

namespace Recognition
{
    public partial class Result : Form
    {
        public Result(string RecognizedUserLogin, List<Letter> letters)
        {
            InitializeComponent();

            UserLogin.Text = RecognizedUserLogin;

            listView.View = View.Details;

            int i = 0;
            foreach (Letter letter in letters)
            {
                i++;
                string[] row = { i.ToString(), letter.Key, letter.Value.ToString() };
                var listViewItem = new ListViewItem(row);
                listView.Items.Add(listViewItem);
            }
        }
    }
}
