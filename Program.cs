using System;

namespace SurMaRoute
{
    class Program
    {
        static void Main(string[] args)
        {
            GiveWay GiveWay1 = new GiveWay1("side1");
            Road road1 = new(10, GiveWay1);
            Road road2 = new(10, GiveWay1);
            Road road3 = new(10, GiveWay1);
            Road road4 = new(10, GiveWay1);
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
