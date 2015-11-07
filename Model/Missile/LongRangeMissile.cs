using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Missile
{
   public class LongRangeMissile : Missile
    {
        public int BlastRadius { get; set; }

       public LongRangeMissile()
       {
           BlastRadius = 4;
       }
    }
}
