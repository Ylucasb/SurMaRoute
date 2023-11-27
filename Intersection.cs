using System.Runtime.InteropServices.Marshalling;
using System.Text;

namespace SurMaRoute{
    abstract class Intersection{
        private List<Road> _roads = new();
        public List<Road> Roads 
        {
            get {return _roads;}
            set {_roads=value;}
        }
        public string Name {get;set;} = "";
        public TrafficLight? TrafficLight { get; private set; }

        public Intersection(string name, List<Road> roads){
            this.Name = name;
            this._roads = roads;
        }
        public virtual void Move(){}
        public virtual bool IsPossibleToMove(int indexRoad,string vehicleName){return true;}
        protected void MoveVehicle(int indexRoad1){
            int indexRoad2 = indexRoad1-1;
            if (indexRoad2 < 0){
                indexRoad2 = 3;
            }
            Road roadWanted = Roads[indexRoad1];
            List<Vehicle?> sideWanted = roadWanted.Side2;
            int positionWanted = -1;
            if (sideWanted != null && sideWanted.Count > 0) {
                Vehicle? firstVehicle = sideWanted[0];
                if (firstVehicle != null)
                {
                    positionWanted = firstVehicle.SetPositionWanted(indexRoad1);
                    if (positionWanted != -1 && IsWantedRoadAvailable(Roads[positionWanted]) && IsPossibleToMove(indexRoad2, firstVehicle.Name)){
                        (Roads[positionWanted].Side1[Roads[positionWanted].RoadLength-1], Roads[indexRoad1].Side2[0]) = (Roads[indexRoad1].Side2[0], Roads[positionWanted].Side1[Roads[positionWanted].RoadLength-1]);
                        Console.WriteLine(String.Format("{0} à quitté {1} pour {2}", firstVehicle.Name, Roads[indexRoad1].RoadName, Roads[positionWanted].RoadName));
                    }
                }
            }
        }
        private bool IsWantedRoadAvailable(Road road){
            return road.Side2[road.RoadLength-1] == null;
        }
        public bool IsFinish(){
            for (int i = 0; i < Roads.Count; i++)
            {
                if (Roads[i].GetNumberVehicles() != -1){
                    return false;
                }
            }
            return true;
        }

        public void DisplayRoad()
        {
            Console.Clear();
            
            VerticalRoad(Roads[0],false);
            RoadLineDisplay(" _");
            RoadLineDisplay("  ");
            HorizontalRoad(false,Roads[3].Side1,Roads[3].RoadLength);
            for (int i = 0; i < 9; i++)
            {
                Console.Write(" ");
            }
            HorizontalRoad(false,Roads[1].Side2,Roads[1].RoadLength);
            Console.WriteLine();
            RoadLineDisplay(" -");
            HorizontalRoad(true,Roads[3].Side2,Roads[3].RoadLength);
            for (int i = 0; i < 9; i++)
            {
                Console.Write(" ");
            }
            HorizontalRoad(true,Roads[1].Side1,Roads[1].RoadLength);
            Console.WriteLine();
            RoadLineDisplay(" _");
            VerticalRoad(Roads[2],true);
        }

        private void RoadLineDisplay(string character)
        {
            StringBuilder line = new StringBuilder();

            for (int i = 0; i < Roads[3].RoadLength; i++)
            {
                line.Append(character);
            }

            for (int i = 0; i < 9; i++)
            {
                line.Append(" ");
            }

            for (int i = 0; i < Roads[1].RoadLength; i++)
            {
                line.Append(character);
            }

            Console.WriteLine(line);
        }

        private void HorizontalRoad(bool reverse,List<Vehicle?> side,int roadLength){
            for (int i = 0; i < roadLength; i++)
            {

                if (side[i] != null && !reverse)
                {
                    Console.Write(side[i]!.Icon);
                }
                else if (side[side.Count-1-i] != null && reverse)
                {
                    Console.Write(side[side.Count-1-i]!.Icon );
                }
                else
                {
                    Console.Write("  ");
                }
            }
        }

        private void VerticalRoad(Road road,bool reverse){
            for (int i = 0; i < road.RoadLength; i++)
            {
                for (int j = 0; j <  Roads[3].RoadLength; j++)
                {
                    Console.Write("  ");
                }
                Console.Write("|");
                Console.Write(" ");

                if (!reverse)
                {
                    if (road.Side2[road.RoadLength-1-i]  != null )
                    {
                        Console.Write(road.Side2[road.RoadLength-1-i]!.Icon);
                    }
                    else
                    {
                        Console.Write("  ");
                    }

                }else{
                    if (road.Side1[road.RoadLength-1-i] != null)
                    {
                        Console.Write(road.Side1[road.RoadLength-1-i]!.Icon);
                    }
                    else
                    {
                        Console.Write("  ");
                    }
                }
                Console.Write(" ");
                Console.Write("|");
                Console.Write(" ");
                if (!reverse)
                {
                    if ( road.Side1[i]!= null)
                    {
                        Console.Write(road.Side1[i]!.Icon);
                    }
                    else
                    {
                        Console.Write("  ");
                    }
                }else{
                    if (road.Side2[i] != null)
                    {
                        Console.Write(road.Side2[i]!.Icon);
                    }
                    else
                    {
                        Console.Write("  ");
                    }
                }
                Console.Write(" ");
                Console.WriteLine("|");
                if (this.TrafficLight != null)
                {
                    switch (this.TrafficLight.Color)
                    {
                        case TrafficLightColor.Green:
                            Console.WriteLine("Traffic light is green");
                            break;
                        case TrafficLightColor.Orange:
                            Console.WriteLine("Traffic light is orange");
                            break;
                        case TrafficLightColor.Red:
                            Console.WriteLine("Traffic light is red");
                            break;
                    }
                }
                
            }
        }
        
    }   
}