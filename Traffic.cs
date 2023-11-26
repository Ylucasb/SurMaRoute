using System;
using System.Collections;

namespace SurMaRoute{
    class Traffic{
        public Traffic(){
            // Génération de la map
            this.Start();
        }
        public void Start(){
            List<Road> allRoads = new() { new("D1",null, true), new("D2",null, true), new("D3",null, true), new("D4",null, true)};
            TrafficLightIntersection GiveWay1 = new("side1", allRoads);
            GiveWay1.Move();
            GiveWay1.DisplayRoad();
            while (!GiveWay1.IsFinish()){
                Console.Write("Entrez quelque chose : ");
                string? userInput = Console.ReadLine();
                if (userInput != null){
                    GiveWay1.Move();
                    GiveWay1.DisplayRoad();
                }
            }
        }
    }
}