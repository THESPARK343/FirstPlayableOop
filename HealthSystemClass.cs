using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstPlayableOop
{
    internal class HealthSystemClass // <- Class Responsible For All Health Functions
    {

        public static int CombatFunction(int atkrX, int atkrY, int dfndX, int dfndY, int atkrDmg, int dfndHp, int Enemy) // <- processes combat between entities 
        {
            if (atkrX == dfndX && atkrY == dfndY)
            {
                switch (Enemy)
                {
                    case 0:
                        DataClass.AttackCollision = true;
                        break;
                    case 1:
                        Program.E1.HasAttacked = true;
                        DataClass.LogMSG = "You Are Engaged In Combat!";
                        break;
                    case 2:
                        Program.E2.HasAttacked = true;
                        DataClass.LogMSG = "You Are Engaged In Combat!";
                        break;
                    case 3:
                        Program.E3.HasAttacked = true;
                        DataClass.LogMSG = "You Are Engaged In Combat!";
                        break;
                }
                dfndHp -= atkrDmg;
                if (dfndHp <= 0)
                {
                    //LogMSG = "You Are Victorious!";
                    dfndHp = 0;
                }
                return dfndHp;
            }
            else
            {
                return dfndHp;
            }
        }
    } 
}
