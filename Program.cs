using System;

namespace SurMaRoute
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Road> allRoads = new List<Road>{new("D1", true), new("D2", true), new("D3", true), new("D4", true)}
            GiveWay GiveWay1 = new GiveWay("side1", allRoads);
            while (!GiveWay1.IsFinish()){
                GiveWay1.Move();
            }
            // Console.WriteLine(road.RoadLength + " length");
            // Console.WriteLine();
            // Road.DisplaySide(road.Side1, "side1");
            // Road.DisplaySide(road.Side2, "side2");
            // road.GetNumberVehicles();
            // road.Move();
            // Road.DisplaySide(road.Side1, "side1");
            // Road.DisplaySide(road.Side2, "side2");
        }
    }
}
