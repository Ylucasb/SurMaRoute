namespace SurMaRoute
{
    class Car : Vehicle
    {
        public override string Name
        {
            get { return "Car"; }
        }
        public override string Icon
        {
            get { return "🚗"; }
        }
        private int _destination;
        public override int Destination
        {
            get => _destination;
            set => _destination = value;
        }
        public void SetPosition(int roadIndex){
            Random rand = new();
            int newDestination = rand.Next(0 , 3);
            while (newDestination != roadIndex){
                newDestination = rand.Next(0 , 3);
            }
            this.Destination = newDestination;
        }
        public Car() { }
    }
}