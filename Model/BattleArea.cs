using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Ship;


namespace Model
{
   public class BattleArea 
    {
        private Point point;
        public Point MaxSizeXy { get; set; }
        public List<Point> ShipSizesXy;
        public List<Ship.Ship> Ships { get; set; }

       public BattleArea(Point sizeXy, List<Point> shipSizes)
       {
           MaxSizeXy = sizeXy;
           ShipSizesXy = shipSizes;
           Ships = new List<Ship.Ship>();
           BuildShips();
       }

       public void BuildShips()
       {
           foreach (var shipsize in ShipSizesXy)
           {
               Point location = GetNextLocation(shipsize);
               var newBattleShip = new BattleShip
                   {
                       SizeXy = shipsize,
                       Xy1 = new Point() { X = location.X,Y = location.Y},
                       Xy2 = new Point() { X = location.X + shipsize.X,Y=location.Y + shipsize.Y}
                   };

                Ships.Add(newBattleShip);
           }
      }

       private Point GetNextLocation(Point shipsize)
       {
           // this function check for respective empty locations in the battle area
           // randomly generates and 
           if (Ships.Count > 1)
           {
               // check other ships 
               //TODO: need more analysis
               return shipsize;
           }
           else
           {
               //first ship to insert 
               return shipsize;
           }
       }

     
       public Boolean CanInclude(Point SizeXy)
       {
           int sizetofit = SizeXy.X * SizeXy.Y;
           int utilizedsize = 0;
           int maxsize = MaxSizeXy.X*MaxSizeXy.Y;

           if (Ships.Count >= 1)
               utilizedsize += Ships.Sum(ship => (ship.SizeXy.X * ship.SizeXy.Y));

           if (utilizedsize < maxsize && sizetofit < (maxsize - utilizedsize))
               return true;
           return false;
       }

       public bool IsOverlapped(Point SizeXy)
       {
           return false;
       }

       public void GoFire(string player)
       {
           Console.WriteLine(player + "- fire the missile");
           var readLine  = Console.ReadLine();
           if (readLine != null)
           {
               var readline = readLine.Trim();
               var shipOnFire = GetShipTobeFired(readline);
               shipOnFire.Fire();
               
               if (shipOnFire.IsCrashed())
                   Ships.Remove(shipOnFire);
           }
       }

       private BattleShip GetShipTobeFired(string readline)
       {
           // conversion method to divert command into list indexes , A1 -- ship at index 
           int index = 0;
           index = ((int)readline[0]) - 65;
           return (BattleShip) Ships[index];
       }



       public bool WasHit(string p)
       {
           //TODO: need to implement
           return true; // just for now.
       }
    }
}
