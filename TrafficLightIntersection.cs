namespace SurMaRoute
{
    public class TrafficLightIntersection : Intersection
    {
        private TrafficLight TrafficColor;

        public TrafficLightIntersection(string name) : base(name)
        {

            TrafficColor = new TrafficLight();
            _ = new CancellationTokenSource();
            _ = TrafficColor.ChangeColorAsync();
        }
        public bool IfSelectedCarCanMove(Road road)
        {
            var currentIndex = Roads.IndexOf(road);
            Road exitRoad = Roads[RandomRangeExcept(Roads.Count, currentIndex)];
            
            if (currentIndex%2 == 0 && (TrafficColor.Color == TrafficLightColor.Green || TrafficColor.Color == TrafficLightColor.Orange)){
                if (road.Side2[0] != null && exitRoad.Side1.Last() == null)
                {
                    return true;
                }
            }else if (TrafficColor.Color == TrafficLightColor.Red){
                if (road.Side2[0] != null && exitRoad.Side1.Last() == null)
                {
                    return true;
                }
            }
            return false;
        }

        public static int RandomRangeExcept (int max,int except)
        {
        int number;
        do {
            Random random = new();
            number = random.Next(max);
        } while (number == except);
        return number;
        }
    }
}