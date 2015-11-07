using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using Model.Missile;

namespace Model.Ship
{
    public class Ship
    {

        //Properties
        public int MissileCount { get; set; }
        public int Health { get; set; }
        public Point Xy1 { get; set; }
        public Point Xy2 { get; set; }
        public Point SizeXy { get; set; }
        public int HitCount { get; set; }

        public List<Missile.Missile> Missiles { get; set; }

        //constructor
        public Ship()
        {
            HitCount = 0;
            Health = 100;
            Missiles = new List<Missile.Missile>();
            Missiles.Add(new ShortRangeMissile());
            Missiles.Add(new ShortRangeMissile());
            Missiles.Add(new ShortRangeMissile());
            MissileCount = Missiles.Count;
        }
        
        //Methods
        public int Size()
        {
            return Math.Abs(SizeXy.X * SizeXy.Y);
        }

        public bool Fire()
        {
            var missile = Missiles.FirstOrDefault();
            Missiles.Remove(missile);
            MissileCount--;
            return true;
        }

        public bool IsHit()
        {
            Health -= 10;
            HitCount++;
            return true;
        }

        public bool IsCrashed()
        {
            if (Health <= 0)
                 return true;
            
            return false;
        }

        
    }
}
