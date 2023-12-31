using System.Data.Common;

namespace SurMaRoute
{
    public class Road
    {
        private int _roadLength;
        public int RoadLength
        {
            get => _roadLength;
            set => _roadLength = value;
        }
        private string _roadName = "Unknown";
        public string RoadName
        {
            get => _roadName;
            set => _roadName = value;
        }
        private bool? _exit1 = null;
        public bool? Exit1
        {
            get => _exit1;
            set => _exit1 = value;
        }
        private bool? _exit2 = null;
        public bool? Exit2
        {
            get => _exit2;
            set => _exit2 = value;
        }
        private List<Vehicle?> _side1 = new(0); // exit 
        public List<Vehicle?> Side1
        {
            get => _side1;
            set => _side1 = value;
        }
        private List<Vehicle?> _side2 = new(0); // entry
        public List<Vehicle?> Side2
        {
            get => _side2;
            set => _side2 = value;
        }

        public Road(string roadName, int length, List<(int, Vehicle)> carsPositionsSide1, List<(int, Vehicle)> carsPositionsSide2, bool? entry = null, bool? exit = null)
        {
            this.RoadLength = length;
            this.Side1 = GenerateNullListAndAddVehicle(length, carsPositionsSide1);
            this.Side2 = GenerateNullListAndAddVehicle(length, carsPositionsSide2);
            this.Exit1 = entry;
            this.Exit2 = exit;
            this.RoadName = roadName;
        }

        public Road(string roadName, bool? entry = null, bool? exit = null)
        {
            Random random = new();
            int randomLength = random.Next(5, 20);
            this.RoadLength = randomLength;
            List<(int, Vehicle)> randomList1 = GenerateRandomCarList(randomLength);
            List<(int, Vehicle)> randomList2 = GenerateRandomCarList(randomLength);
            this.Side1 = GenerateNullListAndAddVehicle(randomLength, randomList1);
            this.Side2 = GenerateNullListAndAddVehicle(randomLength, randomList2);
            this.Exit1 = entry;
            this.Exit2 = exit;
            this.RoadName = roadName;
        }

        public int GetNumberVehicles()
        {
            int TotalNb = 0;
            foreach (var item in this.Side1)
            {
                if (item != null)
                {
                    TotalNb += 1;
                }
            }
            foreach (var item in this.Side2)
            {
                if (item != null)
                {
                    TotalNb += 1;
                }
            }
            if (TotalNb == 0)
            {
                Console.WriteLine(String.Format("No cars on the road : {0}", RoadName));
                return -1;
            }
            return TotalNb;
        }
        public void Move()
        {
            // Console.WriteLine("Vehicles have moved");
            MoveSide(this.Side1, this.Exit1, "side1");
            MoveSide(this.Side2, this.Exit2, "side2");
        }

        private void MoveSide(List<Vehicle?> side, bool? exit, string sideName)
        {
            if (exit == null)
            {
                if (side.First() != null)
                {
                    Console.WriteLine($"Vehicle has exited the road {RoadName} {sideName}");
                }
                side.RemoveAt(0);
                side.Add(null);
            }
            else
            {
                for (int i = 1; i < side.Count; i++)
                {
                    if (side[i] != null && side[i - 1] == null)
                    {
                        Console.WriteLine(String.Format("A vehicle moves forward on the road {0} lane {1}", RoadName, sideName));
                        side[i - 1] = side[i];
                        side[i] = null;
                    }
                }
            }
        }

        private static List<(int, Vehicle)> GenerateRandomCarList(int numberOfElements)
        {
            List<(int, Vehicle)> tupleList = new();
            List<Vehicle> listVehicles = new(){ new Car(), new Truck() };
            Random random = new();
            for (int i = 0; i < numberOfElements; i++)
            {
                int randomInt = random.Next(numberOfElements);
                int randomIntVehicleType = random.Next(listVehicles.Count);
                Vehicle vehicle = listVehicles[randomIntVehicleType];
                tupleList.Add((randomInt, vehicle));
            }
            return tupleList;
        }

        private static List<Vehicle?> GenerateNullListAndAddVehicle(int length, List<(int, Vehicle)> listVehicles)
        {
            List<Vehicle?> tempListSide = new(new Vehicle?[length]);
            foreach (var (index, vehicle) in listVehicles)
            {
                tempListSide[index] = vehicle;
            }
            return tempListSide;
        }
        public void DisplayRoad()
        {
            Console.WriteLine("Current road : " + this.RoadName);
            for (int i = 0; i < this.Side1.Count; i++)
            {
                string temp = "| ";
                if (this.Side1[i] == null)
                {
                    temp += "  ";
                }
                else
                {
                    temp += this.Side1[i]?.Icon;
                }
                temp += " : ";
                if (this.Side2[i] == null)
                {
                    temp += "  ";
                }
                else
                {
                    temp += this.Side2[i]?.Icon;
                }
                temp += " |";
                Console.WriteLine(temp);

            }
        }
    }
}