using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace Model.Missile
{
    public class ShortRangeMissile :Missile
    {
        public int BlastRadius { get; set; }

        public ShortRangeMissile()
        {
            BlastRadius = 2;
        }
    }
}
