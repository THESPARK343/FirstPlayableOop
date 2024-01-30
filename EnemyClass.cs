using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstPlayableOop
{
    internal class EnemyClass // <- Class Responsible For Enemy Functions
    {
        public int EHp;
        public int EmHp;
        public int EnemyDmg;
        public int EnemyPosX;
        public int EnemyPosY;
        public int ID;
        public bool HasAttacked;
        public void EnemyTurn() // <- processes Enemy's turn 
        {
            //if (EHasAttacked)
            //{
            //    EHasAttacked = false;
            //}
            //else
            //{
            //}
            if (EHp > 0)
            {
                EnemyMovement();
            }
            else if (EHp <= 0)
            {
                EHp = 0;
                EnemyPosX = 0;
                EnemyPosY = 0;
            }
            GraphicsClass.PrintHUD();

        }
        void EnemyMovement() // <- processes enemy one movement 
        {
            int AIuse;
            if (Program.RNG.Next(0,1) == 1)
            {
                AIuse = EnemyAI();
            }
            else
            {
                AIuse = Enemy2AI();
            }
            switch (AIuse)
            {
                case 0: break;
                case 1:
                    if (MapClass.MapTileCheck(EnemyPosX, (EnemyPosY - 1)) == '0')
                    {
                        EnemyPosY -= 1;
                        PlayerClass.PHp = HealthSystemClass.CombatFunction(EnemyPosX, EnemyPosY, PlayerClass.PlayerPosX, PlayerClass.PlayerPosY, EnemyDmg, PlayerClass.PHp, ID);
                        if (HasAttacked)
                        {
                            EnemyPosY += 1;
                            HasAttacked = false;
                        }
                    }
                    else if (MapClass.MapTileCheck(EnemyPosX, (EnemyPosY - 1)) == '8')
                    {
                        EnemyPosY -= 1;
                        PlayerClass.PHp = HealthSystemClass.CombatFunction(EnemyPosX, EnemyPosY, PlayerClass.PlayerPosX, PlayerClass.PlayerPosY, EnemyDmg, PlayerClass.PHp, ID);
                        if (HasAttacked)
                        {
                            EnemyPosY += 1;
                            HasAttacked = false;
                        }
                    }
                    break;
                case 2:
                    if (MapClass.MapTileCheck((EnemyPosX - 1), EnemyPosY) == '0')
                    {
                        EnemyPosX -= 1;
                        PlayerClass.PHp = HealthSystemClass.CombatFunction(EnemyPosX, EnemyPosY, PlayerClass.PlayerPosX, PlayerClass.PlayerPosY, EnemyDmg, PlayerClass.PHp, ID);
                        if (HasAttacked)
                        {
                            EnemyPosX += 1;
                            HasAttacked = false;
                        }
                    }
                    else if (MapClass.MapTileCheck((EnemyPosX - 1), EnemyPosY) == '8')
                    {
                        EnemyPosX -= 1;
                        PlayerClass.PHp = HealthSystemClass.CombatFunction(EnemyPosX, EnemyPosY, PlayerClass.PlayerPosX, PlayerClass.PlayerPosY, EnemyDmg, PlayerClass.PHp, ID);
                        if (HasAttacked)
                        {
                            EnemyPosX += 1;
                            HasAttacked = false;
                        }
                    }
                    break;
                case 3:
                    if (MapClass.MapTileCheck(EnemyPosX, (EnemyPosY + 1)) == '0')
                    {
                        EnemyPosY += 1;
                        PlayerClass.PHp = HealthSystemClass.CombatFunction(EnemyPosX, EnemyPosY, PlayerClass.PlayerPosX, PlayerClass.PlayerPosY, EnemyDmg, PlayerClass.PHp, ID);
                        if (HasAttacked)
                        {
                            EnemyPosY -= 1;
                            HasAttacked = false;
                        }
                    }
                    else if (MapClass.MapTileCheck(EnemyPosX, (EnemyPosY + 1)) == '8')
                    {
                        EnemyPosY += 1;
                        PlayerClass.PHp = HealthSystemClass.CombatFunction(EnemyPosX, EnemyPosY, PlayerClass.PlayerPosX, PlayerClass.PlayerPosY, EnemyDmg, PlayerClass.PHp, ID);
                        if (HasAttacked)
                        {
                            EnemyPosY -= 1;
                            HasAttacked = false;
                        }
                    }
                    break;
                case 4:
                    if (MapClass.MapTileCheck((EnemyPosX + 1), EnemyPosY) == '0')
                    {
                        EnemyPosX += 1;
                        PlayerClass.PHp = HealthSystemClass.CombatFunction(EnemyPosX, EnemyPosY, PlayerClass.PlayerPosX, PlayerClass.PlayerPosY, EnemyDmg, PlayerClass.PHp, ID);
                        if (HasAttacked)
                        {
                            EnemyPosX -= 1;
                            HasAttacked = false;
                        }
                    }
                    else if (MapClass.MapTileCheck((EnemyPosX + 1), EnemyPosY) == '8')
                    {
                        EnemyPosX += 1;
                        PlayerClass.PHp = HealthSystemClass.CombatFunction(EnemyPosX, EnemyPosY, PlayerClass.PlayerPosX, PlayerClass.PlayerPosY, EnemyDmg, PlayerClass.PHp, ID);
                        if (HasAttacked)
                        {
                            EnemyPosX -= 1;
                            HasAttacked = false;
                        }
                    }
                    break;
            }
        }
        int EnemyAI() // <- Determines what enemy one will do 
        {
            if (PlayerClass.PlayerPosY < EnemyPosY)
            {
                return 1; // <- up
            }
            else if (PlayerClass.PlayerPosX < EnemyPosX)
            {
                return 2; // <- left
            }
            else if (PlayerClass.PlayerPosY > EnemyPosY)
            {
                return 3; // <- down
            }
            else if (PlayerClass.PlayerPosX > EnemyPosX)
            {
                return 4; // <- right
            }
            else
            {
                return 0; // <- N/A
            }
        }
        int Enemy2AI() // <- Determines what enemy two will do 
        {
            //if (PlayerPosY < Enemy2PosY)
            //{
            //    return 1;
            //}
            //else if (PlayerPosX < Enemy2PosX)
            //{
            //    return 2;
            //}
            //else if (PlayerPosY > Enemy2PosY)
            //{
            //    return 3;
            //}
            //else if (PlayerPosX > Enemy2PosX)
            //{
            //    return 4;
            //}
            //else
            //{
            //    return 0;
            //}
            Random RNG = new Random();
            switch (RNG.Next(1, 4))
            {
                case 1:
                    return 1;
                case 2:
                    return 2;
                case 3:
                    return 3;
                case 4:
                    return 4;
            }
            return 0;
        }
    }
}
