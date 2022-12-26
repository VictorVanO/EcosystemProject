//using System;
//using System.Threading.Tasks;
//using Microsoft.Maui.Controls;


namespace EcosystemProject
{
    
	public class Simulation : IDrawable
    {
        public List<SimulationObject> objects;

        Random random = new Random();

        public Simulation()
        {
            objects = new List<SimulationObject>();

            objects.Add(new Animal(200, 200, 10, 10, 0, 0, this));
            objects.Add(new Animal(1000, 400, 10, 10, 0, 0, this));
            objects.Add(new Plant(random.Next(100, 1400), random.Next(100, 550), 10, 10, 0, 0, this));
            
            

        }
        public void Update()
        {
            var tmp_objects = new List<SimulationObject>(objects);
            foreach (SimulationObject drawable in tmp_objects)
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