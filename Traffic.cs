using System;
using System.Collections;

namespace SurMaRoute{
    class Traffic{
        private List<Intersection> _allIntersection = new();
        public Traffic(){
            MapGeneration();
            Start();
        }
        private void Start(){
            while (!_allIntersection[0].IsFinish() && !_allIntersection[1].IsFinish()){
                // Console.Write("Entrez quelque chose : ");
                // string? userInput = Console.ReadLine();
                string? userInput = "y";
                if (userInput != null){
                    _allIntersection[0].Move();
                    // _allIntersection[0].DisplayRoad(); // Graphic display
                    // _allIntersection[1].Move();
                    // _allIntersection[1].DisplayRoad(); // Graphic display
                }
            }
        }
        private void MapGeneration(){
            Road road1 = new("D1",null, true);
            Road road2 = new("D2",null, true);
            Road road3 = new("D3",null, true);
            Road road4 = new("D4",null, true);
            Road road5 = new("D5",null, true);
            Road road6 = new("D6",null, true);
            Road road7 = new("D7",null, true);
            List<Road> allRoadsIntersection1 = new() { road1, road2, road3, road4};
            List<Road> allRoadsIntersection2 = new() { road4, road5, road6, road7};
            _allIntersection.Add(new TrafficLightIntersection("side1", allRoadsIntersection1));
            _allIntersection.Add(new GiveWay("side1", allRoadsIntersection2));

        }

    }
}