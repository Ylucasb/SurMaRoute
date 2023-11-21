using System;

namespace SurMaRoute
{
    class Program
    {
        static void Main(string[] args)
        {
            Intersection inter = new("side1");
            Road road = new(10, inter);
            Console.WriteLine(road.RoadLength + " length");
            Console.WriteLine();
            Road.DisplaySide(road.Side1, "side1");
            Road.DisplaySide(road.Side2, "side2");
            road.GetNumberVehicles();
            road.Move();
            Road.DisplaySide(road.Side1, "side1");
            Road.DisplaySide(road.Side2, "side2");
        }
    }
}
