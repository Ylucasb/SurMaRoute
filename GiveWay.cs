namespace SurMaRoute{
    class GiveWay : Intersection{
        public GiveWay(string name):base(name){}
        public override void Move(){
            if (AllRoadFull()){
                Random rnd = new Random();
                int indexRoad1 = rnd.Next(0, (Roads.Count-1));
                MoveVehicle(indexRoad1);
            }
            for (int i = 0; i < roads.Count; i++)
            {
                MoveVehicle(i, index)
                Roads[i].Move();
            }
        }
        private void MoveVehicle(int indexRoad1){
            int indexRoad2 = indexRoad1+1;
            if (indexRoad2 == Roads.Count){
                indexRoad2 = 0;
            }
            if (AnyoneWantTurn(Roads[indexRoad1]) && !IsRoadFull(Roads[indexRoad2]) && IsNobodyOnLeft(Roads[indexRoad2])){
                // Vehicle saveVehicle = Roads[i].Side1[road.Count-1]
                (Roads[indexRoad2].Side2[Roads[indexRoad2].RoadLength-1], Roads[indexRoad1].Side2[0]) = (Roads[indexRoad1].Side2[0], Roads[indexRoad2].Side2[Roads[indexRoad2].RoadLength-1]);
                Console.WriteLine(String.Format("{0} à quitté {1} pour {2}",Roads[indexRoad2].Side2[Roads[indexRoad2].RoadLength-1].Name, Roads[indexRoad1].Name, Roads[indexRoad2].Name));
                // Roads[index].Side1[0] = saveVehicle
            }
        }
        private bool AnyoneWantTurn(Road road){
            return road.Side2[road.RoadLength-1] != null;
        }
        private bool IsRoadFull(Road road){
            return road.Side2[0] != null;
        }
        private bool IsNobodyOnLeft(Road road){
            return road.Side1[0] == null && road.Side1[1] == null;
        }
        private bool AllRoadFull(){
            for (int i = 0; i < Roads.Count; i++){
                if (Roads[i].Side2[0] == null){
                    return false;
                }
            }
            return true;
        }
    }
}