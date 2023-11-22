namespace SurMaRoute
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Road> allRoads = new() { new("D1",null, true), new("D2",null, true), new("D3",null, true), new("D4",null, true)};
            GiveWay GiveWay1 = new("side1", allRoads);
            // GiveWay1.Roads[0].DisplayRoad();
            // GiveWay1.Roads[1].DisplayRoad();
            // GiveWay1.Roads[2].DisplayRoad();
            // GiveWay1.Roads[3].DisplayRoad();
            GiveWay1.Move();
            while (!GiveWay1.IsFinish()){
                Console.Write("Entrez quelque chose : ");
                string? userInput = Console.ReadLine();
                if (userInput != null){
                    // GiveWay1.Roads[0].DisplayRoad();
                    // GiveWay1.Roads[1].DisplayRoad();
                    // GiveWay1.Roads[2].DisplayRoad();
                    // GiveWay1.Roads[3].DisplayRoad();
                    GiveWay1.Move();
                }
            }
        }
    }
}
