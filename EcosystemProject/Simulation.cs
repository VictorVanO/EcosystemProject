namespace EcosystemProject
{
	public class Simulation : IDrawable
    {
        List<DrawableObject> objects;
        public Simulation()
        {
            objects = new List<DrawableObject>();

            objects.Add(new Animal(100, 100));
            objects.Add(new Plant(500, 100));
        }
        public void Draw(ICanvas canvas, RectF dirtyRect)
        {
            foreach (DrawableObject drawable in objects)
            {
                canvas.FillColor = drawable.Color;
                canvas.FillCircle(new Point(drawable.X, drawable.Y), 10.0);
            }
        }
    }
}