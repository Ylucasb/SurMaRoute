namespace SurMaRoute
{
    public class Car : Vehicle
    {
        public override string Name
        {
            get { return "Car"; }
        }
        public override string Icon
        {
            get { return "🚗"; }
        }
        public Car() {}
    }
}