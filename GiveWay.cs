namespace SurMaRoute{
    class GiveWay : Intersection{
        public GiveWay(string name):base(name){}

        public override void Move(){
            for (int i = 0; i < roads.Count; i++)
            {
                roads[i].Move();
                int index = i+1;
                if (index == roads.Count){
                    index = 0;
                }
                if (AnyoneWantTurn(roads[i]) && !IsRoadFull(roads[index])){
                    roads[i].side1[road.Count-1] = null;
                    roads[index].side1[0]
                }
            }
        }
        private bool AnyoneWantTurn(Road road){
            return road.side1[road.Count-1] != null;
        }
        private bool IsRoadFull(Road road){
            return road.side1[0] != null;
        }
    }
}