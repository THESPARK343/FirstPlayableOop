using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstPlayableOop
{
    internal class PlayerClass // <- Class Responsible For All Player Functions
    {
        static public int PmHp;
        static public int PHp;
        static public int PlayerDmg;
        static public int PlayerPosX;
        static public int PlayerPosY;
        static public int PGold;
        public static int EnemiesDefeated;
        static public void PlayerTurn() // <- Processes Player turn 
        {
            PmHp = 10;
            if (Program.E1.EHp <= 0)
            {
                PmHp = PmHp + 5;
            }
            if (Program.E2.EHp <= 0)
            {
                PmHp = PmHp + 5;
            }
            if (Program.E3.EHp <= 0)
            {
                PmHp = PmHp + 5;
            }
            PlayerMovement();
            GraphicsClass.PrintHUD();

        }
        static int PlayerInput() // <- processes player input 
        {
            ConsoleKeyInfo Input = Console.ReadKey(true);
            if (Input.KeyChar == 'w')
            {
                return 1;
            }
            if (Input.KeyChar == 'a')
            {
                return 2;
            }
            if (Input.KeyChar == 's')
            {
                return 3;
            }
            if (Input.KeyChar == 'd')
            {
                return 4;
            }
            else
            {
                return 0;
            }
        }
        static void PlayerMovement() // <- processes player movement 
        {
            switch (PlayerInput())
            {
                case 0:
                    Program.ErrorMessage();
                    break;
                case 1:
                    PlayerPosition(0, -1);
                    Program.E1.EHp = HealthSystemClass.CombatFunction(PlayerPosX, PlayerPosY, Program.E1.EnemyPosX, Program.E1.EnemyPosY, PlayerDmg, Program.E1.EHp, 0);
                    Program.E2.EHp = HealthSystemClass.CombatFunction(PlayerPosX, PlayerPosY, Program.E2.EnemyPosX, Program.E2.EnemyPosY, PlayerDmg, Program.E2.EHp, 0);
                    Program.E3.EHp = HealthSystemClass.CombatFunction(PlayerPosX, PlayerPosY, Program.E3.EnemyPosX, Program.E3.EnemyPosY, PlayerDmg, Program.E3.EHp, 0);
                    if (DataClass.AttackCollision)
                    {
                        DataClass.AttackCollision = false;
                        PlayerPosition(0, 1);
                        //LogMSG = "You Are Engaged In Combat!";
                    }
                    break;
                case 2:
                    PlayerPosition(-1, 0);
                    Program.E1.EHp = HealthSystemClass.CombatFunction(PlayerPosX, PlayerPosY, Program.E1.EnemyPosX, Program.E1.EnemyPosY, PlayerDmg, Program.E1.EHp, 0);
                    Program.E2.EHp = HealthSystemClass.CombatFunction(PlayerPosX, PlayerPosY, Program.E2.EnemyPosX, Program.E2.EnemyPosY, PlayerDmg, Program.E2.EHp, 0);
                    Program.E3.EHp = HealthSystemClass.CombatFunction(PlayerPosX, PlayerPosY, Program.E3.EnemyPosX, Program.E3.EnemyPosY, PlayerDmg, Program.E3.EHp, 0);
                    if (DataClass.AttackCollision)
                    {
                        DataClass.AttackCollision = false;
                        PlayerPosition(1, 0);
                        //LogMSG = "You Are Engaged In Combat!";
                    }
                    break;
                case 3:
                    PlayerPosition(0, 1);
                    Program.E1.EHp = HealthSystemClass.CombatFunction(PlayerPosX, PlayerPosY, Program.E1.EnemyPosX, Program.E1.EnemyPosY, PlayerDmg, Program.E1.EHp, 0);
                    Program.E2.EHp = HealthSystemClass.CombatFunction(PlayerPosX, PlayerPosY, Program.E2.EnemyPosX, Program.E2.EnemyPosY, PlayerDmg, Program.E2.EHp, 0);
                    Program.E3.EHp = HealthSystemClass.CombatFunction(PlayerPosX, PlayerPosY, Program.E3.EnemyPosX, Program.E3.EnemyPosY, PlayerDmg, Program.E3.EHp, 0);
                    if (DataClass.AttackCollision)
                    {
                        DataClass.AttackCollision = false;
                        PlayerPosition(0, -1);
                        //LogMSG = "You Are Engaged In Combat!";
                    }
                    break;
                case 4:
                    PlayerPosition(1, 0);
                    Program.E1.EHp = HealthSystemClass.CombatFunction(PlayerPosX, PlayerPosY, Program.E1.EnemyPosX, Program.E1.EnemyPosY, PlayerDmg, Program.E1.EHp, 0);
                    Program.E2.EHp = HealthSystemClass.CombatFunction(PlayerPosX, PlayerPosY, Program.E2.EnemyPosX, Program.E2.EnemyPosY, PlayerDmg, Program.E2.EHp, 0);
                    Program.E3.EHp = HealthSystemClass.CombatFunction(PlayerPosX, PlayerPosY, Program.E3.EnemyPosX, Program.E3.EnemyPosY, PlayerDmg, Program.E3.EHp, 0);
                    if (DataClass.AttackCollision)
                    {
                        DataClass.AttackCollision = false;
                        PlayerPosition(-1, 0);
                        //LogMSG = "You Are Engaged In Combat!";
                    }
                    break;
            }
        }
        static void PlayerPosition(int Xmod, int Ymod) // <- determines player position 
        {
            PlayerPosY += Ymod;
            PlayerPosX += Xmod;
            switch (MapClass.MapTileCheck(PlayerPosX, PlayerPosY))
            {
                case '0': //<-- floor detection
                    DataClass.LogMSG = "No Report.";
                    break;
                case '7': //<-- Wall detection
                    PlayerPosY -= Ymod;
                    PlayerPosX -= Xmod;
                    DataClass.LogMSG = "It's A Wall...";
                    break;
                case '3': //<-- Health pool detection
                    if (PHp < PmHp)
                    {
                        PHp = PHp + 1;
                        DataClass.LogMSG = "The Health Pool Rejuvenates You...";
                    }
                    break;
                case '1': //<-- Safe Area detection
                    DataClass.LogMSG = "In Safe Area.";
                    break;
                case '8': //<-- Hazard Area Detection
                    PHp = PHp - 1;
                    DataClass.LogMSG = "The Poison Saps Your Strength...";
                    break;
                case '4':
                    //PGold = PGold + 1;
                    //Pickup01 = false;
                    if (Program.P1.Pickup)
                    {
                        Program.P1.GoldCheck(PlayerPosX, PlayerPosY);
                        Program.P1.Pickup = false;
                    }
                    else if (Program.P2.Pickup)
                    {
                        Program.P2.GoldCheck(PlayerPosX, PlayerPosY);
                        Program.P2.Pickup = false;
                    }
                    else if (Program.P3.Pickup)
                    {
                        Program.P3.GoldCheck(PlayerPosX, PlayerPosY);
                        Program.P3.Pickup = false;
                    }
                    else if (Program.P4.Pickup)
                    {
                        Program.P4.GoldCheck(PlayerPosX, PlayerPosY);
                        Program.P4.Pickup = false;
                    }
                    else if (Program.P5.Pickup)
                    {
                        Program.P5.GoldCheck(PlayerPosX, PlayerPosY);
                        Program.P5.Pickup = false;
                    }
                    DataClass.LogMSG = "You Got Gold!";
                    break;
            }
            if (PlayerPosX <= 0)
            {
                PlayerPosX = 1;
            }
            else if (PlayerPosX >= MapClass.MapAcross - 2)
            {
                PlayerPosX = MapClass.MapAcross - 2;
            }
            if (PlayerPosY <= 0)
            {
                PlayerPosY = 1;
            }
            else if (PlayerPosY >= MapClass.MapDown - 2)
            {
                PlayerPosY = MapClass.MapDown - 2;
            }
            Console.SetCursorPosition(PlayerPosX, PlayerPosY);
            GraphicsClass.PrintPlayer();
        }

    } 
}
