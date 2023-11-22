namespace SurMaRoute
{
    class TrafficLightIntersection : Intersection
    {
        private TrafficLight TrafficColor;

        public TrafficLightIntersection(string name, List<Road> roads):base(name, roads)
        {
            TrafficColor = new TrafficLight();
            _ = new CancellationTokenSource();
            _ = TrafficColor.ChangeColorAsync();
        }
        public override bool IsPossibleToMove(int currentIndex)
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
        public override void Move(){
            for (int i = 0; i < Roads.Count; i++)
            {
                MoveVehicle(i);
                Roads[i].Move();
            }
        }
    }
}