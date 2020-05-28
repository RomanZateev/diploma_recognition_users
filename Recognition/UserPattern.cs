using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recognition
{
    public class UserPattern
    {
        public string Login { get; set; }

        public List<Letter> ExpectedValues { get; set; }

        public List<Letter> Dispersions { get; set; }
    }
}
