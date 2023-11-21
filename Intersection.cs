namespace SurMaRoute{
    abstract class Intersection{
        private List<Road> _roads = new List<Road>();
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
    }   
}