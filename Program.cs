using System;

namespace SurMaRoute
{
    class Program
    {
        static void Main(string[] args)
        {
            Road road = new("road1", null, true);
            road.DisplayRoad();
            while (road.GetNumberVehicles() != -1)
            {
                road.Move();
                road.DisplayRoad();
            }
        }
    }
}
