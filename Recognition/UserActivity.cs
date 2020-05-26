using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recognition
{
    public class UserActivity
    {
        public string login { get; set; }

        public List<Session> sessions { get; set; }

        public Dictionary<string, double> dispersions { get; set; }
    }
}
