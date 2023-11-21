namespace SurMaRoute{
    abstract class Intersection{
        private List<Road> _roads = new List<Road>();
        public List<Road> Roads 
        {
            get {return _roads;}
            set {_roads=value;}
        }
        public string Name {get;set;} = "";
        public Intersection(string name){
            this.Name = name;
            for (int i = 0; i < 4; i++)
            {
                _roads.Add(new Road());  
            }
        }
        public virtual void Move(){}
    }   
}