using System;

namespace SurMaRoute
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Road> allRoads = new List<Road>{new("D1",null, true), new("D2",null, true), new("D3",null, true), new("D4",null, true)};
            GiveWay GiveWay1 = new GiveWay("side1", allRoads);
            while (!GiveWay1.IsFinish()){
                Console.WriteLine(GiveWay1.IsFinish());
                Road.DisplaySide(GiveWay1.Roads[0].Side1, "side1R0");
                Road.DisplaySide(GiveWay1.Roads[0].Side2, "side2R0");
                Road.DisplaySide(GiveWay1.Roads[1].Side1, "side1R1");
                Road.DisplaySide(GiveWay1.Roads[1].Side2, "side2R1");
                Road.DisplaySide(GiveWay1.Roads[2].Side1, "side1R2");
                Road.DisplaySide(GiveWay1.Roads[2].Side2, "side2R2");
                Road.DisplaySide(GiveWay1.Roads[3].Side1, "side1R3");
                Road.DisplaySide(GiveWay1.Roads[3].Side2, "side2R3");
                GiveWay1.Move();
            }
        }
    }
}
