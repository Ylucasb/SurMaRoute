using System.Runtime.CompilerServices;

namespace SurMaRoute{
    class GiveWay : Intersection{
        public GiveWay(string name, List<Road> roads):base(name, roads){}
        public override void Move(){
            int indexRoad1 = -1;
            if (AllRoadFull()){
                Random rnd = new();
                indexRoad1 = rnd.Next(0, Roads.Count-1);
                MoveVehicle(indexRoad1);
                Roads[indexRoad1].Move();
            } 
            for (int i = 0; i < Roads.Count; i++)
            {
                if (i != indexRoad1){
                    MoveVehicle(i);
                    Roads[i].Move();
                }
            }
        }
        public override bool IsPossibleToMove(int indexRoad){
            return Roads[indexRoad].Side1[0] == null && Roads[indexRoad].Side1[1] == null;
        }
        private bool AllRoadFull(){
            for (int i = 0; i < Roads.Count; i++){
                if (Roads[i].Side2[0] == null && Roads[i].Side2[1] == null){
                    return false;
                }
            }
            return true;
        }
    }
}