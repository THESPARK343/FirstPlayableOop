using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace FirstPlayableOop
{
    internal class Program // <- Main Program Class
    {
        public static EnemyClass E1 = new EnemyClass();
        public static EnemyClass E2 = new EnemyClass();
        public static EnemyClass E3 = new EnemyClass();
        public static PickupClass P1 = new PickupClass();
        public static PickupClass P2 = new PickupClass();
        public static PickupClass P3 = new PickupClass();
        public static PickupClass P4 = new PickupClass();
        public static PickupClass P5 = new PickupClass();
        public static Random RNG = new Random();
        static void Main(string[] args) // <- Entry point for the program 
        {
            //Console.Beep();
            //Console.ForegroundColor = ConsoleColor.Black;
            SetUp();
            while (DataClass.GameIsRunning)
            {
                //Console.ForegroundColor = ConsoleColor.White;
                if (DataClass.FirstTurnAvailable)
                {
                    Console.Write("<Press Any Key To Start>");
                    Console.ReadKey(true);
                    Console.Clear();
                    GraphicsClass.PrintMap();
                    GraphicsClass.PrintPlayer();
                    GraphicsClass.PrintEnemy();
                    GraphicsClass.PrintHUD();
                    SoundClass.MusicPlayer("boodeep01.wav");
                }
                else
                {
                    PlayerClass.PlayerTurn();
                    E1.EnemyTurn();
                    E2.EnemyTurn();
                    E3.EnemyTurn();
                    GraphicsClass.PrintMap();
                    GraphicsClass.PrintEnemy();
                    GraphicsClass.PrintPlayer();
                }
                if (PlayerClass.PHp <= 0)
                {
                    PlayerClass.PHp = 0;
                    DataClass.LossConditon = true;
                    DataClass.GameIsRunning = false;
                }
                else if (PlayerClass.PGold >= 5)
                {
                    DataClass.WinCondition = true;
                    DataClass.GameIsRunning = false;
                }
                DataClass.FirstTurnAvailable = false;
            }
            Console.Clear();
            EndScreen();
        }
        static void EndScreen() // <- Ends the game when you have lost or won 
        {
            Console.SetCursorPosition(0, 5);
            if (DataClass.WinCondition)
            {
                Console.Write("     !!!CONGRATULATIONS!!!");
            }
            else if (DataClass.LossConditon)
            {
                Console.Write("Unfortunately You Ceased Living...");
            }
            Console.Write("\n    <Press Any Key To Exit>");
            Console.ReadKey(true);
        }
        static void SetUp() // <- starts the game 
        {
            //player
            PlayerClass.PlayerPosX = 1;
            PlayerClass.PlayerPosY = 1;
            PlayerClass.PHp = 10;
            PlayerClass.PmHp = 10;
            PlayerClass.PlayerDmg = 1;
            //enemy one
            E1.ID = 1;
            E1.EHp = 5;
            E1.EmHp = 5;
            E1.EnemyPosX = 9;
            E1.EnemyPosY = 9;
            E1.EnemyDmg = 1;
            //enemy two
            E2.ID = 2;
            E2.EHp = 10;
            E2.EmHp = 10;
            E2.EnemyPosX = 5;
            E2.EnemyPosY = 5;
            E2.EnemyDmg = 1;
            //enemy three
            E3.ID = 3;
            E3.EHp = 15;
            E3.EmHp = 15;
            E3.EnemyPosX = 10;
            E3.EnemyPosY = 14;
            E3.EnemyDmg = 1;
            //gold and pickups
            PlayerClass.PGold = 0;
            //Console.Beep();
            bool Done = false;
            P1.Pickup = true;
            while (Done) // <- Pickup one assignment
            {
                int PRNGX = RNG.Next(0, MapClass.MapAcross);
                int PRNGY = RNG.Next(0, MapClass.MapDown);
                if (MapClass.MapTileCheck(PRNGX, PRNGY) == 0)
                {
                    P1.PickupX = PRNGX;
                    P1.PickupY = PRNGY;
                    Done = false;
                    break;
                }
                else
                {
                    Done = true;
                }
            }
            //Console.Beep();
            P2.Pickup = true;
           // Done = true;
            while (Done) // <- Pickup two assignment
            {
                int PRNGX = RNG.Next(0, MapClass.MapAcross);
                int PRNGY = RNG.Next(0, MapClass.MapDown);
                if (MapClass.MapTileCheck(PRNGX, PRNGY) == 0)
                {
                    P2.PickupX = PRNGX;
                    P2.PickupY = PRNGY;
                    Done = false;
                    break;
                }
                else
                {
                    Done = true;
                }
            }
            //Console.Beep();
            P3.Pickup = true;
           // Done = true;
            while (Done) // <- Pickup three assignment
            {
                int PRNGX = RNG.Next(0, MapClass.MapAcross);
                int PRNGY = RNG.Next(0, MapClass.MapDown);
                if (MapClass.MapTileCheck(PRNGX, PRNGY) == 0)
                {
                    P3.PickupX = PRNGX;
                    P3.PickupY = PRNGY;
                    Done = false;
                    break;
                }
                else
                {
                    Done = true;
                }
            }
            //Console.Beep();
            P4.Pickup = true;
           // Done = true;
            while (Done) // <- Pickup four assignment
            {
                int PRNGX = RNG.Next(0, MapClass.MapAcross);
                int PRNGY = RNG.Next(0, MapClass.MapDown);
                if (MapClass.MapTileCheck(PRNGX, PRNGY) == 0)
                {
                    P4.PickupX = PRNGX;
                    P4.PickupY = PRNGY;
                    Done = false;
                    break;
                }
                else
                {
                    Done = true;
                }
            }
           // Console.Beep();
            P5.Pickup = true;
          //  Done = true;
            while (Done) // <- Pickup five assignment
            {
                int PRNGX = RNG.Next(0, MapClass.MapAcross);
                int PRNGY = RNG.Next(0, MapClass.MapDown);
                if (MapClass.MapTileCheck(PRNGX, PRNGY) == 0)
                {
                    P5.PickupX = PRNGX;
                    P5.PickupY = PRNGY;
                    Done = false;
                    break;
                }
                else
                {
                    Done = true;
                }
            }
            //Console.Beep();
            //conditions
            DataClass.WinCondition = false;
            DataClass.AttackCollision = false;
            E1.HasAttacked = false;
            E2.HasAttacked = false;
            Console.CursorVisible = false;
            DataClass.LossConditon = false;
            DataClass.GameIsRunning = true;
            DataClass.FirstTurnAvailable = true;
            //initialized
            DataClass.LogMSG = "Adventure Started...";
            MapClass.MapLegend();
            Console.Clear();

            Console.Beep();
        }
        public static void ErrorMessage() // <- Displays Error message 
        {
            Console.SetCursorPosition(5, 17);
            Console.Write("\nError :: Invalid Input \nError :: Press Any Key To Continue...");
            Console.SetCursorPosition(0, 0);
            Console.ReadKey(true);
            Console.Clear();
        }

    }
}
