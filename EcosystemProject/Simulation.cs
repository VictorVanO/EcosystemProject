//using System;
//using System.Threading.Tasks;
//using Microsoft.Maui.Controls;


namespace EcosystemProject
{
    
	public class Simulation : IDrawable
    {
        private List<SimulationObject> objects;

        public List<SimulationObject> Objects { get { return new List<SimulationObject>(objects); } }

        Random random = new Random();

        public Simulation()
        {
            objects = new List<SimulationObject>();

            Add(new Animal(typeof(Carnivorous), Colors.Red, random.Next(1000, 1200), random.Next(500, 550), 10, 10, 100, 30, "M", this));
            Add(new Animal(typeof(Herbivorous), Colors.Red, random.Next(1000, 1200), random.Next(500, 550), 10, 10, 100, 30, "F", this)); 

            //Add(new Animal(typeof(Herbivorous), Colors.Red, random.Next(100, 1400), random.Next(100, 550), 10, 10, 100, 30, "M", this));
            //Add(new Animal(typeof(Herbivorous), Colors.Red, random.Next(100, 1400), random.Next(100, 550), 10, 10, 100, 30, "F", this));


            //Add(new Plant(random.Next(100, 1400), random.Next(100, 550), 10, 10, 160, 50, this));
            //Add(new Plant(random.Next(100, 1400), random.Next(100, 550), 10, 10, 160, 50, this));
            //Add(new Plant(random.Next(100, 1400), random.Next(100, 550), 10, 10, 160, 50, this));
        }
        public void Update()
        {
            foreach (SimulationObject drawable in Objects)
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

        public void Add(SimulationObject obj)
        {
            objects.Add(obj);
        }

        public void Remove(SimulationObject obj)
        {
            objects.Remove(obj);
        }
        
    }
    
}