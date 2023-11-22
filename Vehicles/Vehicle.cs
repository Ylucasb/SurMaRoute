namespace SurMaRoute
{
    public abstract class Vehicle
    {
        public virtual string Name { get; set; } = "";
        public virtual string Icon { get; set; } = "";
        private int _destination = -1;
        public int SetPositionWanted(int roadIndex){
            if (_destination == -1){
                Random rand = new();
                int newDestination = rand.Next(0 , 3);
                while (newDestination == roadIndex){
                    newDestination = rand.Next(0 , 3);
                }
                return newDestination;
            }
            return _destination;
        }
        public Vehicle()
        {
            this.Name = "Unknown";
            this.Icon = "Unknown";
        }
    }
}