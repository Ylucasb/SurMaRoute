namespace SurMaRoute
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Road> allRoads = new() { new("D1",null, true), new("D2",null, true), new("D3",null, true), new("D4",null, true)};
            TrafficLightIntersection GiveWay1 = new("side1", allRoads);
            GiveWay1.Move();
            while (!GiveWay1.IsFinish()){
                Console.Write("Entrez quelque chose : ");
                string? userInput = Console.ReadLine();
                if (userInput != null){
                    GiveWay1.Move();
                }
            }
        }
    }
}
