using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recognition
{
    public class Letter
    {
        public string key;

        public double value;

        public Letter()
        {

        }

        public Letter(string key, double value)
        {
            this.key = key;

            this.value = value;
        }
    }
}
