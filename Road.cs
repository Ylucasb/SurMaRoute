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

        private Intersection? _exit1 = null;

        public Intersection? Exit1
        {
            get => _exit1;
            set => _exit1 = value;
        }
        private Intersection? _exit2 = null;

        public Intersection? Exit2
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

        public Road(int length, List<(int, Vehicle)> carsPositionsSide1, List<(int, Vehicle)> carsPositionsSide2, Intersection? entry = null, Intersection? exit = null)
        {
            this.RoadLength = length;
            this.Side1 = GenerateNullListAndAddVehicle(length, carsPositionsSide1);
            this.Side2 = GenerateNullListAndAddVehicle(length, carsPositionsSide2);
            this.Exit1 = entry;
            this.Exit2 = exit;

        }

        public Road(int length, Intersection? entry = null, Intersection? exit = null)
        {
            this.RoadLength = length;
            List<(int, Vehicle)> randomList1 = GenerateRandomCarList(length);
            List<(int, Vehicle)> randomList2 = GenerateRandomCarList(length);
            this.Side1 = GenerateNullListAndAddVehicle(length, randomList1);
            this.Side2 = GenerateNullListAndAddVehicle(length, randomList2);
            this.Exit1 = entry;
            this.Exit2 = exit;
        }

        public Road()
        {
            Random random = new();
            int randomLength = random.Next(3, 20 + 1);
            this.RoadLength = randomLength;
            List<(int, Vehicle)> randomList1 = GenerateRandomCarList(randomLength);
            List<(int, Vehicle)> randomList2 = GenerateRandomCarList(randomLength);
            this.Side1 = GenerateNullListAndAddVehicle(randomLength, randomList1);
            this.Side2 = GenerateNullListAndAddVehicle(randomLength, randomList2);
        }

        public void AddVehicle(string side, Vehicle vehicle)
        {
            switch (side)
            {
                case "1":
                    if (Side1.Last() == null)
                    {
                        Side1[^1] = vehicle;
                        Console.WriteLine("Car added to Side 1");
                    }
                    else
                    {
                        Console.WriteLine("Can't add car, Side 1 is full");
                    }
                    break;

                case "2":
                    if (Side2.Last() == null)
                    {
                        Side2[^1] = vehicle;
                        Console.WriteLine("Car added to Side 2");
                    }
                    else
                    {
                        Console.WriteLine("Can't add car, Side 2 is full");
                    }
                    break;

                default:
                    Console.WriteLine("Invalid side");
                    break;
            }
        }


        public void DeleteCar(int position, string side)
        {
            switch (side)
            {
                case "1":
                    if (position >= 0 && position < Side1.Count)
                    {
                        Side1[position] = null;
                        Console.WriteLine("Car deleted from Side 1");
                    }
                    else
                    {
                        Console.WriteLine("Invalid position on Side 1");
                    }
                    break;

                case "2":
                    if (position >= 0 && position < Side2.Count)
                    {
                        Side2[position] = null;
                        Console.WriteLine("Car deleted from Side 2");
                    }
                    else
                    {
                        Console.WriteLine("Invalid position on Side 2");
                    }
                    break;

                default:
                    Console.WriteLine("Invalid side");
                    break;
            }
        }

        public int GetNumberVehicles()
        {
            int TotalNb = this.Side1.Count + this.Side2.Count;
            if (TotalNb == 0)
            {
                Console.WriteLine("No cars on the road");
                return -1;
            }
            return TotalNb;
        }

        public bool IsRoadFull()
        {
            return GetNumberVehicles() == this.RoadLength;
        }

        public void Move()
        {
            Console.WriteLine("Vehicles have moved");
            MoveSide(this.Side1, this.Exit1,"side1");
            MoveSide(this.Side2, this.Exit2,"side2");
        }

        private static void MoveSide(List<Vehicle?> side, Intersection? exit , string sideName)
        {
            if (exit == null)
            {
                side.RemoveAt(0);
                side.Add(null);
                Console.WriteLine($"The vehicle has exited the road on side {sideName} \n");
            }
            else
            {
                for (int i = 1; i < side.Count; i++)
                {
                    if (side[i] != null && side[i - 1] == null)
                    {
                        side[i - 1] = side[i];
                        side[i] = null;
                    }
                }
            }
        }

        private static List<(int, Vehicle)> GenerateRandomCarList(int numberOfElements)
        {
            List<(int, Vehicle)> tupleList = new();
            Random random = new();
            for (int i = 0; i < numberOfElements; i++)
            {
                int randomInt = random.Next(numberOfElements);
                Car car = new();
                tupleList.Add((randomInt, car));
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

        public static void DisplaySide(List<Vehicle?> side, string sideName)
        {
            Console.WriteLine(sideName);
            foreach (Vehicle? valeur in side)
            {
                if (valeur == null)
                {
                    Console.WriteLine("null");
                }
                else
                {
                    Console.WriteLine(valeur.Icon);
                }

            }
            Console.WriteLine("");
        }
    }
}