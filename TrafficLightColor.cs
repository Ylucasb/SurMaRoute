using System;
using System.Threading.Tasks;

//To initiat in intersection traffic light
// TrafficLight trafficLight = new TrafficLight();
// var cancelSource = new CancellationTokenSource();
// Task changeColorTask = trafficLight.ChangeColorAsync();

namespace SurMaRoute
{
    public enum TrafficLightColor
    {
        Green,
        Orange,
        Red
    }

    public class TrafficLight
    {
        public TrafficLightColor Color { get; set; }

        public TrafficLight()
        {
            this.Color = TrafficLightColor.Green;
        }

        public async Task ChangeColorAsync()
        {
            while (true)
            {
                switch (this.Color)
                {
                    case TrafficLightColor.Green:
                        this.Color = TrafficLightColor.Orange;
                        break;
                    case TrafficLightColor.Orange:
                        this.Color = TrafficLightColor.Red;
                        break;
                    case TrafficLightColor.Red:
                        this.Color = TrafficLightColor.Green;
                        break;
                }
                await Task.Delay(2000); // Wait for 2 seconds
                Console.WriteLine(Color);
            }
        }
    }
}
