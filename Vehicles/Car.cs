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

        public void SetDesination(int start , int end){
            Random rand = new();
            int newDestination = rand.Next(start , end + 1);
            this.Destination = newDestination;
        }

        public Car() { }
    }
}