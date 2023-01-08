//using System;
//using System.Threading.Tasks;
//using Microsoft.Maui.Controls;



namespace EcosystemProject
{
    
	public class Simulation : IDrawable
    {
        List<SimulationObject> objects;

        public List<SimulationObject> Objects { get { return new List<SimulationObject>(objects); } }

        Random random = new Random();

        public Simulation()
        {
            objects = new List<SimulationObject>();
            
            //Add(new Animal(typeof(Carnivorous), Colors.Red, random.Next(1000, 1200), random.Next(500, 550), 10, 10, 100, 30, "M","No", this, 0));
            Add(new Animal(typeof(Herbivorous), Colors.Red, random.Next(1100, 1200), random.Next(500, 550), 10, 10, 100, 30, "F", "No", this,0)); 
            Add(new Animal(typeof(Herbivorous), Colors.Red, random.Next(1100, 1200), random.Next(500, 550), 10, 10, 100, 30, "M", "No", this,0));
            Add(new Animal(typeof(Herbivorous), Colors.Red, random.Next(100, 1400), random.Next(100, 550), 10, 10, 100, 30, "F", "No", this,0));
            Add(new Plant(random.Next(1100, 1400), random.Next(500, 550), 10, 10, 160, 50, this,0));
            Add(new Plant(random.Next(100, 1400), random.Next(100, 550), 10, 10, 160, 50, this,0));
            Add(new Plant(random.Next(100, 1400), random.Next(100, 550), 10, 10, 160, 50, this,0));

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
                //limite zone
                canvas.StrokeColor = Colors.White;
                canvas.DrawLine(drawable.Radius * 0, drawable.Radius * 0, drawable.Radius * 1400, drawable.Radius * 0);
                canvas.DrawLine(drawable.Radius * 0, drawable.Radius * 650, drawable.Radius * 1400, drawable.Radius * 650);
                canvas.DrawLine(drawable.Radius * 0, drawable.Radius * 0, drawable.Radius * 0, drawable.Radius * 650);
                canvas.DrawLine(drawable.Radius * 1400, drawable.Radius * 0, drawable.Radius * 1400, drawable.Radius * 650);
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