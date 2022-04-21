using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GadzOOks.Objects
{

    /// <summary>
    /// For locations in the fictional world of the game.
    /// 
    /// To create and hold the state of the current environment
    /// which where the user is in the game.
    /// </summary>
    class Environment
    {
        public Dictionary<String, short> _area { get; }
        protected String[][] _position { get; set; }
    }
}
