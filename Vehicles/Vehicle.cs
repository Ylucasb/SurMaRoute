namespace SurMaRoute
{
    abstract class Vehicle
    {
        public virtual string Name { get; set; } = "";
        public virtual string Icon { get; set; } = "";
        public virtual int Destination { get; set; }

        public Vehicle()
        {
            this.Name = "Unknown";
            this.Icon = "Unknown";
        }
    }
}