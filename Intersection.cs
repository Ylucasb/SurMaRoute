namespace SurMaRoute{
    abstract class Intersection{
        private List<Road> _roads = new List<Road>();
        public List<Road> roads 
        {
            get {return _roads;}
            set {_roads=value;}
        }
        public string name {get;set;} = "";
        public Intersection(string name){
            this.name = name;
            for (int i = 0; i < 4; i++)
            {
                _roads.Add(new Road());  
            }
        }
    }   
}