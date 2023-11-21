namespace SurMaRoute
{
    public class TrafficLightIntersection : Intersection
    {

        public TrafficLightIntersection(string name) : base(name)
        {
            this.Name = name;
            for (int i = 0; i < 4; i++)
            {
                Roads.Add(new Road());  
            }
            for (int i = 0; i < 2; i++)
            {
                TrafficLight trafficLight = new TrafficLight();
                var cancelSource = new CancellationTokenSource();
                Task changeColorTask = trafficLight.ChangeColorAsync();
            }
            
        }
        public override void Move()
        {
            foreach (var road in Roads)
            {
                road.Move();
            }
        }
    }
}