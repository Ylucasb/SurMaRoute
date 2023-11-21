namespace SurMaRoute{
    class GiveWay : Intersection{
        public GiveWay(string name, List<Road> roads):base(name, roads){}
        public override void Move(){
            if (AllRoadFull()){
                Random rnd = new Random();
                int indexRoad1 = rnd.Next(0, Roads.Count-1);
                int indexRoad2 = indexRoad1-1;
                if (indexRoad2 <0){
                    indexRoad2 = 3;
                }
                (Roads[indexRoad2].Side1[Roads[indexRoad2].RoadLength-1], Roads[indexRoad1].Side2[0]) = (Roads[indexRoad1].Side2[0], Roads[indexRoad2].Side1[Roads[indexRoad2].RoadLength-1]);
                // Console.WriteLine(String.Format("{0} à quitté {1} pour {2}",Roads[indexRoad2].Side2[Roads[indexRoad2].RoadLength-1].Name, Roads[indexRoad1].RoadName, Roads[indexRoad2].RoadName));
                Roads[indexRoad1].Move();
            } 
            for (int i = 0; i < Roads.Count; i++)
            {
                MoveVehicle(i);
                Roads[i].Move();
            }
        }
        private bool IsPossibleToMove(int indexRoad){
            return Roads[indexRoad].Side1[0] == null && Roads[indexRoad].Side1[1] == null;
        }
        private void MoveVehicle(int indexRoad1){
            int indexRoad2 = indexRoad1-1;
            if (indexRoad2 <0){
                indexRoad2 = 3;
            }
            if (AnyoneWantTurn(Roads[indexRoad1]) && IsWantedRoadAvailable(Roads[indexRoad2]) && IsPossibleToMove(indexRoad2)){
                Console.WriteLine("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
                (Roads[indexRoad2].Side1[Roads[indexRoad2].RoadLength-1], Roads[indexRoad1].Side2[0]) = (Roads[indexRoad1].Side2[0], Roads[indexRoad2].Side1[Roads[indexRoad2].RoadLength-1]);
                // Console.WriteLine(String.Format("{0} à quitté {1} pour {2}",Roads[indexRoad2].Side2[Roads[indexRoad2].RoadLength-1].Name, Roads[indexRoad1].RoadName, Roads[indexRoad2].RoadName));
            }
        }
        private bool AnyoneWantTurn(Road road){
            return road.Side2[0] != null;
        }
        private bool IsWantedRoadAvailable(Road road){
            return road.Side2[road.RoadLength-1] == null;
        }
        private bool AllRoadFull(){
            
            for (int i = 0; i < Roads.Count; i++){
                if (Roads[i].Side2[0] == null && Roads[i].Side2[1] == null){
                    return false;
                }
            }
            return true;
        }
        public bool IsFinish(){
            for (int i = 0; i < Roads.Count; i++)
            {
                if (Roads[i].GetNumberVehicles() != -1){
                    return false;
                }
            }
            return true;
        }
    }
}