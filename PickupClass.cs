using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstPlayableOop
{
    internal class PickupClass // <- Class Responsible For Pickups
    {
        public bool Pickup; //1
        public int PickupX; //1 <- Pickup 01 variables
        public int PickupY; //1
      
        public void GoldCheck(int x, int y) // <- Checks whether the gold pickups exist
        {
            if (PlayerClass.PGold <= 5)
            {
                PickupX = x;
                PickupY = y;
                Pickup = false;
                PlayerClass.PGold = PlayerClass.PGold + 1;
            }
   
        }
    }
}
