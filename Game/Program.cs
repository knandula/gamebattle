using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Game
{
    class Program
    {
        public static int M { get; set; }
        public static int N { get; set; }
        public static int NumberOfShipsPlayer1 { get; set; }
        public static int NumberOfShipsPlayer2 { get; set; }
        public static List<Point> ShipSizesPlayer1 { get; set; }
        public static List<Point> ShipSizesPlayer2 { get; set; }
        
        static void Main(string[] args)
        {
            //Start here
            //Grabbing necesasry inputs from the console
            // Size, Number of Ships and Sizes
            
            ExtractBattleArea();
            ExtractShipInfo("Player1");
            ExtractShipInfo("Player2");
            Console.WriteLine(Environment.NewLine);
            Console.WriteLine("Initializing , please wait ...");
            

            var newField = new BattleField();  //creating a battlefield
            newField.BattleAreas.Add(1,new BattleArea(new Point(){X = M,Y=N} , ShipSizesPlayer1));  // initializing battle area for Player 1
            newField.BattleAreas.Add(2, new BattleArea(new Point(){X = M,Y=N},ShipSizesPlayer2)); // initializing battle area for Play 2

            //Launch Player 1 First
            newField.Start();



        }

        private static void ExtractShipInfo(string Player)
        {
            ;
            Console.WriteLine("Enter number of ships and their size in AXB -- " + Player);
            int shipcount = 0;
            var readline = Console.ReadLine();
            if (readline != null)
            {
                var line2 = readline.Trim();
                shipcount = int.Parse(line2.ToString().Split(' ')[0]);
            }

            List<Point> playershipsizes = new List<Point>();
            for (int i = 0; i < shipcount; i++)
            {
                var readLine = Console.ReadLine();
                if (readLine != null)
                {
                    var line = readLine.Trim();
                    Point p = new Point();
                    string[] inputs = line.ToString().Split(' ');
                    p.X = int.Parse(inputs[0]);
                    if (inputs.Length > 1) p.Y = int.Parse(inputs[1]);
                    playershipsizes.Add(p);
                }
            }

            if (Player.Equals("Player1"))
            {
                ShipSizesPlayer1 = playershipsizes;
                NumberOfShipsPlayer1 = shipcount;
            }
            else if (Player.Equals("Player2"))
            {
                ShipSizesPlayer2 = playershipsizes;
                NumberOfShipsPlayer2 = shipcount;
            }
        }

        private static void ExtractBattleArea()
        {
            Console.WriteLine("Enter size of the battle area M*N");
            var readLine = Console.ReadLine();
            if (readLine != null)
            {
                var line1 = readLine.Trim();
                string[] inputs = line1.ToString().Split(' ');
                M = int.Parse(inputs[0]);
                N = int.Parse(inputs[1]);
            }
        }
    }
}
