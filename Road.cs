namespace SurMaRoute
{
    class Road
    {
        private int _roadLength;
        public int RoadLength
        {
            get => _roadLength;
            set => _roadLength = value;
        }

        private Intersection _exit1 = null;

        public Intersection Exit1
        {
            get => _exit1;
            set => _exit1 = value;
        }
        private Intersection _exit2 = null;

        public Intersection Exit2
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

        public Road(int length, List<int> carsPositionsSide1, List<int> carsPositionsSide2, Intersection? entry, Intersection? exit)
        {
            this.RoadLength = length;
            List<Vehicle?> tempListSide1 = new();
            for (int i = 0; i < length; i++)
            {
                tempListSide1.Add(null);
            }
            foreach (var car in carsPositionsSide1)
            {
                tempListSide1[car] = new Vehicle();
            }
            List<Vehicle?> tempListSide2 = new();
            for (int i = 0; i < length; i++)
            {
                tempListSide2.Add(null);
            }
            foreach (var car in carsPositionsSide2)
            {
                tempListSide2[car] = new Vehicle();
            }
            this.Side1 = tempListSide1;
            this.Side2 = tempListSide2;
            this.Exit1 = entry;
            this.Exit2 = exit;

        }

        public void AddCar(string side)
        {
            if (side == "0")
            {
                if (this.Side1.Last() != null)
                {
                    this.Side1[this.Side1.Count() - 1] = new Vehicle();
                }
            }
            else
            {
                if (this.Side2.Last() != null)
                {
                    this.Side2[this.Side2.Count() - 1] = new Vehicle();
                }
            }
        }

        public int NumberCar()
        {
            int TotalNb = this.Side1.Count + this.Side2.Count;
            if (TotalNb == 0)
            {
                Console.WriteLine("no cars on the road");
                return -1;
            }
            else
            {
                return TotalNb;
            }
        }



        public void Move()
        {
            if (this.Exit1 == null)
            {
                this.Side1.RemoveAt(0);
                this.Side1.Add(null);
                Console.WriteLine("The vehicle has exit the road");
            }
            else
            {
                if (this.Side1[0] != null)
                {
                    for (int i = 2; i < this.Side1.Count; i++)
                    {
                        this.Side1[i - 1] = this.Side1[i];
                    }
                }
                else
                {
                    this.Side1.RemoveAt(0);
                    this.Side1.Add(null);
                }

            }


            if (this.Exit2 == null)
            {
                this.Side1.RemoveAt(0);
                this.Side1.Add(null);
                Console.WriteLine("The vehicle has exit the road");
            }
        }


    }
}