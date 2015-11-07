using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Ship
{
    public class Destroyer : Ship
    {
        private const string _shipname = "DESTROYER";
        public static string Shipname
        {
            get { return _shipname; }
        }
    }
}
