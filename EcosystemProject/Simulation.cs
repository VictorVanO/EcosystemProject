//using System;
//using System.Threading.Tasks;
//using Microsoft.Maui.Controls;

namespace EcosystemProject
{
	public class Simulation : IDrawable
    {
        List<SimulationObject> objects;

        public Simulation()
        {
            objects = new List<SimulationObject>();

            objects.Add(new Animal(200, 200));
            objects.Add(new Animal(1000, 400));
            objects.Add(new Plant(700, 500));
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
                canvas.FillColor = drawable.Color;
                canvas.FillCircle(new Point(drawable.X, drawable.Y), 10.0);
            }
        }
    }
}