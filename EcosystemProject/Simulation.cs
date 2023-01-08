
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
            //Add default Objects to the simulation
            
            Add(new Animal(typeof(Carnivorous), Colors.Red, random.Next(100, 1300), random.Next(100, 550), 10, 10, 100, 30, "M", "No", this, 0));
            Add(new Animal(typeof(Carnivorous), Colors.Red, random.Next(100, 1300), random.Next(100, 550), 10, 10, 100, 30, "F", "No", this, 0));
            Add(new Animal(typeof(Herbivorous), Colors.Red, random.Next(100, 1300), random.Next(100, 550), 10, 10, 100, 30, "M", "No", this, 0));
            Add(new Animal(typeof(Herbivorous), Colors.Red, random.Next(100, 1300), random.Next(100, 550), 10, 10, 100, 30, "M", "No", this, 0));
            Add(new Animal(typeof(Herbivorous), Colors.Red, random.Next(100, 1300), random.Next(100, 550), 10, 10, 100, 30, "F", "No", this, 0));
            Add(new Animal(typeof(Herbivorous), Colors.Red, random.Next(100, 1300), random.Next(100, 550), 10, 10, 100, 30, "F", "No", this, 0));
            Add(new Plant(random.Next(100, 1300), random.Next(100, 550), 10, 10, 160, 50, this, 0));
            Add(new Plant(random.Next(100, 1300), random.Next(100, 550), 10, 10, 160, 50, this, 0));
            Add(new Plant(random.Next(100, 1300), random.Next(100, 550), 10, 10, 160, 50, this, 0));
            Add(new Plant(random.Next(100, 1300), random.Next(100, 550), 10, 10, 160, 50, this, 0));
            Add(new Plant(random.Next(100, 1300), random.Next(100, 550), 10, 10, 160, 50, this, 0));
            Add(new Plant(random.Next(100, 1300), random.Next(100, 550), 10, 10, 160, 50, this, 0));

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
                //Add limite zone depending on the value of Radius
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