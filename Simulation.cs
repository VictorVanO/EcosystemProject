namespace EcosystemProject
{
	public class Simulation : IDrawable
    {
        List<DrawableObject> objects;
        public Simulation()
        {
            objects = new List<DrawableObject>();

            objects.Add(new Animal(200, 300,150,50));
            objects.Add(new Plant(500, 100,100,0));
        }
        public void Draw(ICanvas canvas, RectF dirtyRect)
        {
            foreach (DrawableObject drawable in objects)
            {
                canvas.FillColor = drawable.Color;
                canvas.FillCircle(new Point(drawable.X, drawable.Y), 10.0);
                canvas.StrokeColor = Colors.Blue;
                canvas.DrawCircle(drawable.X, drawable.Y,drawable.D);
                canvas.StrokeColor = Colors.Orange;
                canvas.DrawCircle(drawable.X, drawable.Y, drawable.A);

            }
        }
    }
}