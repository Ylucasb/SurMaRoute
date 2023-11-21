namespace SurMaRoute {
    public abstract class Vehicle {
        public virtual string Name { get; set; } = "";
        public virtual string Icon { get; set; } = "";

        public Vehicle(){
            this.Name = "Unknown";
        }
    }
}