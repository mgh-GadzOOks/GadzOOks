using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GadzOOks.Objects
{
    internal class Environment
    {
        public Dictionary<String, short> _area { get; }
        protected String[][] _position { get; set; }
    }
}
