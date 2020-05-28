using System.Collections.Generic;
using System.Windows.Forms;

namespace Recognition
{
    public partial class Errors : Form
    {
        public Errors(List<List<string>> listViewItems)
        {
            InitializeComponent();

            listView.View = View.Details;

            foreach (List<string> item in listViewItems)
            {
                //метод, FAR, FRR, точность
                string[] row = { item[0], item[1], item[2], item[3] };
                var listViewItem = new ListViewItem(row);
                listView.Items.Add(listViewItem);
            }
        }
    }
}
