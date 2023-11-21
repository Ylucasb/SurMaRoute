using System;

namespace SurMaRoute
{
    class Program
    {
        static void Main(string[] args)
        {
            Road road = new("road1",null , true);
            Road.DisplaySide(road.Side1, "side1");
            Road.DisplaySide(road.Side2, "side2");
            while (road.GetNumberVehicles() != -1)
            {
                Console.WriteLine(road.GetNumberVehicles());
                road.Move();
                Road.DisplaySide(road.Side1, "side1");
                Road.DisplaySide(road.Side2, "side2");
            }
        }
    }
}
