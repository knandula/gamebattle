using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Model
{
   public class BattleField
    {
       public Dictionary<int,BattleArea> BattleAreas { get; set; }

       public BattleField()
       {
           BattleAreas = new Dictionary<int, BattleArea>();
       }

       public void Start()
       {
           BattleArea readyToFire;
           BattleArea affected;

           while (BattleAreas[1].Ships.Count <= 0 || BattleAreas[2].Ships.Count <= 0)
           {
               readyToFire = BattleAreas[1];
               affected = BattleAreas[2];
               readyToFire.GoFire("Player1");
             
               if (affected.WasHit("Player2"))
               {
                   // If Hit Player1 holds a second chance.
                   readyToFire = BattleAreas[1]; 
                   affected = BattleAreas[2];
               }
               else
               {
                   readyToFire = BattleAreas[2];
                   affected = BattleAreas[1];
               }
           }
       }
    }
}
