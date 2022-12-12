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

            objects.Add(new Animal(608, 700, 10, 10,0,0,0,0));
            objects.Add(new Animal(403, 650, 10, 10,0,0,0,0));
            objects.Add(new Animal(501, 550, 10, 10,0,0,0,0));
            objects.Add(new Animal(701, 600, 10, 10,0,0,0,0));
            objects.Add(new Animal(900, 500, 10, 10,0,0,0,0));
            objects.Add(new Animal(1000,400, 10, 10,0,0,0,0));
            objects.Add(new Animal(100, 300, 10, 10,0,0,0,0));
            objects.Add(new Animal(800, 200, 10, 10,0,0,0,0));

            objects.Add(new Plant(random.Next(100, 1400), random.Next(100, 550), 10, 10,30,60,0,0));
            
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