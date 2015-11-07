using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Ship
{
    public class BattleShip : Ship
    {
        private const string _shipname = "BATTLESHIP";
        public static string Shipname
        {
            get { return _shipname; }
        }
    }
}
