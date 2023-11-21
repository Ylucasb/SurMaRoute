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
        public bool IfSelectedCarCanMove(int currentIndex)
        {
            if (currentIndex%2 == 0 && (TrafficColor.Color == TrafficLightColor.Green )){

                return false;

            }else if (currentIndex%2 != 0 && TrafficColor.Color == TrafficLightColor.Red || TrafficColor.Color == TrafficLightColor.Orange){
                return false;
            }
            return true;
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