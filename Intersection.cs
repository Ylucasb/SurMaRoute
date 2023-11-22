namespace SurMaRoute{
    abstract class Intersection{
        private List<Road> _roads = new();
        public List<Road> Roads 
        {
            get {return _roads;}
            set {_roads=value;}
        }
        public string Name {get;set;} = "";
        public Intersection(string name, List<Road> roads){
            this.Name = name;
            this._roads = roads;
        }
        public virtual void Move(){}
        public virtual bool IsPossibleToMove(int indexRoad){return true;}
        protected void MoveVehicle(int indexRoad1){
            int indexRoad2 = indexRoad1-1;
            if (indexRoad2 < 0){
                indexRoad2 = 3;
            }
            Road roadWanted = Roads[indexRoad1];
            List<Vehicle?> sideWanted = roadWanted.Side2;
            int positionWanted = -1;
            if (sideWanted != null && sideWanted.Count > 0) {
                Vehicle? firstVehicle = sideWanted[0];
                if (firstVehicle != null)
                {
                    positionWanted = firstVehicle.SetPositionWanted(indexRoad1);
                    if (positionWanted != -1 && IsWantedRoadAvailable(Roads[positionWanted]) && IsPossibleToMove(indexRoad2)){
                        (Roads[positionWanted].Side1[Roads[positionWanted].RoadLength-1], Roads[indexRoad1].Side2[0]) = (Roads[indexRoad1].Side2[0], Roads[positionWanted].Side1[Roads[positionWanted].RoadLength-1]);
                        Console.WriteLine(String.Format("{0} à quitté {1} pour {2}", firstVehicle.Name, Roads[indexRoad1].RoadName, Roads[positionWanted].RoadName));
                    }
                }
            }
        }
        private bool IsWantedRoadAvailable(Road road){
            return road.Side2[road.RoadLength-1] == null;
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