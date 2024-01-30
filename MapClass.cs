using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FirstPlayableOop
{
    internal class MapClass // <- Class Responsible For All Map Functions
    {
        public static int MapAcross;
        public static int MapDown;

        public static char[][] MapLegend() // <- Processes map references 
        {
            string[] mapData = LoadMap();
            int MapDimensionAcross = mapData[0].Length;
            int MapDimensionDown = mapData.Length;
            MapAcross = MapDimensionAcross;
            MapDown = MapDimensionDown;
            char[] MapDataOD = new char[MapDimensionAcross];
            char[][] MapLegendArray = new char[MapDimensionDown][];
            for (int i = 0; i < MapDimensionDown; i++)
            {
                MapLegendArray[i] = mapData[i].ToCharArray();
            }
            if (Program.P1.Pickup == false)
            {
                MapLegendArray[Program.P1.PickupY][Program.P1.PickupX] = '0';
            }
            if (Program.P2.Pickup == false)
            {
                MapLegendArray[Program.P2.PickupY][Program.P2.PickupX] = '0';
            }
            if (Program.P3.Pickup == false)
            {
                MapLegendArray[Program.P3.PickupY][Program.P3.PickupX] = '0';
            }
            if (Program.P4.Pickup == false)
            {
                MapLegendArray[Program.P4.PickupY][Program.P4.PickupX] = '0';
            }
            if (Program.P5.Pickup == false)
            {
                MapLegendArray[Program.P5.PickupY][Program.P5.PickupX] = '0';
            }
            return MapLegendArray;
        }
        static public int MapTileCheck(int PosX, int PosY) // <- Checks the map for tile value at specified location, then returns said value 
        {
            char[][] TempArray = MapLegend();
            return TempArray[PosY][PosX];
        }
        static string[] LoadMap() // <- loads and returns map data 
        {
            string path = @"Map_Data.txt";
            string[] mapData = File.ReadAllLines(path);
            return mapData;
        }
    } 
}
