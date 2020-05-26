using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recognition
{
    public class UserPattern
    {
        public string login { get; set; }

        public List<Letter> expectedValues { get; set; }

        public List<Letter> dispersions { get; set; }
    }
}
