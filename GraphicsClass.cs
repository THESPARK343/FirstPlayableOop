using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstPlayableOop
{
    internal class GraphicsClass // <- Class Responsible For Displaying Graphics
    {
        static public void PrintPlayer() // <- prints player character 
        {
            //Console.SetCursorPosition(PlayerPosX, PlayerPosY);
            //Console.Write("T");
            GFX.GridProcGFX('2', PlayerClass.PlayerPosX, PlayerClass.PlayerPosY);
        }
        static public void PrintEnemy() // <- Prints enemy character 
        {
            //Console.SetCursorPosition(EnemyPosX, EnemyPosY);
            //Console.Write("E");
            if (Program.E1.EHp > 0)
            {
                GFX.GridProcGFX('5', Program.E1.EnemyPosX, Program.E1.EnemyPosY);
            }
            if (Program.E2.EHp > 0)
            {
                GFX.GridProcGFX('5', Program.E2.EnemyPosX, Program.E2.EnemyPosY);
            }
            if (Program.E3.EHp > 0)
            {
                GFX.GridProcGFX('5', Program.E3.EnemyPosX, Program.E3.EnemyPosY);
            }
        }
        static public void PrintMap() // <- prints the map to the screen 
        {
            for (int i = 0; i < MapClass.MapDown; i++)
            {
                for (int j = 0; j < MapClass.MapAcross; j++)
                {
                    //Console.SetCursorPosition(j, i);
                    //Console.Write(MapLegend()[i][j]);
                    if (i == j)
                    {

                    }
                    GFX.GridProcGFX(MapClass.MapLegend()[i][j], j, i);
                }
            }
        }
        static public void PrintHUD() // <- Displays HUD 
        {
            Console.SetCursorPosition(0, 23);
            Console.Write("                                                                         \n                                                                         \n                                                                         \n                                                                         \n                                                                         ");
            Console.SetCursorPosition(0, 23);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Player Hp: " + PlayerClass.PHp + "/" + PlayerClass.PmHp + "  |  " + "Gold: " + PlayerClass.PGold);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("\n" + "Intel Report: " + DataClass.LogMSG);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\n" + "Enemy 1: " + Program.E1.EHp + "/" + Program.E1.EmHp);
            Console.Write("\n" + "Enemy 2: " + Program.E2.EHp + "/" + Program.E2.EmHp);
            Console.Write("\n" + "Enemy 3: " + Program.E3.EHp + "/" + Program.E3.EmHp);

        }
    }
}
