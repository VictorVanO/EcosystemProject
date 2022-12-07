//using System;
//using System.Threading.Tasks;
//using Microsoft.Maui.Controls;

namespace EcosystemProject
{
	public class Simulation : IDrawable
    {
        List<SimulationObject> objects;
        Random random = new Random();

        public Simulation()
        {
            objects = new List<SimulationObject>();

            objects.Add(new Animal(200, 200, 10, 10));
            objects.Add(new Animal(1000, 400, 10, 10));
            objects.Add(new Plant(random.Next(100, 1400), random.Next(100, 550), 10, 10));
            //objects.Add(new Poop(200, 200));
        }
        public void Update()
        {
            foreach (SimulationObject drawable in objects)
            {
                drawable.Update();
            }
        }
        public void Draw(ICanvas canvas, RectF dirtyRect)
        {
            foreach (SimulationObject drawable in objects)
            {
                drawable.Draw(canvas);
            }
        }
    }
}